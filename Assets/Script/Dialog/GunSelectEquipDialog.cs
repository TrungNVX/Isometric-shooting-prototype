using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSelectEquipDialog : BaseDialog
{
    public Text gunname_lb_1;
    public Image iconGun_1;
    public Text gunname_lb_2;
    public Image iconGun_2;
    private GunSelectEquipDialogParam d_param;
    // Start is called before the first frame update
    public override void Setup(DialogParam dialogParam)
    {
        this.d_param = (GunSelectEquipDialogParam)dialogParam;

        PlayerInfo playerInfo = DataAPIController.instance.GetInfo();
        ConfigWeaponRecord cf_wp_1 = ConfigManager.instance.configWeapon.GetRecordByKeySearch(playerInfo.gun_slot_1);
        gunname_lb_1.text = cf_wp_1.Wp_name;
        iconGun_1.overrideSprite = SpriteLiblaryControl.instance.GetSprirteByName(cf_wp_1.Wp_name);

        ConfigWeaponRecord cf_wp_2 = ConfigManager.instance.configWeapon.GetRecordByKeySearch(playerInfo.gun_slot_2);
        gunname_lb_2.text = cf_wp_2.Wp_name;
        iconGun_2.overrideSprite = SpriteLiblaryControl.instance.GetSprirteByName(cf_wp_2.Wp_name);
    }
    public void OnSelect_Gun_1()
    {
        DataAPIController.instance.ChangeGunEquip(d_param.weapon_ID, 1, () =>
        {
            DialogManager.instance.HideDialog(this.dialogIndex);
        });
    }
    public void OnSelect_Gun_2()
    {
        DataAPIController.instance.ChangeGunEquip(d_param.weapon_ID, 2, () =>
        {
            DialogManager.instance.HideDialog(this.dialogIndex);
        });
    }
    public void OnClose()
    {
        DialogManager.instance.HideDialog(this.dialogIndex);
    }
}
