using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseDialog : BaseDialog
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public override void OnShowDialog()
    {
        base.OnShowDialog();
        Time.timeScale = 0;
    }
    public override void OnHideDialog()
    {
        base.OnHideDialog();
        Time.timeScale = 1;
    }
    // Update is called once per frame

    public void OnQuit()
    {
        DialogManager.instance.HideDialog(dialogIndex);
        LoadSceneManager.instance.LoadScene(1, () =>
        {

            Debug.LogError(" load scene buffer done!");
            ViewManager.instance.SwitchView(ViewIndex.MapView);
        });
    }
    public void OnResum()
    {
        DialogManager.instance.HideDialog(dialogIndex);
       
    }
}