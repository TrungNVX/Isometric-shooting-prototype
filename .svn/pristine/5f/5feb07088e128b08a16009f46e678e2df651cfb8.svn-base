using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDataInit
{
    public ConfigEnemyRecord config;
}
public class EnemyDamageData
{
    public int damage;
}
public class EnemyControl : FSM_System
{
    public NavMeshAgent m_agent;
    public Transform trans;
    public Transform player_target;
    public float rangeDetect=10;
    public float attackrange=2;
    public float attackSpeed=2;
    public float attackTime;
    public ConfigEnemyRecord config;
    public int hp;
    public int maxHP;
    public Transform anchorHub;
    private EnemyHubControl hubControl;
    public override void Awake()
    {
        base.Awake();
        trans = transform;
    }
    public virtual void Setup(EnemyDataInit enemyDataInit)
    {
        config = enemyDataInit.config;
        hp = config.HP;
        maxHP = config.HP;
        Transform hub_trans = BYPoolManager.instance.Spawn("EnemyHub");
        hubControl = hub_trans.GetComponent<EnemyHubControl>();
        hubControl.Init(anchorHub);
        hubControl.UpdateHP(hp, maxHP);
    }
    public virtual void OnDamage(BulletPlayerData bulletPlayer)
    {
        hubControl.UpdateHP(hp, maxHP);
    }
    public void OnDead()
    {
        MissionControl.instance.OnEnemyDead(this);
        BYPoolManager.instance.DeSpawn("EnemyHub",hubControl.transform);

        Destroy(gameObject);
    }
}
