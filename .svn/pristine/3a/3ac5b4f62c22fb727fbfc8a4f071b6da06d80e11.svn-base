using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public GameObject resourceUI;
    public Text gem_lb;
    public Text gold_lb;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.sceneUnloaded += SceneManager_sceneUnloaded;
        DataTrigger.RegisterValueChange(DataPath.INVENTORY, SetUpresource);
    }

    private void SceneManager_sceneUnloaded(Scene arg0)
    {
        if(arg0.buildIndex==1)
        {
            resourceUI.SetActive(false);
        }
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.buildIndex == 1)
        {
            resourceUI.SetActive(true);
            SetUpresource(null);
        }
    }
    private void SetUpresource(object dataChange)
    {
        int gem = DataAPIController.instance.GetGem();
        gem_lb.text = gem.ToString();
        int gold = DataAPIController.instance.GetGold();
        gold_lb.text = gold.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnShopView()
    {
        ViewManager.instance.SwitchView(ViewIndex.ShopView);
    }
}
