using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConfigWaveRecord
{
    //id	wave_id	enemies_id	number
    [SerializeField]
    private int id;
    [SerializeField]
    private string wave_id;
    public string Wave_ID
    {
        get
        {
            return wave_id;
        }
    }
    [SerializeField]
    private string enemies_id;
    public List<string> Enemies_id
    {
        get
        {
            string[] s = enemies_id.Split(';');
            List<string> ls = new List<string>();
            ls.AddRange(s);
            return ls;
        }
    }
    [SerializeField]
    private int number;
    public int Number
    {
        get
        {
            return number;
        }
    }

}
public class ConfigWave : BYDataTable<ConfigWaveRecord>
{
    public override ConfigCompare<ConfigWaveRecord> DefineCompare()
    {
        ConfigCompare<ConfigWaveRecord> configCompare = new ConfigCompare<ConfigWaveRecord>("wave_id");
        return configCompare;
    }


}
