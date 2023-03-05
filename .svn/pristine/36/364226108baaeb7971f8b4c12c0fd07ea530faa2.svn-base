using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ZN_WanderState : FSM_State
{
    [NonSerialized]
    public ZombieNormalControl parent;
    private Coroutine coroutine_;
    public float range = 3f;
    private bool isStopMove;
    // Start is called before the first frame update
    public override void OnEnter()
    {
        isStopMove = false;
        parent.m_agent.speed = 1;
        parent.m_agent.enabled = true;
        parent.m_agent.stoppingDistance = 0;
        parent.m_agent.Warp(parent.trans.position);
        coroutine_ = parent.StartCoroutine(RanDomMove());
    }
    IEnumerator RanDomMove()
    {
        isStopMove = false;
        Vector2 posRandom = UnityEngine.Random.insideUnitCircle;

        Vector3 pos = new Vector3(posRandom.x, 0, posRandom.y);
        pos = pos * UnityEngine.Random.Range(1, range);
        pos = parent.ogrinalPos + pos;

        parent.m_agent.SetDestination(pos);
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(()=>parent.m_agent.remainingDistance <= 0.5f);
        isStopMove = true;
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if(isStopMove)
        {
            if (coroutine_ != null)
                parent.StopCoroutine(coroutine_);
            coroutine_ = parent.StartCoroutine(RanDomMove());
        }
        float speed = parent.m_agent.velocity.magnitude / parent.m_agent.desiredVelocity.magnitude;
        speed = speed * parent.m_agent.speed;
        parent.databinding.Speed = speed;
        RotateCharacter();
    }
    public override void Exits()
    {
        base.Exits();
        if (coroutine_ != null)
            parent.StopCoroutine(coroutine_);
        parent.m_agent.enabled = false;
        parent.databinding.Speed = 0;
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
