using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public class DataEventTrigger:UnityEvent<object>
{

}
public static class DataTrigger
{
    private static Dictionary<string, DataEventTrigger> dicOnValueChange = new Dictionary<string, DataEventTrigger>();
    public static void RegisterValueChange(string path, UnityAction<object> delegateDataChange)
    {
        if(dicOnValueChange.ContainsKey(path))
        {
            dicOnValueChange[path].AddListener(delegateDataChange);
        }
        else
        {
            dicOnValueChange.Add(path, new DataEventTrigger());
            dicOnValueChange[path].AddListener(delegateDataChange);
        }
    }
    public static void UnRegisterValueChange(string path,UnityAction<object> delegateDataChange)
    {
        if(dicOnValueChange.ContainsKey(path))
        {
            dicOnValueChange[path].RemoveListener(delegateDataChange);
        }
    }
    //extention method
    public static void TriggerEventData(this object data, string path)
    {
        if(dicOnValueChange.ContainsKey(path))
        {
            dicOnValueChange[path].Invoke(data);
        }
    }
}
public class DataLocalModel : MonoBehaviour
{
    private UserData userData;
    // CRUD: create,read, update, delete
    public void CreateData(Action callBack)
    {
        userData = LoadData();
        if(userData!=null)
        {
            callBack();
        }
        else
        {
            // create 
            userData = new UserData();
            PlayerInfo info = new PlayerInfo();
            info.name = "Hero";
            info.level = 1;
            info.exp = 0;
            info.gun_slot_1 = "W_001";
            info.gun_slot_2 = "W_002";
            userData.info = info;
            PlayerInventory inventory = new PlayerInventory();
            inventory.gold = 100;
            ItemData gun = new ItemData();
            gun.id= "W_001";
            gun.level = 1;
            Dictionary<string, ItemData> dic_gun = new Dictionary<string, ItemData>();
            dic_gun["W_001"] = gun;
            ItemData gun_2 = new ItemData();
            gun_2.id = "W_002";
            gun_2.level = 1;
            dic_gun["W_002"] = gun_2;
            inventory.weapons = dic_gun;
            userData.inventory = inventory;
            SaveData();
            callBack();
           
        }
    }
    private List<string> GetPath(string path)
    {
        string[] s = path.Split('/');
        List<string> ls = new List<string>();
        ls.AddRange(s);
        return ls;
    }
    public T Read<T>(string path)
    {
        object data = null;
        ReadDataByPath(GetPath(path), userData,out data);
        return (T)data;
    }
    public T ReadKey<T>(string path,string key)
    {
        object data = null;
        ReadDataByPath(GetPath(path), userData, out data);
        Dictionary<string, T> dic_Data = (Dictionary<string, T>)data;
        T outData;
        dic_Data.TryGetValue(key, out outData);
        return outData;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="paths"> path of data</param>
    /// <param name="data"> root data</param>
    /// <param name="dataOut"> data read</param>
    private void ReadDataByPath(List<string> paths, object data, out object dataOut)
    {
        string p = paths[0];
        Type t = data.GetType();
        FieldInfo field = t.GetField(p);
        if(paths.Count==1)
        {
            dataOut = field.GetValue(data);
        }
        else
        {
            paths.RemoveAt(0);
            ReadDataByPath(paths,field.GetValue(data), out dataOut);
        }
    }
    public void UpdateData(string path, object dataNew,Action callback)
    {
        List<object> ls_datachange = new List<object>();
        List<string> paths = GetPath(path);
        UpdateDataByPath(paths, userData, dataNew,ref ls_datachange, callback);
        SaveData();
        string e_path = string.Empty;
        paths.Clear();
        paths = GetPath(path);
        for (int i=0;i<paths.Count;i++)
        {
            if(i==0)
            {
                e_path = paths[0];
            }
            else
            {
                e_path = e_path + "/" + paths[i];
            }
            ls_datachange[i].TriggerEventData(e_path);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="paths"> path of data</param>
    /// <param name="data"> root data</param>
    /// <param name="datanew"> data read</param>
    private void UpdateDataByPath(List<string> paths, object data,  object datanew,ref List<object> datas_change,Action callback=null)
    {
        string p = paths[0];
        Type t = data.GetType();
        FieldInfo field = t.GetField(p);
        if (paths.Count == 1)
        {
            datas_change.Add(datanew);
            field.SetValue(data,datanew);
            callback?.Invoke();
        }
        else
        {
            object dataAdd = field.GetValue(data);
            datas_change.Add(dataAdd);
            paths.RemoveAt(0);
            UpdateDataByPath(paths, dataAdd,  datanew,ref datas_change,callback);
        }
    }
    public void UpdateDataKey<T>(string path, string key, T dataNew, Action callback)
    {
        List<object> ls_datachange = new List<object>();
        List<string> paths = GetPath(path);
        UpdateDataKeyByPath<T>(GetPath(path), key, userData, dataNew,ref ls_datachange, callback);
        SaveData();
        string e_path = string.Empty;
        paths.Clear();
        paths = GetPath(path);
        for (int i = 0; i < paths.Count; i++)
        {
            if (i == 0)
            {
                e_path = paths[0];
            }
            else
            {
                e_path = e_path + "/" + paths[i];
            }
            ls_datachange[i].TriggerEventData(e_path);
        }
        dataNew.TriggerEventData(e_path+"/"+key);
    }
    private void UpdateDataKeyByPath<T>(List<string> paths, string key, object data, T datanew, ref List<object> datas_change, Action callback = null)
    {
        string p = paths[0];
        Type t = data.GetType();
        FieldInfo field = t.GetField(p);
       
        if (paths.Count == 1)
        {
            object dic = field.GetValue(data);
            Dictionary<string, T> dic_new = (Dictionary<string, T>)dic;
            dic_new[key] = datanew;
            datas_change.Add(dic_new);
            field.SetValue(data, dic_new);
            callback?.Invoke();
        }
        else
        {
            object dataAdd = field.GetValue(data);
            datas_change.Add(dataAdd);
            paths.RemoveAt(0);
            UpdateDataKeyByPath(paths,key, dataAdd, datanew,ref datas_change, callback);
        }
    }
    private UserData LoadData()
    {
       
        if(PlayerPrefs.HasKey("DATA"))
        {
            string dataJson = PlayerPrefs.GetString("DATA");
            return JsonConvert.DeserializeObject<UserData>(dataJson);
        }
        else
        {
            return null;
        }
    }
    private void SaveData()
    {
        string dataJson = JsonConvert.SerializeObject(userData);
        PlayerPrefs.SetString("DATA", dataJson);
    }
}
