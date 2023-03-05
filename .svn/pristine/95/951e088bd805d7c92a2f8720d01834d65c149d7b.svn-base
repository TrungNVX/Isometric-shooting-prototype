using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_CharacterDataBinding : MonoBehaviour
{
    public Animator animator;
    public bool IsAim
    {
        set
        {
            if(value)
            {
                animator.Play("Aim_in", 0, 0);
            }
            else
            {
                animator.Play("Aim_out", 0, 0);
            }
        }
    }
    public float Speed;
    private float cur_speed;
    private int key_Speed;
    private void Start()
    {
        key_Speed = Animator.StringToHash("Speed");
        FPS_WeaponControl.OnChangeGun.AddListener(OnchangeGun);
    }
    private void OnchangeGun(FPS_WeaponBehaviour fPS_Weapon)
    {
        animator = fPS_Weapon.animController;
    }
    private void Update()
    {
        cur_speed = Mathf.Lerp(cur_speed, Speed, Time.deltaTime * 20);
        animator.SetFloat(key_Speed, cur_speed);


    }
}
