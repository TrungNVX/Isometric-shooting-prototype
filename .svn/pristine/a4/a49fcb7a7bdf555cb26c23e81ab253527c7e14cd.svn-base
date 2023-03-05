using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BossCallState : FSM_State
{
    [NonSerialized]
    public Boss_Control parent;
    private Vector3 posSpawn;
    public string enemy_ID;
    public int maxEnemy=2;
    public override void OnEnter(object data)
    {
        base.OnEnter(data);
        parent.dataBinding.Call = true;
        posSpawn = (Vector3)data;
    }
    public override void OnAnimationMiddle()
    {
        base.OnAnimationMiddle();
        // create enemy 
        MissionControl.instance.CreateEnemyBoss(enemy_ID, UnityEngine.Random.Range(1, maxEnemy),posSpawn);
        parent.GotoState(parent.idleState);
    }
}
