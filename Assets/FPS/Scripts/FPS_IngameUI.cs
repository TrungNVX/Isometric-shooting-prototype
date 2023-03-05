using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS_IngameUI : MonoBehaviour
{
    public Image btnFireImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnFire(bool isFire)
    {
        btnFireImage.transform.localScale = isFire ? Vector3.one * 0.9f : Vector3.one;
        btnFireImage.color = isFire ? Color.gray : Color.white;
        FPS_InputManager.Fire(isFire);
    }
}
