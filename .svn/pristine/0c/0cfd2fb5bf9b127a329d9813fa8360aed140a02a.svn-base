using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConfigShopRecord 
{
    // id shop_id name description type value cost 
    [SerializeField]
    private int id;
    [SerializeField]
    private string shop_id;
    public string ShopID
    {
        get
        {
            return shop_id;
        }
    }
    [SerializeField]
    private string name;
    public string Name
    {
        get
        {
            return name;
        }
    }
    [SerializeField]
    private string description;
    public string Description
    {
        get
        {
            return description;
        }
    }
    [SerializeField]
    private int type;
    public int Type_Shop
    {
        get
        {
            return type;
        }
    }
    [SerializeField]
    private int value;
    public int Value
    {
        get
        {
            return value;
        }
    }
    [SerializeField]
    private float cost;
    public float Cost
    {
        get
        {
            return cost;
        }
    }

}
public class ConfigShop : BYDataTable<ConfigShopRecord>
{
    public override ConfigCompare<ConfigShopRecord> DefineCompare()
    {
        ConfigCompare<ConfigShopRecord> configCompare = new ConfigCompare<ConfigShopRecord>("shop_id");
        return configCompare;
    }
}
