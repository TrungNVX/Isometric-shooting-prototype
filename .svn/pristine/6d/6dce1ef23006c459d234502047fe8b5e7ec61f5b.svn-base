using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    public Transform target_player;
    public Transform trans;
    public Transform trans_cam;
    public Camera cam;
    public Transform aim;
    public Transform rootCam;
    public float limit_top=-70;
    public float limit_bottom = 30;
    private const float _threshold = 0 / 0.01f;
    private float _horizontal = 0;
    private float _vertical = 0;
    public float sensity = 5;
    private bool lockCam=true;
    public CameraData[] camData;
    private CameraData currentData;
    private Dictionary<CameraState, CameraData> dicState = new Dictionary<CameraState, CameraData>();
    // Start is called before the first frame update
    IEnumerator Start()
    {
        trans = transform;
        foreach(CameraData e in camData)
        {
            dicState.Add(e.state, e);
        }
        ChangeStateCam(CameraState.Move);
        yield return new WaitForSeconds(2);
        lockCam = false;
       
    }

    public void ChangeStateCam(CameraState newState)
    {
        currentData = dicState[newState];
    }
    private void Update()
    {
        if(FirstControlInput.isFire)
        {
            ChangeStateCam(CameraState.Aim);
        }
        else
        {
            ChangeStateCam(CameraState.Move);
        }
    }
    // Update is called once per frame
    private void LateUpdate()
    {
        RotateRoot();
        trans.position = target_player.position;
        trans_cam.localPosition = Vector3.Lerp(trans_cam.localPosition, currentData.localPos, Time.deltaTime * 6);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, currentData.fov, Time.deltaTime * 6);
        trans_cam.LookAt(aim.position, Vector3.up);
    }
    private void RotateRoot()
    {
        Vector2 look = FirstControlInput.look;
        if (look.sqrMagnitude>=_threshold&&!lockCam)
        {
            float deltaTimeMul = FirstControlInput.instance.IsCurrentDeviceMouse ? 1 : Time.deltaTime;
            // rotate X <> input Y
            _horizontal = _horizontal + look.x * deltaTimeMul* sensity;
            _vertical += look.y * deltaTimeMul * sensity;
            // Rotate Y <> input X


        }
        // limit 
        _vertical = ClamAngle(_vertical, limit_bottom, limit_top);
        _horizontal = ClamAngle(_horizontal, float.MinValue, float.MaxValue);

        Quaternion q = Quaternion.Euler(_vertical, _horizontal, 0);
        rootCam.localRotation = q;
    }
    private float ClamAngle(float val_Angle,float min, float max)
    {
        if (val_Angle < -360f)
            val_Angle += 360;
        if (val_Angle > 360f)
            val_Angle -= 360f;
        return Mathf.Clamp(val_Angle, min, max);
    }
}
public enum CameraState
{
    Move=1,
    Aim=2
}

[Serializable]
public class CameraData
{
    public CameraState state;
    public Vector3 localPos;
    public float fov;
}