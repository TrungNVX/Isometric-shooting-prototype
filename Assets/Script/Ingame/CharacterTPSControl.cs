using RootMotion.FinalIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterTPSControl : MonoBehaviour
{
    public CharacterDataBinding dataBinding;
    public CharacterController _characterController;
    public CameraControl cameraControl;
    public float speed_Crouch = 1;
    public float speed_walk = 2;
    public float speed_run = 4;
    private float _targetRotation;
    private Transform trans;
    public AimIK aimIK;
    private float timeDelayRotate;
    private bool isAimDelay;
    private float w_Aim = 0;
    public float groundOffset = 0.15f;
    public float groundRadious = 0.5f;
    public LayerMask groundLayer;
    public bool isGround;
    public float verticalVelocity;
    public float maxVerticalVelocity;
    public float gravity = -15f;
    public float jumpHeight = 1.3f;
    private float timeJumpRof;
    // Start is called before the first frame update
    void Start()
    {
        trans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        JumpGravity();
        GroundCheck();
        Move();
    }
    private void Move()
    {
        Vector2 move = FirstControlInput.move;
        float speedMove = 0;
        float motionBlend = 1;

        Vector3 inputDirection = new Vector3(move.x, 0, move.y).normalized;
        Vector3 moveDir = Vector3.zero;


        if (FirstControlInput.isFire)
        {
            dataBinding.MoveType = 2;
            speedMove = speed_walk;
        }
        else
        {
            if (FirstControlInput.isCrouch)
            {
                speedMove = speed_Crouch;
                dataBinding.MoveType = 0;
                motionBlend = 1;
            }
            else if (FirstControlInput.isRun)
            {
                speedMove = speed_run;
                dataBinding.MoveType = 1;
                motionBlend = 2;
            }
            else
            {
                speedMove = speed_walk;
                dataBinding.MoveType = 1;
                motionBlend = 1;
            }
        }
        if (move == Vector2.zero)
        {
            speedMove = 0;
            dataBinding.Speed = Vector3.zero;
            if (FirstControlInput.isFire)
            {
                trans.rotation = Quaternion.Euler(0.0f, cameraControl.rootCam.localEulerAngles.y, 0f);
            }
        }
        else
        {
            if (FirstControlInput.isFire || isAimDelay)
            {
                moveDir = trans.TransformDirection(inputDirection);
                trans.rotation = Quaternion.Euler(0.0f, cameraControl.rootCam.localEulerAngles.y, 0f);
                //moveDir = Quaternion.Euler(0.0f, cameraControl.rootCam.localEulerAngles.y, 0f)*Vector3.forward;
                dataBinding.Speed = inputDirection;
            }
            else
            {

                _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cameraControl.rootCam.localEulerAngles.y;
                float _rotationVel = 0;
                float rotaion_y = Mathf.SmoothDampAngle(trans.localEulerAngles.y, _targetRotation, ref _rotationVel, Time.deltaTime * 0.12f);
                trans.rotation = Quaternion.Euler(0.0f, rotaion_y, 0f);
                dataBinding.Speed = new Vector3(0, 0, motionBlend);
                moveDir = Quaternion.Euler(0.0f, _targetRotation, 0f) * Vector3.forward;
            }

        }
        if (!FirstControlInput.isFire)
        {
            timeDelayRotate += Time.deltaTime;
            if (timeDelayRotate > 1)
            {
                isAimDelay = false;
            }
            if (timeDelayRotate > 1)
            {
                w_Aim = 0;

            }

        }
        else
        {
            isAimDelay = true;
            timeDelayRotate = 0;
            w_Aim = 1;
        }



        _characterController.Move(moveDir * Time.deltaTime * speedMove + new Vector3(0, verticalVelocity, 0) * Time.deltaTime);
        float speedAim = w_Aim > 0 ? 20 : 3;
        aimIK.solver.IKPositionWeight = Mathf.MoveTowards(aimIK.solver.IKPositionWeight, w_Aim, Time.deltaTime * speedAim);
    }
    private void GroundCheck()
    {
        Vector3 spherePos = new Vector3(trans.position.x, trans.position.y - groundOffset, trans.position.z);
        isGround = Physics.CheckSphere(spherePos, groundRadious, groundLayer, QueryTriggerInteraction.Ignore);
        dataBinding.IsGround = isGround;

    }
    private void JumpGravity()
    {
        if (isGround)
        {
            dataBinding.Jump = false;
            dataBinding.Fall = false;
            if (verticalVelocity < 0)
            {
                verticalVelocity = -2;
            }
            if (FirstControlInput.isJump&&timeJumpRof<=0)
            {
                Debug.LogError(" jumpo");
                verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
                dataBinding.Jump = true;
            }
            if(timeJumpRof>=0)
            {
                timeJumpRof -= Time.deltaTime;
            }
        }
        else
        {
            timeJumpRof = 0.3f;
            FirstControlInput.isJump = false;
            if (verticalVelocity < 0)
                dataBinding.Fall = true;
        }
        if (verticalVelocity < maxVerticalVelocity)
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
    }
}
