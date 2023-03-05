using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public Transform aim;
    public Transform parentGun;
    public List<string> wp_IDS;
    private List<WeaponBehaviour> wp_Behaviours = new List<WeaponBehaviour>();
    private WeaponBehaviour currentGun;
    private int indexGun = -1;
    public event Action<WeaponBehaviour> OnchangeGun;
    // Start is called before the first frame update
    void Start()
    {
        foreach (string id in wp_IDS)
        {
            ConfigWeaponRecord cf_Wp = ConfigManager.instance.configWeapon.GetRecordByKeySearch(id);
            GameObject go_wp = Instantiate(Resources.Load("Weapon/" + cf_Wp.Weapon_id, typeof(GameObject))) as GameObject;
            go_wp.transform.SetParent(parentGun, false);
            go_wp.SetActive(false);
            WeaponBehaviour wp_Behaviour = go_wp.GetComponent<WeaponBehaviour>();
            wp_Behaviour.Init(new WeaponData { cf = cf_Wp,aim_trans=aim });
            wp_Behaviours.Add(wp_Behaviour);
        }
        ChangeGun();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            ChangeGun();
        }
        currentGun?.OnFire(FirstControlInput.isFire);
    }
    public void ChangeGun()
    {
        indexGun++;
        if (indexGun >= wp_Behaviours.Count)
        {
            indexGun = 0;
        }
        currentGun?.SetActiveGun(false);
        currentGun = wp_Behaviours[indexGun];
        currentGun.SetActiveGun(true);
        OnchangeGun?.Invoke(currentGun);
    }
}
