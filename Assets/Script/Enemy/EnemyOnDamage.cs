using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyType
{
    NORMAL,
    HEAD,
    UP_BODY,
    LOW_BODY
}
public class EnemyOnDamage : MonoBehaviour
{
    public BodyType bodyType=BodyType.NORMAL;
    private EnemyControl parent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public  void OnDamage(BulletPlayerData bulletPlayer)
    {
        if (parent == null)
            parent = gameObject.GetComponentInParent<EnemyControl>();
        bulletPlayer.bodyType = bodyType;
        bulletPlayer.rigidbody_ = gameObject.GetComponent<Rigidbody>();
        parent.OnDamage(bulletPlayer);
    }
}
