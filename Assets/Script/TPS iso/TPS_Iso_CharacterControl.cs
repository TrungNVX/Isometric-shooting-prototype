using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TPS_Iso_CharacterControl : MonoBehaviour
{
    public TPS_Iso_Databinding databinding;
    public CharacterController characterController;
    [SerializeField]
    private bool isAim = false;
    private Transform trans;
    [SerializeField]
    private bool isGround;
    private int hp=30;
    private int maxHP=30;
    private bool isDead = false;
    public UnityEvent<int, int> OnHPChange;
    private void Awake()
    {
        trans = transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        OnHPChange?.Invoke(hp, maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = FirstControlInput.move;
        Vector3 moveDir = new Vector3(move.x, 0, move.y);
       // isAim = FirstControlInput.isFire;
        if (isAim)
        {
            moveDir = Quaternion.Euler(0, 45, 0) * moveDir;
            databinding.MoveDir = moveDir;
        }
        else
        {
            if(moveDir.magnitude>0)
            {
                Quaternion q = Quaternion.LookRotation(moveDir, Vector3.up);
                trans.rotation = q;
            }
        
            databinding.MoveDir = new Vector3(0, 0, moveDir.magnitude);
        }
        isGround = characterController.isGrounded;
        Vector3 pos = moveDir;
        pos.y = isGround ? 0 : -1;
        characterController.Move(pos*Time.deltaTime*4);
    }
    /*
    private void OnAnimatorMove()
    {
        // check isGround : BTVN
        Vector3 pos = databinding.GetAnimator().deltaPosition;
        pos.y= isGround ? 0 : -1;
        characterController.Move(pos);
    }
    */
    public void OnDamage(EnemyDamageData damage)
    {
        hp -= damage.damage;
        if(hp<=0&&!isDead)
        {
            isDead = true;
            MissionControl.instance.PlayerDead();
        }
        OnHPChange?.Invoke(hp, maxHP);
    }
}