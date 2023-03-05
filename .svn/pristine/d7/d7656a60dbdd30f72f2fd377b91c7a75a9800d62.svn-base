using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CreepDeadState : FSM_State
{

    [NonSerialized]
    public CreepControl parent;
    private float timeCount;
    // Start is called before the first frame update
    public override void OnEnter()
    {
        base.OnEnter();
        //  parent.m_agent.isStopped = true;
        timeCount = 0;
        parent.m_agent.enabled = false;
        parent.dataBinding.Dead = true;
        parent.dataBinding.DeadIndex = UnityEngine.Random.Range(1, 5);
    }
    public override void OnAnimationExist()
    {
        base.OnAnimationExist();
    }
    public override void OnAnimationMiddle()
    {
        Debug.LogError(" dead anim done");
    }
    public override void FixedUpdate()
    {
        timeCount += Time.deltaTime;
        if (timeCount > 2)
        {
            parent.OnDead();
            timeCount = 0;
        }
    }
}
