using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ZN_AttackState : FSM_State
{
    [NonSerialized]
    public ZombieNormalControl parent;
    // Start is called before the first frame update
    public override void OnEnter()
    {
        base.OnEnter();
        parent.databinding.Attack = true;
        parent.databinding.AttackIndex = UnityEngine.Random.Range(1, 4);
    }
    public override void OnAnimationMiddle()
    {
        base.OnAnimationMiddle();
        if(parent.player_target!=null)
        {
            Vector3 posPlayer = parent.player_target.position;
            posPlayer.y = parent.trans.position.y;
            Vector3 dir = posPlayer - parent.trans.position;
            dir.Normalize();
            float dot = Vector3.Dot(dir, parent.trans.forward);
            float dis = Vector3.Distance(posPlayer, parent.trans.position);
            if (dot > 0&&dis<=parent.attackrange)
            {
                EnemyDamageData data = new EnemyDamageData();
                data.damage = parent.config.Damage;
                parent.player_target.GetComponent<TPS_Iso_CharacterControl>().OnDamage(data);
            }
        }
       
    }
    public override void OnAnimationExist()
    {
        parent.GotoState(parent.chaseState);
    }
}
