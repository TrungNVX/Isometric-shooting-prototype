using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopViewItem : MonoBehaviour
{
    public string idShop;
    private ConfigShopRecord cf_Shop;
    public Text namepack;
    public Text val_lb;
    public Text cost_lb;

    // Start is called before the first frame update
    void Start()
    {
        cf_Shop = ConfigManager.instance.configShop.GetRecordByKeySearch(idShop);
        namepack.text = cf_Shop.Name;
        val_lb.text = cf_Shop.Value.ToString();
        cost_lb.text = cf_Shop.Cost.ToString() + "$";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnBuy()
    {
        if (cf_Shop.Type_Shop == 1)
            DataAPIController.instance.AddGold(cf_Shop.Value);
        else if (cf_Shop.Type_Shop == 2)
            DataAPIController.instance.AddGem(cf_Shop.Value);
    }
}
