using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunInfoDialog : BaseDialog
{
    public Text gunname_lb;
    public Text gunSlot_lb;
    public Image iconGun;
    public Button btn_Buy;
    public Button btn_equip;
    public Button btn_upgrade;
    public Text lev_lb;
    private bool isEquip;
    public Text gunprice_lb;
    public Text gunUpgradeCost_lb;
    private GunInfoDialogParam d_param;
    // gun stat
    public Image damage_pg;
    public Text damage_lb;
    public Image clip_pg;
    public Text clip_lb;
    public Image rof_pg;
    public Text rof_lb;
    public Image reload_pg;
    public Text reload_lb;
    public Image accuracy_pg;
    public Text accuracy_lb;
    // Start is called before the first frame update
    public override void Setup(DialogParam dialogParam)
    {

        d_param = (GunInfoDialogParam)dialogParam;
      
        gunname_lb.text = d_param.cf.Wp_name;
        iconGun.overrideSprite = SpriteLiblaryControl.instance.GetSprirteByName(d_param.cf.Wp_name);
        
        // gun info;
        SetgunInfo();
    }
    public override void OnShowDialog()
    {
        base.OnShowDialog();
        DataTrigger.RegisterValueChange(DataPath.INFO, SetgunInfo);
        DataTrigger.RegisterValueChange(DataPath.DIC_GUN+"/"+d_param.cf.Weapon_id, SetgunInfo);
    }
    public override void OnHideDialog()
    {
        base.OnHideDialog();
        DataTrigger.UnRegisterValueChange(DataPath.INFO, SetgunInfo);
        DataTrigger.UnRegisterValueChange(DataPath.DIC_GUN + "/" + d_param.cf.Weapon_id, SetgunInfo);
    }
    private void SetgunInfo(object data=null)
    {
        PlayerInfo playerInfo = DataAPIController.instance.GetInfo();
        if (d_param.cf.Weapon_id.CompareTo(playerInfo.gun_slot_1) == 0)
        {
            gunSlot_lb.text = GameConfig.Gun_Slot_1;
            isEquip = true;
        }
        else if (d_param.cf.Weapon_id.CompareTo(playerInfo.gun_slot_2) == 0)
        {
            gunSlot_lb.text = GameConfig.Gun_Slot_2;
            isEquip = true;
        }
        else
        {
            gunSlot_lb.text = string.Empty;
            isEquip = false;
        }
        ItemData gundata = DataAPIController.instance.GetGunData(d_param.cf.Weapon_id);
        btn_Buy.gameObject.SetActive(gundata==null);
        btn_upgrade.gameObject.SetActive(gundata != null);
        btn_equip.gameObject.SetActive(gundata != null);

        int gold = DataAPIController.instance.GetGold();
        int gem = DataAPIController.instance.GetGem();
        gunprice_lb.text = d_param.cf.Price.ToString();
        if (gundata==null)
        {
            lev_lb.text = "Level 1";
            btn_Buy.interactable = d_param.cf.Price <= gem;
        }
        else
        {
            if(gundata.level==10)
            {
                lev_lb.text = "Max Level";
                btn_upgrade.interactable = false;
            }
            else
            {
                lev_lb.text = "Level " + gundata.level.ToString();
                float cost_up = d_param.cf.Cost;
                cost_up = cost_up.CalculatorStatUpgrade(gundata.level, d_param.cf.Factor);
                gunUpgradeCost_lb.text = cost_up.ToString();
                btn_upgrade.interactable = cost_up <= gold;
                btn_equip.gameObject.SetActive(!isEquip);
            }
           
        }
        SetStats(gundata);
    }
    private void SetStats(ItemData gundata)
    {
        int level = 1;
        if(gundata!=null)
        {
            level = gundata.level;
        }
        //damage
        int damage = (int)((float)d_param.cf.Damage).CalculatorStatUpgrade(level, d_param.cf.Factor);
        damage_lb.text = damage.ToString();
        int damage_max= (int)((float)d_param.cf.Damage).CalculatorStatUpgrade(10, d_param.cf.Factor);
        damage_pg.fillAmount = (float)damage / (float)damage_max;
        //clip
        int clip = (int)((float)d_param.cf.Clip_size).CalculatorStatUpgrade(level, d_param.cf.Factor);
        clip_lb.text = clip.ToString();
        int clip_max = (int)((float)d_param.cf.Clip_size).CalculatorStatUpgrade(10, d_param.cf.Factor);
        clip_pg.fillAmount = (float)clip / (float)clip_max;
        //rof
        float rof = (float)((float)d_param.cf.Rof).CalculatorStatUpgrade(level, d_param.cf.Factor);
        rof_lb.text = rof.ToString();
        float rof_max = (float)((float)d_param.cf.Rof).CalculatorStatUpgrade(10, d_param.cf.Factor);
        rof_pg.fillAmount = (float)rof / (float)rof_max;
        //reload
        float reload = (float)((float)d_param.cf.ReloadTime).CalculatorStatUpgrade(level, d_param.cf.Factor);
        reload_lb.text = reload.ToString();
        float reload_max = (float)((float)d_param.cf.ReloadTime).CalculatorStatUpgrade(10, d_param.cf.Factor);
        reload_pg.fillAmount = (float)reload / (float)reload_max;
        //acuracy
        float accuracy = (float)((float)d_param.cf.Accuracy).CalculatorStatUpgrade(level, d_param.cf.Factor);
        accuracy_lb.text = accuracy.ToString();
        float accuracy_max = (float)((float)d_param.cf.Accuracy).CalculatorStatUpgrade(10, d_param.cf.Factor);
        accuracy_pg.fillAmount = (float)accuracy / (float)accuracy_max;
    }
    public void OnClose()
    {
        // DialogManager.instance.HideDialog(dialogIndex);
        DialogManager.instance.HideDialog(DialogIndex.GunInfoDialog);
    }
    public void OnBuy()
    {
        DataAPIController.instance.BuyGun(d_param.cf, (res) =>
        {
            //
        });
    }
    public void OnUpgrade()
    {
        DataAPIController.instance.UpgradeGun(d_param.cf, (res) =>
        {
            //
        });
    }
    public void OnEquip()
    {
        GunSelectEquipDialogParam param = new GunSelectEquipDialogParam { weapon_ID = d_param.cf.Weapon_id };

        DialogManager.instance.ShowDialog(DialogIndex.GunSelectEquipDialog, param);
    }
}
