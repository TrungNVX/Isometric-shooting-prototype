using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FPS_WeaponControl : MonoBehaviour
{

    public Transform parentWP;
    public List<FPS_WeaponBehaviour> weapons;
    private int indexGun=-1;
    private FPS_WeaponBehaviour current_WP;
    public static UnityEvent<FPS_WeaponBehaviour> OnChangeGun=new UnityEvent<FPS_WeaponBehaviour>();
    // Start is called before the first frame update
    void Start()
    {
        ChangeGun();
        FPS_InputManager.OnChangeGun += ChangeGun;
     
    }
    public void ChangeGun()
    {
        indexGun++;
        if (indexGun >= weapons.Count)
            indexGun = 0;
        if(current_WP!=null)
        {
            current_WP.OnHideGun(() =>
            {
                current_WP.gameObject.SetActive(false);
                current_WP = weapons[indexGun];
                current_WP.gameObject.SetActive(true);
                current_WP.OnShowGun();
                OnChangeGun?.Invoke(current_WP);
            });
        }
       else
        {
            current_WP = weapons[indexGun];
            current_WP.gameObject.SetActive(true);
            current_WP.OnShowGun();
            OnChangeGun?.Invoke(current_WP);
        }
      
    }
    // Update is called once per frame
    private void OnDisable()
    {
        OnChangeGun.RemoveAllListeners();
    }
}
