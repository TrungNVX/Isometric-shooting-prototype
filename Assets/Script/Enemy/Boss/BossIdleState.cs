using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BossIdleState : FSM_State
{
    [NonSerialized]
    public Boss_Control parent;
    private float timeCount;
    private float timeRandom;
    public override void OnEnter()
    {
        timeCount = 0;
        timeRandom = UnityEngine.Random.Range(5, 10f);
        parent.dataBinding.Idle = true;
    }
    public override void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= timeRandom)
        {
            parent.GotoState(parent.jumpState);
        }
    }
}
