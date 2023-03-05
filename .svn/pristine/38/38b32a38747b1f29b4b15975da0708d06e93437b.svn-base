using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FPS_InputManager : MonoBehaviour
{
    public static Vector3 moveDir;
    public static Vector3 deltaMouse;
    private Vector3 previous_point;
    public static event Action OnChangeGun;
    public static event Action OnReloadGun;
    public static event Action<bool> OnFire;
    public static event Action<bool> OnGrenade;
    public static bool isZoom=false;
    public static bool isRun;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static void Zoom()
    {
        isZoom = !isZoom;

    }
    public static void Fire(bool isFire)
    {
        OnFire?.Invoke(isFire);
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        moveDir = new Vector3(x, 0, z);
        // 
        deltaMouse = Vector3.zero;
        if(Input.GetMouseButtonDown(0))
        {
            previous_point = Input.mousePosition;
        }
        else if(Input.GetMouseButton(0))
        {
            deltaMouse = Input.mousePosition - previous_point;
            previous_point = Input.mousePosition;
        }
        else
        {
            previous_point = Vector3.zero;
        }
        // zoom
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Zoom();
        }
        // run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRun = true;
        }
        else
        {
            isRun = false;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            OnChangeGun?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnReloadGun?.Invoke();
        }
        // fire
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnFire?.Invoke(true);
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            OnFire?.Invoke(false);
        }
        // grenade
        if (Input.GetKeyDown(KeyCode.G))
        {
            OnGrenade?.Invoke(true);
        }
        else if (Input.GetKeyUp(KeyCode.G))
        {
            OnGrenade?.Invoke(false);
        }
    }
}
