using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataAPIController : BYSingleton<DataAPIController>
{
    [SerializeField]
    private DataLocalModel dataModel;
    // Start is called before the first frame update
    public void InitData(Action callBack)
    {
        dataModel.CreateData(callBack);

    }
    public PlayerInfo GetInfo()
    {
        return dataModel.Read<PlayerInfo>(DataPath.INFO);
    }
    
    public int GetGold()
    {
        return dataModel.Read<int>(DataPath.GOLD);
    }
    public void AddGold(int num)
    {
        int gold = dataModel.Read<int>(DataPath.GOLD);
        gold += num;
        dataModel.UpdateData(DataPath.GOLD, gold, null);
    }
    public int GetGem()
    {
        return dataModel.Read<int>(DataPath.GEM);
    }
    public void AddGem(int num)
    {
        int gold = dataModel.Read<int>(DataPath.GEM);
        gold += num;
        dataModel.UpdateData(DataPath.GEM, gold, null);
    }
    public ItemData GetGunData(string id_gun)
    {
        return dataModel.ReadKey<ItemData>(DataPath.DIC_GUN, id_gun);
    }
   
   public void ChangeGunEquip(string wp_id, int slot,Action callback)
    {
        PlayerInfo info = GetInfo();
        if(slot==1)
        {
            info.gun_slot_1 = wp_id;
        }
        else if (slot == 2)
        {
            info.gun_slot_2 = wp_id;
        }

        dataModel.UpdateData(DataPath.INFO, info,callback);
    }
    public void BuyGun(ConfigWeaponRecord cf,Action<bool> callback)
    {
        int gem = GetGem();
        if(cf.Price>gem)
        {
            callback(false);
        }
        else
        {
            AddGem(-cf.Price);
            //
            ItemData gundata = new ItemData();
            gundata.id = cf.Weapon_id;
            gundata.level = 1;
            dataModel.UpdateDataKey<ItemData>(DataPath.DIC_GUN, cf.Weapon_id, gundata, () =>
            {
                callback(true);
            });

        }
    }
    public void UpgradeGun(ConfigWeaponRecord cf, Action<bool> callback)
    {
        ItemData gundata = dataModel.ReadKey<ItemData>(DataPath.DIC_GUN, cf.Weapon_id);
        int gold = GetGold();
        float cost_up = cf.Cost;
        cost_up = cost_up.CalculatorStatUpgrade(gundata.level, cf.Factor);
        int cost = (int)cost_up;
        if (cost > gold)
        {
            callback(false);
        }
        else
        {
            AddGold(-cost);
            //
            gundata.level++;

            dataModel.UpdateDataKey<ItemData>(DataPath.DIC_GUN, cf.Weapon_id, gundata, () =>
            {
                callback(true);
            });

        }
    }
}
