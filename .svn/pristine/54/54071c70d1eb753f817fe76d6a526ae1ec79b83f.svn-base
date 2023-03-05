using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeView : BaseView
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnShowWeaponView()
    {
        CardsViewParam viewParam = new CardsViewParam { gunName = "Ak 47" };

        ViewManager.instance.SwitchView(ViewIndex.MapView, viewParam, () =>
        {
            Debug.LogError(" Load WeaponView Done");
        });
    }
    public void OnShopView()
    {
        ViewManager.instance.SwitchView(ViewIndex.ShopView);
    }
    public void OnWeaponView()
    {
        ViewManager.instance.SwitchView(ViewIndex.WeaponView);
    }
}
