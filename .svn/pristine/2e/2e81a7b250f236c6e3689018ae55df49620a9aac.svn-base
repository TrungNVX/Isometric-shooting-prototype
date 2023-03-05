using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CreepChaseState : FSM_State
{

    [NonSerialized]
    public CreepControl parent;
    public override void OnEnter()
    {
        base.OnEnter();
        parent.m_agent.speed = 2;
        parent.m_agent.enabled = true;
        parent.m_agent.stoppingDistance = parent.attackrange * 0.8f;
    }
    public override void Update()
    {
        base.Update();


        float dis = Vector3.Distance(parent.trans.position, parent.player_target.position);

        if (dis <= parent.attackrange)
        {
            if (parent.attackTime >= parent.attackSpeed)
                parent.GotoState(parent.attackState);
        }
        else
        {
            parent.m_agent.SetDestination(parent.player_target.position);
            float speed = parent.m_agent.velocity.magnitude / parent.m_agent.desiredVelocity.magnitude;
            speed = speed * parent.m_agent.speed;
            parent.dataBinding.Speed = speed;
        }
        RotateCharacter();
    }
    public override void Exits()
    {
        base.Exits();
        parent.m_agent.enabled = false;
        parent.dataBinding.Speed = 0;
    }
    private void RotateCharacter()
    {
        Vector3 dir = parent.m_agent.steeringTarget - parent.trans.position;
        if (dir.magnitude > 0.2f)
        {
            dir.Normalize();
            Quaternion q = Quaternion.LookRotation(dir, Vector3.up);
            parent.trans.rotation = Quaternion.Slerp(parent.trans.rotation, q, Time.deltaTime * 360);
        }

    }
}
