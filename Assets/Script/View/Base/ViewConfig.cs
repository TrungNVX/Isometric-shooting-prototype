using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ViewIndex
{
    EmptyView = 0,
    HomeView = 1,
    MapView = 2,
    ShopView = 3,
    WeaponView = 4,
    QuestView = 5
}
public class ViewConfig
{
    public static ViewIndex[] viewIndies =
    {
        ViewIndex.EmptyView,
        ViewIndex.HomeView,
        ViewIndex.MapView,
         ViewIndex.ShopView,
        ViewIndex.WeaponView,
        ViewIndex.QuestView,
    };
}
public class ViewParam
{

}
public class CardsViewParam : ViewParam
{
    public string gunName;
}