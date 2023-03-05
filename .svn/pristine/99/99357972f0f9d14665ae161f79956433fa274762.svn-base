using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConfigMissionRecord
{
    //id	mission_id	mission_name	description	waves	reward
    [SerializeField]
    private int id;
    [SerializeField]
    private string mission_id;
    public string Mission_ID
    {
        get
        {
            return mission_id;
        }
    }
    [SerializeField]
    private string mission_name;
    public string Mission_name
    {
        get
        {
            return mission_name;
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
    private MissionType missionType;
    public MissionType Mission_Type
    {
        get
        {
            return missionType;
        }
    }
    [SerializeField]
    private string waves;
    public List<WaveInit> Waves
    {
        get
        {
            List<WaveInit> ls = new List<WaveInit>();
            string[] s = waves.Split(';');
            foreach(string e_s in s)
            {
                string[] s_element = e_s.Split(':');
                WaveInit waveInit = new WaveInit();
                waveInit.wave_ID = s_element[0];
                waveInit.delay = int.Parse(s_element[1]);
                ls.Add(waveInit);
            }
            return ls;
        }
    }
    [SerializeField]
    private string reward;
    public string Reward
    {
        get
        {
            return reward;
        }
    }
    [SerializeField]
    private string map;
    public string Map
    {
        get
        {
            return map;
        }
    }
}
public class ConfigMission : BYDataTable<ConfigMissionRecord>
{
    public override ConfigCompare<ConfigMissionRecord> DefineCompare()
    {
        ConfigCompare<ConfigMissionRecord> configCompare = new ConfigCompare<ConfigMissionRecord>("mission_id");
        return configCompare;
    }


}
public class WaveInit
{
    public string wave_ID;
    public int delay;
}
public enum MissionType
{
    MissionDefend = 1,
    MissionCollect=2
}