using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponViewItem : MonoBehaviour
{
    public GameObject lockObject;
    public Image iconGun;
    public Text level_lb;
    public Text equip_lb;
    public Text nameGun_lb;
    public Image gunType;
    private ConfigWeaponRecord cfWeapon;
    // Start is called before the first frame update
    void Start()
    {
        DataTrigger.RegisterValueChange(DataPath.INFO, OnInfoChange);

    }
    
    private void SetGunStats(object data = null)
    {
        ItemData itemData = DataAPIController.instance.GetGunData(cfWeapon.Weapon_id);
        if (itemData == null)
        {
            lockObject.SetActive(true);
            level_lb.text = string.Empty;
        }
        else
        {
            lockObject.SetActive(false);
            level_lb.text = "Level " + itemData.level.ToString();
        }
    }

    private void OnInfoChange(object dataChange)
    {
        PlayerInfo info = (PlayerInfo)dataChange;
        SetEquip(info);
    }
    private void SetEquip(PlayerInfo info)
    {
        if (cfWeapon.Weapon_id == info.gun_slot_1)
        {
            equip_lb.text = GameConfig.Gun_Slot_1;
        }
        else if (cfWeapon.Weapon_id == info.gun_slot_2)
        {
            equip_lb.text = GameConfig.Gun_Slot_2;
        }
        else
        {
            equip_lb.text = string.Empty;
        }
    }
    public void OnSetup(ConfigWeaponRecord cfWeapon, PlayerInfo info)
    {
        this.cfWeapon = cfWeapon;
        SetGunStats();
        iconGun.overrideSprite = SpriteLiblaryControl.instance.GetSprirteByName(cfWeapon.Wp_name);
        nameGun_lb.text = cfWeapon.Wp_name;
        gunType.overrideSprite= SpriteLiblaryControl.instance.GetSprirteByName(cfWeapon.Gun_Type.ToString());
        SetEquip(info);
        DataTrigger.RegisterValueChange(DataPath.DIC_GUN , SetGunStats);

    }
    private void OnDisable()
    {
        DataTrigger.UnRegisterValueChange(DataPath.DIC_GUN , SetGunStats);

    }
    public void OnShowInfo()
    {
        GunInfoDialogParam param = new GunInfoDialogParam {cf=cfWeapon };
        DialogManager.instance.ShowDialog(DialogIndex.GunInfoDialog,param);
    }
}
