using RootMotion.Dynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_DataBinding : MonoBehaviour
{
    public Animator animator;
    public PuppetMaster puppetMaster;
    public PuppetMaster.StateSettings deadState = PuppetMaster.StateSettings.Default;
    public bool Idle
    {
        set
        {
            animator.Play("Idle", 0, 0);
        }
    }
    public bool Run
    {
        set
        {
            animator.Play("Run", 0, 0);
        }
    }
    public bool Jump
    {
        set
        {
            animator.Play("Jump", 0, 0);
        }
    }
    public bool Call
    {
        set
        {
            animator.Play("Call", 0, 0);
        }
    }
    public bool Dead
    {
        set
        {
            puppetMaster.mode = PuppetMaster.Mode.Active;
            puppetMaster.Kill(deadState);

        }
    }
}
