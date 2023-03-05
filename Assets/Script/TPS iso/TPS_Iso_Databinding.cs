using RootMotion.Demos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPS_Iso_Databinding : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public Animator GetAnimator()
    {
        return animator;
    }
    private int Anim_Key_X;
    private int Anim_Key_Y;
    public Vector3 MoveDir
    {
        set
        {
            animator.SetFloat(Anim_Key_X, value.x);
            animator.SetFloat(Anim_Key_Y, value.z);
        }
    }
    public bool isFire
    {
        set
        {
            if(value)
            {
                animator.Play("Fire", 1, 0);
            }
        }
    }
    public bool Reload
    {
        set
        {
            if (value)
            {
                animator.Play("Reload", 1, 0);
            }
        }
    }
    public bool Empty
    {
        set
        {
            if (value)
            {
                animator.Play("Empty", 1, 0);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Anim_Key_X = Animator.StringToHash("X");
        Anim_Key_Y = Animator.StringToHash("Y");

    }
    public void ChangeAnimatorControler(AnimatorOverrideController newAC)
    {
        animator.runtimeAnimatorController = newAC;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
