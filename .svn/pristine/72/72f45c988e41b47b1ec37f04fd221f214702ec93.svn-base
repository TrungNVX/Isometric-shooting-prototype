using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponView : BaseView
{
    public Transform parent_item;
    public WeaponViewItem prefab_item;
    private List<WeaponViewItem> ls_items = new List<WeaponViewItem>();
    public List<Button> ls_Button;
    private PlayerInfo info;
    // Start is called before the first frame update
    public override void Setup(ViewParam viewParam)
    {
        info = DataAPIController.instance.GetInfo();
        if (ls_items.Count == 0)
        {
            foreach (ConfigWeaponRecord cf in ConfigManager.instance.configWeapon.GetWeaponSort())
            {
                WeaponViewItem item = Instantiate(prefab_item);
                item.transform.SetParent(parent_item, false);
                ls_items.Add(item);

            }
        }

        OnSelectWP(0);

    }
    public void OnBack()
    {
        ViewManager.instance.SwitchView(ViewIndex.HomeView);
    }
    public void OnSelectWP(int index)
    {
        for (int i = 0; i < ls_Button.Count; i++)
        {

            ls_Button[i].interactable = i != index;
        }
        foreach (WeaponViewItem e in ls_items)
        {
            e.gameObject.SetActive(false);
        }
        int count = 0;
        if (index > 0)
        {

            foreach (ConfigWeaponRecord cf in ConfigManager.instance.configWeapon.GetWeaponByType((GunType)index))
            {
                ls_items[count].gameObject.SetActive(true);
                ls_items[count].OnSetup(cf, info);
                count++;
            }
        }
        else
        {
            foreach (ConfigWeaponRecord cf in ConfigManager.instance.configWeapon.GetWeaponSort())
            {

                ls_items[count].gameObject.SetActive(true);
                ls_items[count].OnSetup(cf, info);
                count++;
            }
        }

    }
}
