using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapView : BaseView
{

    public InputField input_Mission;
    public Text goldLB;
    public Text guninfo;
    public Text inventtory_lb;
    // Start is called before the first frame update
    public override void Setup(ViewParam viewParam)
    {
        goldLB.text = DataAPIController.instance.GetGold().ToString();
        ItemData gunData= DataAPIController.instance.GetGunData("W_001");
        ConfigWeaponRecord cf_gun = ConfigManager.instance.configWeapon.GetRecordByKeySearch(gunData.id);

        guninfo.text = cf_gun.Wp_name + " level " + gunData.level.ToString();
        DataTrigger.RegisterValueChange(DataPath.GOLD, DataGoldchange);
        DataTrigger.RegisterValueChange(DataPath.INVENTORY, DataInventorychange);
        DataTrigger.RegisterValueChange(DataPath.DIC_GUN+"/W_001", DataGunchange);
    }
    private void DataGoldchange(object dataChange)
    {
        goldLB.text =((int)(dataChange)).ToString();
    }
    private void DataGunchange(object dataChange)
    {
        ItemData gunData =(ItemData)dataChange;
        ConfigWeaponRecord cf_gun = ConfigManager.instance.configWeapon.GetRecordByKeySearch(gunData.id);

        guninfo.text = cf_gun.Wp_name + " level " + gunData.level.ToString();
    }
    public override void OnHideView()
    {
        DataTrigger.UnRegisterValueChange(DataPath.GOLD, DataGoldchange);
        DataTrigger.UnRegisterValueChange(DataPath.INVENTORY, DataInventorychange);
        DataTrigger.RegisterValueChange(DataPath.DIC_GUN + "/W_001", DataGunchange);
    }
    private void DataInventorychange(object dataChange)
    {
        PlayerInventory inventory = (PlayerInventory)(dataChange);
        string s = JsonConvert.SerializeObject(inventory);
        inventtory_lb.text = s;
    }    
    public void OnPlay()
    {
        GameManager.instance.missionRecord = ConfigManager.instance.configMission.GetRecordByKeySearch(input_Mission.text);
        LoadSceneManager.instance.LoadScene(GameManager.instance.missionRecord.Map, () =>
        {

            GameObject missionControl_ob = Instantiate(Resources.Load("Mission/" + GameManager.instance.missionRecord.Mission_Type.ToString(),
                typeof(GameObject))) as GameObject;
            
            ViewManager.instance.SwitchView(ViewIndex.EmptyView);
        });
    }
    public void AddGold()
    {
        DataAPIController.instance.AddGold(10);
    }
    
}
