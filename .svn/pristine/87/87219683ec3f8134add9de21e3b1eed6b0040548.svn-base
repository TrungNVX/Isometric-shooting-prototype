using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_CharacterControl : MonoBehaviour
{
    public Breathe breathe;
    public FPS_CharacterDataBinding dataBinding;
    public float speed=1;
    public CharacterController characterController_;
    public Transform camera_trans;
    private bool isAim_;
    public bool isAim
    {
        set
        {
            if(isAim_!=value)
            {
                isAim_ = value;
                dataBinding.IsAim = value;
                breathe.isBreath = value;
            }
        

        }
        get
        {
            return isAim_;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        dataBinding.Speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        isAim = FPS_InputManager.isZoom;

        float y = 0;
        if(!characterController_.isGrounded)
        {
            y = -1;
        }

        Vector3 dirMove = FPS_InputManager.moveDir;
        if (dirMove.magnitude > 0)
        {
            
            dataBinding.Speed = FPS_InputManager.isRun ? 2 : 1;
            speed=FPS_InputManager.isRun ? 3.5f : 2f;
            speed = isAim ? 2 : speed;
        }
        else
        {
            dataBinding.Speed = 0;
        }
        dirMove = camera_trans.TransformDirection(dirMove);
        dirMove.y = y;
        characterController_.Move(dirMove * Time.deltaTime * speed);
      
    }
}
