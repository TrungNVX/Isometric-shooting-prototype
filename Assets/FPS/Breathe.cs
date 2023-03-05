using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathe : MonoBehaviour
{
    public bool isBreath;
    Vector3 startPos;

    public float amplitude = 10f;
    public float period = 5f;
    private Transform trans;
    private Vector3 ogrinal_pos;
    private void Awake()
    {
        trans = transform;
        ogrinal_pos = trans.localPosition;
    }
    protected void Start()
    {
        startPos = transform.localPosition;

    }

    protected void Update()
    {
        if(isBreath)
        {
            float theta = Time.timeSinceLevelLoad / period;
            float distance = amplitude * Mathf.Sin(theta);
            trans.localPosition = startPos + Vector3.up * distance;
        }
        else
        {
            trans.localPosition = ogrinal_pos;
        }
       
    }
}
