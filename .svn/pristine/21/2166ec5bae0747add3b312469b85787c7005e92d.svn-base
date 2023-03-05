using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_WeaponBehaviour : MonoBehaviour
{
    public Vector3 localPos;
    public Animator animController;
    private Action callBackHide;
    public float fov = 45;
    public float fov_zoom = 25;
    public int numBullet;
    public bool isFire;
    public bool isSemiAuto;
    private bool semiAutoCheck;
    public float rof;
    private float timeFire;
    public float accuracy;
    public float accuracy_drop;
    public float accuracy_recover;
    public float rateAccuracy=0.0005f;
   
    public float min_a;
    public float max_a;
    public float recoil;
    public int clipsize;
    private bool isReloadPrgress;
    public float timeRerloadLeft;
    public float timeReloadOutOfAmo;
    public LayerMask mask;
    private Camera cam_;
    public FPS_MuzzleFlash muzzleFlash;
    
    // Start is called before the first frame update
    void Start()
    {
        cam_ = Camera.main;
        numBullet = clipsize;
        isReloadPrgress = false;
    }

    private void FPS_InputManager_OnGrenade(bool obj)
    {


    }

    private void FPS_InputManager_OnFire(bool obj)
    {
        isFire = obj;
        semiAutoCheck = !isFire;
    }

    // Update is called once per frame
    void Update()
    {
        timeFire += Time.deltaTime;
        if (isReloadPrgress)
        {

        }
        else if (numBullet <= 0)
        {

        }
        else
        {
            if (isSemiAuto)
            {
                if (isFire && !semiAutoCheck)
                {
                    if (timeFire >= rof)
                    {
                        semiAutoCheck = true;
                        FireHandle();
                    }
                }
            }
            else
            {
                if (isFire)
                {
                    if (timeFire >= rof)
                    {
                        FireHandle();
                    }
                }
            }
        }
        accuracy = Mathf.Lerp(accuracy, min_a, Time.deltaTime * accuracy_recover);
        accuracy = Mathf.Clamp(accuracy, min_a, max_a);
    }
    public float GetRecoilCamera()
    {
        float rate = accuracy - min_a;
        return rate * recoil;
    }
    private void FireHandle()
    {
        muzzleFlash.FireHandle();
        accuracy += accuracy_drop;
        float accuracy_ = accuracy * rateAccuracy;
        float x = 0.5f + UnityEngine.Random.Range(-accuracy_, accuracy_);
        float y = 0.5f + UnityEngine.Random.Range(-accuracy_, accuracy_);
        Ray ray = cam_.ViewportPointToRay(new Vector3(x, y, 0));
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, mask))
        {
            Transform impact = null; ;
            if (hitInfo.collider.CompareTag("Flesh"))
            {
                // daamage to enemy 
                impact = BYPoolManager.instance.Spawn("ImpactBlood");
            }
            else if (hitInfo.collider.CompareTag("Metal"))
            {
                impact = BYPoolManager.instance.Spawn("ImpactMetal");
            }
            else if (hitInfo.collider.CompareTag("Concrete"))
            {
                impact = BYPoolManager.instance.Spawn("ImpactStone");
            }
            impact.position = hitInfo.point;
            impact.forward = hitInfo.normal;
        }

        if (FPS_InputManager.isZoom)
        {
            animController.Play("Fire_Aim", 0, 0);

        }
        else
        {
            animController.Play("Fire", 0, 0);

        }
        timeFire = 0;
        numBullet--;
        if (numBullet <= 0)
        {
            ReloadWeapon();
        }
    }
    public void OnHideGun(Action callBack)
    {
        FPS_InputManager.OnFire -= FPS_InputManager_OnFire;
        FPS_InputManager.OnGrenade -= FPS_InputManager_OnGrenade;
        FPS_InputManager.OnReloadGun -= ReloadWeapon;
        callBackHide = callBack;
        animController.Play("Hide", 0, 0);
    }
    public void OnHideAnimEnd()
    {
        callBackHide.Invoke();
    }
    public void OnShowGun()
    {
        FPS_InputManager.OnFire += FPS_InputManager_OnFire;
        FPS_InputManager.OnGrenade += FPS_InputManager_OnGrenade;
        FPS_InputManager.OnReloadGun += ReloadWeapon;
        if (FPS_InputManager.isZoom)
        {
            animController.Play("Aim", 0, 0);

        }
        else
        {
            animController.Play("Show", 0, 0);

        }
    }
    public void ReloadWeapon()
    {
        if (numBullet >= clipsize)
            return;
        FPS_InputManager_OnFire(false);
        FPS_InputManager.isZoom = false;
        isReloadPrgress = true;
        StopCoroutine("ReloadProgress");
        if (numBullet > 0)
        {
            animController.Play("Reload", 0, 0);
            StartCoroutine("ReloadProgress", timeRerloadLeft);
        }
        else
        {

            animController.Play("Reload_out_of_ammo", 0, 0);
            StartCoroutine("ReloadProgress", timeReloadOutOfAmo);
        }
    }
    IEnumerator ReloadProgress(float timeProgress)
    {
        yield return new WaitForSeconds(timeProgress);
        isReloadPrgress = false;
        numBullet = clipsize;
    }
    public void EventReloadEnd()
    {

    }
}
