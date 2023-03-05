using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : WeaponBehaviour
{

    protected override void InitWeapon()
    {
        base.InitWeapon();
        BYPool poolBullet = new BYPool();
        poolBullet.namePool = prefab_Projecties.name;
        poolBullet.total = clip_size;
        poolBullet.prefab_ = prefab_Projecties;
        BYPoolManager.instance.AddNewPool(poolBullet);

        BYPool poolImpact = new BYPool();
        poolImpact.namePool = prefab_imapact.name;
        poolImpact.total = clip_size;
        poolImpact.prefab_ = prefab_imapact;
        BYPoolManager.instance.AddNewPool(poolImpact);
        iWP_handle = new IHandGun();
        iWP_handle.InitHandle(this);
    }
    IEnumerator Reloading()
    {
        databinding.Reload = true;
      
        yield return new WaitForSeconds(reloadTime);
        EndReload();
    }
}
public class IHandGun : IWeaponHandle
{
    private HandGun wp_Behaviour;


    public void FireHandle()
    {
        wp_Behaviour.databinding.isFire = true;
        // 
        Transform bullet_trans = BYPoolManager.instance.Spawn(wp_Behaviour.prefab_Projecties.name);
        bullet_trans.position = wp_Behaviour.muzzleFlash.transform.position;
        Vector3 posAim= wp_Behaviour.aim_trans.position;
        posAim.y = bullet_trans.position.y;
        float x = wp_Behaviour.accuracy_current * 0.01f;
        float y= wp_Behaviour.accuracy_current * 0.01f;
        posAim.x += UnityEngine.Random.Range(-x, x);
        posAim.y += UnityEngine.Random.Range(-y, y);
        Vector3 dir = posAim - bullet_trans.position;
        bullet_trans.forward = dir;
        BulletPlayerData data = new BulletPlayerData();
        data.dir = dir.normalized;
        data.cf = wp_Behaviour.weaponData.cf;
        data.damage = wp_Behaviour.weaponData.cf.Damage;
        data.force = wp_Behaviour.force;
        bullet_trans.GetComponent<BulletPlayer>().Setup(data);
    }

    public void InitHandle(WeaponBehaviour weapon)
    {
        wp_Behaviour = (HandGun)weapon;
    }

    public void ReloadHandle()
    {
        wp_Behaviour.StartCoroutine("Reloading");
    }
}
