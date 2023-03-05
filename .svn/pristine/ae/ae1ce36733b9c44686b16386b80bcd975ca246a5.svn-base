using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : BYSingleton<ConfigManager>
{
    public ConfigEnemy configEnemy;
    public ConfigWeapon configWeapon;
    public ConfigWave configWave;
    public ConfigMission configMission;
    public ConfigShop configShop;
    public void InitConfig(Action callback)
    {
        StartCoroutine(Init(callback));
    }
    // Start is called before the first frame update
    IEnumerator Init(Action callback)
    {
        configEnemy = Resources.Load("Datatable/ConfigEnemy", typeof(ScriptableObject)) as ConfigEnemy;
        yield return new WaitUntil(() => configEnemy != null);

        configWeapon = Resources.Load("Datatable/ConfigWeapon", typeof(ScriptableObject)) as ConfigWeapon;
        yield return new WaitUntil(() => configWeapon != null);

        configWave = Resources.Load("Datatable/ConfigWave", typeof(ScriptableObject)) as ConfigWave;
        yield return new WaitUntil(() => configWave != null);

        configMission = Resources.Load("Datatable/ConfigMission", typeof(ScriptableObject)) as ConfigMission;
        yield return new WaitUntil(() => configMission != null);

        configShop = Resources.Load("Datatable/ConfigShop", typeof(ScriptableObject)) as ConfigShop;
        yield return new WaitUntil(() => configShop != null);

        callback?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
