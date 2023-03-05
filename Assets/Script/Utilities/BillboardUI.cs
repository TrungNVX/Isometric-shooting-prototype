using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    public Transform cam_trans;
    // Start is called before the first frame update
    void Start()
    {
        cam_trans = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
       

        Vector3 direction = (  transform.position- cam_trans.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 360);

    }
}
