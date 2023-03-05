using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DialogIndex
{
    GunInfoDialog = 0,
    MessageDialog = 1,
    VictoryDialog=2,
    LoseDialog=3,
    PauseDialog=4,
    GunSelectEquipDialog=5
}
public class DialogConfig
{
    public static DialogIndex[] dialogIndices =
    {
        DialogIndex.GunInfoDialog,
        DialogIndex.MessageDialog,
        DialogIndex.VictoryDialog,
        DialogIndex.LoseDialog,
        DialogIndex.PauseDialog,
        DialogIndex.GunSelectEquipDialog
       
    };
}
public class DialogParam
{

}
public class GunInfoDialogParam : DialogParam
{
    public ConfigWeaponRecord cf;
}
public class GunSelectEquipDialogParam: DialogParam
{
    public string weapon_ID;
}
public class MessageDialogParam : DialogParam
{
    public string mess;
}