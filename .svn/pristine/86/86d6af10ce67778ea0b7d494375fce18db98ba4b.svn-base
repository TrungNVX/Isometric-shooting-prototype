using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageDialog : BaseDialog
{
    public Text mess_lb;
    // Start is called before the first frame update
    public override void Setup(DialogParam dialogParam)
    {
        base.Setup(dialogParam);
        MessageDialogParam d_paream = (MessageDialogParam)dialogParam;
        mess_lb.text = d_paream.mess;
    }
    public void OnClose()
    {
        DialogManager.instance.HideAllDialog();
    }
}
