using System;
using UnityEngine;

public class WeaponData
{
    public ConfigWeaponRecord cf;
    public Transform aim_trans;
}
public class WeaponBehaviour : MonoBehaviour
{
    public IWeaponHandle iWP_handle;
    public AnimatorOverrideController overrideController;
    // rate of fire
    public float rof;
    public int clip_size;
    public float accuracy_min;
    public float accuracy_max;
    public float accuracy_current;
    public float accuracy_recover;
    public float accuracy_drop;
    public float reloadTime;
    public int damage;
    public float force=300;

    public int numberBullet;
    private float timeFire;
    public bool isFire;
    public bool isReloading;
    public TPS_Iso_Databinding databinding;
    public WeaponData weaponData;
    public event Action<int, int> OnAmoChange;
    public Transform prefab_Projecties;
    public Transform prefab_imapact;
    public MuzzleFlash muzzleFlash;
    public Transform aim_trans;

    public void Init(WeaponData weaponData)
    {
        this.weaponData = weaponData;
        this.aim_trans = weaponData.aim_trans;
        databinding = gameObject.GetComponentInParent<TPS_Iso_Databinding>();
        rof = weaponData.cf.Rof;
       // accuracy = weaponData.cf.Accuracy;
        reloadTime = weaponData.cf.ReloadTime;
        clip_size = weaponData.cf.Clip_size;
        numberBullet = clip_size;
        damage = weaponData.cf.Damage;
        isReloading = false;
        // create Pool 
        

        InitWeapon();
    }
    // Start is called before the first frame update
    protected virtual void InitWeapon()
    {

    }
    public void OnFire(bool isFire)
    {
        this.isFire = isFire;
    }
    private void Update()
    {
        timeFire += Time.deltaTime;
        if (isFire)
        {
            if (timeFire >= rof && numberBullet > 0 && !isReloading)
            {
                timeFire = 0;
                numberBullet--;
                OnAmoChange?.Invoke(numberBullet, clip_size);
                iWP_handle.FireHandle();
                muzzleFlash.FireHandle();
                accuracy_current += accuracy_drop;
                
                if (numberBullet <= 0)
                {
                    Invoke("OnReload", rof);
                }

            }
        }
        accuracy_current = Mathf.Lerp(accuracy_current, accuracy_min, Time.deltaTime * accuracy_recover);
        accuracy_current = Mathf.Clamp(accuracy_current, accuracy_min, accuracy_max);

    }
    public void SetActiveGun(bool isActive)
    {
        //  


        if (isActive)
        {
            gameObject.SetActive(true);
            databinding.Empty = true;
            databinding.ChangeAnimatorControler(overrideController);
            if (isReloading && numberBullet <= 0)
                iWP_handle.ReloadHandle();
        }
        else
        {
            StopAllCoroutines();
            gameObject.SetActive(false);
        }

    }

    private void OnReload()
    {
        isReloading = true;
        isFire = false;
        if (gameObject.activeSelf)
            iWP_handle.ReloadHandle();

    }
    protected void EndReload()
    {
        isReloading = false;
        numberBullet = clip_size;
        OnAmoChange?.Invoke(numberBullet, clip_size);
    }

}
