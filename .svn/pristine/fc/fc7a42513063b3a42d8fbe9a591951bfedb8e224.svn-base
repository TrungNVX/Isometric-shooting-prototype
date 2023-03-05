using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MissionCollect : MissionControl
{
    private int total_item;
    private int count;
    public event Action<int, int> OnCollectItem;
    private MissionCollectItemControl missionCollectItemControl;
    // Start is called before the first frame update
    public override void OnInit()
    {
        base.OnInit();
        count = 0;
        GameObject go_item_control = Instantiate(Resources.Load("Mission/MissionCollect/" + configMission.Mission_ID, typeof(GameObject))) as GameObject;
        missionCollectItemControl = go_item_control.GetComponent<MissionCollectItemControl>();
        foreach (MissionCollectItem e in missionCollectItemControl.items)
        {
            e.missionCollect = this;
            total_item++;
        }
        missionCollectItemControl.Setup();
    }
    public void CollectItem(MissionCollectItem item)
    {
        count++;
        missionCollectItemControl.UpdateNumber(count);
        if (count>=total_item)
        {
            DialogManager.instance.ShowDialog(DialogIndex.VictoryDialog);
        }
    }
}
