using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataBinding : MonoBehaviour
{
    public Animator animator;
    public Vector3 Speed
    {
        set
        {
            animator.SetFloat(Anim_K_Speed_X, value.x);
            animator.SetFloat(Anim_K_Speed_Y, value.z);

        }
    }
    public float MoveType
    {
        set
        {
            animator.SetFloat(Anim_K_MoveType, value);
        }
    }
    public bool Isfire
    {
        set
        {
            if (value)
                animator.SetTrigger(Anim_K_Fire);
        }
    }
    public bool IsGround
    {
        set
        {
            animator.SetBool(Anim_K_IsGround, value);
        }
    }
    public bool Jump
    {
        set
        {
            animator.SetBool(Anim_K_jump, value);
        }
    }
    public bool Fall
    {
        set
        {
            animator.SetBool(Anim_K_Fall, value);
        }
    }
    private int Anim_K_Speed_X;
    private int Anim_K_Speed_Y;
    private int Anim_K_MoveType;
    private int Anim_K_Fire;
    private int Anim_K_IsGround;
    private int Anim_K_jump;
    private int Anim_K_Fall;
    // Start is called before the first frame update
    void Start()
    {
        Anim_K_Speed_X = Animator.StringToHash("Speed_X");
        Anim_K_Speed_Y = Animator.StringToHash("Speed_Y");
        Anim_K_MoveType = Animator.StringToHash("MoveType");
        Anim_K_Fire = Animator.StringToHash("Fire");
        Anim_K_IsGround = Animator.StringToHash("IsGround");
        Anim_K_jump = Animator.StringToHash("Jump");
        Anim_K_Fall = Animator.StringToHash("Fall");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
