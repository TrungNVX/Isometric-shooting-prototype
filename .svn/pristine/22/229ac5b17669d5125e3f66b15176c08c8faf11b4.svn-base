using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

[Serializable]
public class BossJumpState : FSM_State
{
    [NonSerialized]
    public Boss_Control parent;
    private bool isJumpProgress = false;
    private Coroutine coroutine_;
    public Transform lockTarget;
    public override void OnEnter()
    {
        lockTarget.SetParent(null);
        parent.m_agent.speed = 3;
        parent.m_agent.enabled = true;
        parent.m_agent.stoppingDistance = parent.attackrange * 0.8f;
        parent.dataBinding.Run = true;
        isJumpProgress = false;
        lockTarget.gameObject.SetActive(false);
    }
    public override void Update()
    {


        if (!isJumpProgress)
        {
            float dis = Vector3.Distance(parent.trans.position, parent.player_target.position);

            if (dis <= parent.rangeDetect)
            {
                isJumpProgress = true;
                parent.m_agent.enabled = false;
                coroutine_ = parent.StartCoroutine(JumpProgress());
            }
            else
            {
                parent.m_agent.SetDestination(parent.player_target.position);
                RotateCharacter();
            }
        }

    }
    IEnumerator JumpProgress()
    {
        parent.dataBinding.Idle = true;
        // lock target 
        Vector3 posPlayer = parent.player_target.position;
        posPlayer.y = parent.trans.position.y;
        Vector3 dir = posPlayer - parent.trans.position;
        if (dir.magnitude > 0.2f)
        {
            dir.Normalize();
            Quaternion q = Quaternion.LookRotation(dir, Vector3.up);
            parent.trans.rotation =q;
        }
        lockTarget.gameObject.SetActive(true);
        lockTarget.transform.position = parent.player_target.position;
        yield return new WaitForSeconds(0.5f);
        parent.dataBinding.Jump = true;

        parent.trans.DOJump(lockTarget.transform.position, 2.5f, 1, 1).OnComplete(() =>
         {
             posPlayer = parent.player_target.position;
             posPlayer.y = parent.trans.position.y;
             float dis = Vector3.Distance(posPlayer, parent.trans.position);
             if (dis <= parent.attackrange)
             {
                 EnemyDamageData data = new EnemyDamageData();
                 data.damage = parent.config.Damage;
                 parent.player_target.GetComponent<TPS_Iso_CharacterControl>().OnDamage(data);
             }
             parent.GotoState(parent.callState, lockTarget.transform.position);

         }).SetEase(Ease.Linear);

    }
    public override void Exits()
    {
        base.Exits();
        parent.m_agent.enabled = false;
        if (coroutine_ != null)
            parent.StopCoroutine(coroutine_);
        lockTarget.gameObject.SetActive(false);
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
