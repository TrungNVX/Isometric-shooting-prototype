using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_CameraControl : MonoBehaviour
{
    private float horizontal;
    public float h_sensity = 0.1f;
    private float vertical;
    public float v_sensity = 0.1f;
    public float speed = 5;
    public Camera cam_main;
    public Camera cam_gun;
    private float fov_cam;
    public Animator animRoot_Gun;
    private Vector3 slide_gun_cur;
    private FPS_WeaponBehaviour currentWP;
    // Start is called before the first frame update
    void Start()
    {
        fov_cam = cam_main.fieldOfView;
        FPS_WeaponControl.OnChangeGun.AddListener((wp) =>
        {
            currentWP = wp;
           // fov_cam = currentWP.fov;
        });
        slide_gun_cur = Vector3.zero;
    }

   

    // Update is called once per frame
    void LateUpdate()
    {
        fov_cam = FPS_InputManager.isZoom ? currentWP.fov_zoom : currentWP.fov;
        Vector3 delta = FPS_InputManager.deltaMouse;
        Vector3 slide_del = delta;
        slide_del.Normalize();
        slide_gun_cur = Vector3.Lerp(slide_gun_cur, slide_del, Time.deltaTime * 3);
        animRoot_Gun.SetFloat("X", slide_gun_cur.x);
        animRoot_Gun.SetFloat("Y", slide_gun_cur.y);
       
        horizontal = Mathf.Lerp(horizontal, horizontal + delta.x * h_sensity, Time.deltaTime * speed);
        vertical = Mathf.Lerp(vertical, vertical - delta.y * v_sensity- currentWP.GetRecoilCamera(), Time.deltaTime * speed);

        Quaternion q = Quaternion.Euler(vertical, horizontal, 0);
        transform.localRotation = q;
        cam_gun.fieldOfView = Mathf.Lerp(cam_gun.fieldOfView, fov_cam, Time.deltaTime * 10);
        cam_main.fieldOfView = Mathf.Lerp(cam_main.fieldOfView, fov_cam, Time.deltaTime * 10);
    }
}
