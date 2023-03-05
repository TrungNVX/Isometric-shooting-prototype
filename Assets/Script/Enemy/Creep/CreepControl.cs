using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;
public class CreepControl : EnemyControl
{
    public CreepDataBinding dataBinding;
    public CreepDeadState deadState;
    public CreepChaseState chaseState;
    public CreepAttackState attackState;
    public CreepStartState startState;
    public override void Setup(EnemyDataInit enemyDataInit)
    {
        base.Setup(enemyDataInit);
        player_target = GameObject.FindGameObjectWithTag("Player").transform;
        m_agent.updateRotation = false;
        deadState.parent = this;
        chaseState.parent = this;
        attackState.parent = this;
        startState.parent = this;
        GotoState(startState);
    }
    public override void Update()
    {
        base.Update();
        attackTime += Time.deltaTime;
    }
    public override void OnDamage(BulletPlayerData bulletPlayer)
    {
        hp -= bulletPlayer.damage;

        if (hp <= 0)
        {
            if (CurrentState != deadState)
            {
                GotoState(deadState);
                Rigidbody rig = bulletPlayer.rigidbody_;
                if (rig != null)
                {
                    Vector3 force = 10 * bulletPlayer.force * bulletPlayer.dir;


                    var broadcaster = rig.GetComponent<MuscleCollisionBroadcaster>();

                    if (broadcaster != null)
                    {
                        broadcaster.Hit(2, force, bulletPlayer.point);


                    }
                }

            }
        }
        base.OnDamage(bulletPlayer);
    }
}
