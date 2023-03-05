using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPS_Iso_CameraControl : MonoBehaviour
{
    public Transform target;
    private Transform trans;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        trans = transform;
        offset = trans.position - target.position;
    }

    // Update is called once per frame
   

    private void LateUpdate()
    {
        Vector3 pos = offset + target.position;
        trans.position = Vector3.Lerp(trans.position, pos, Time.deltaTime * 5);
    }
}
