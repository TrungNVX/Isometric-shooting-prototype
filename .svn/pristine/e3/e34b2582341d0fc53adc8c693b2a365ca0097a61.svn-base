using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionCollectItemControl : MonoBehaviour
{
    public MissionCollectItem[] items;
    public Sprite iconItem;
    public RectTransform itemUI;
    public Image icon;
    public Text numLB;
    public void Setup()
    {
        icon.overrideSprite = iconItem;
        numLB.text = "0/" + items.Length.ToString();
        itemUI.SetParent(IngameUI.instance.parentMissionInfo);
        itemUI.anchoredPosition = Vector2.zero;
    }
    public void UpdateNumber(int num)
    {
        numLB.text = num.ToString()+"/" + items.Length.ToString();
    }
}
