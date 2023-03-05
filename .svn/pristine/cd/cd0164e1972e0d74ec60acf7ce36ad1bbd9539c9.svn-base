using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Crosshair : MonoBehaviour
{
    public RectTransform parent;
    public float rate = 1;
    private float scale;
    private float targetVal;
    public FPS_WeaponBehaviour weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetVal = weapon.accuracy;
        scale = Mathf.Lerp(scale, targetVal, Time.deltaTime * 2);
        scale = Mathf.Clamp(scale, weapon.min_a, weapon.max_a);
        parent.sizeDelta = Vector2.one * scale* rate;
    }
}
