using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootLoader : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        DontDestroyOnLoad(gameObject);

        yield return new WaitForSeconds(1);
        ConfigManager.instance.InitConfig(() =>
        {
            DataAPIController.instance.InitData(() =>
            {

                LoadSceneManager.instance.LoadScene(1, () =>
                {

                    Debug.LogError(" load scene buffer done!");
                    ViewManager.instance.SwitchView(ViewIndex.HomeView);
                });
            });
        });
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
