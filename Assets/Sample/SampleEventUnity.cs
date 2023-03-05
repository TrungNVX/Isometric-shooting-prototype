using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SampleEventUnity : MonoBehaviour
{
    public Button btnDemo;

    public UnityEvent mytestEvent = new UnityEvent();
    public UnityEvent<bool, int> mytestEventparam = new UnityEvent<bool, int>();
    // Start is called before the first frame update
    void Start()
    {
        btnDemo.onClick.AddListener(OnCheckEvent);
        btnDemo.onClick.RemoveListener(OnCheckEvent);
        mytestEventparam.AddListener((a,b) =>
        {
            //
        });
        mytestEventparam.RemoveAllListeners();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCheckEvent()
    {
        Debug.LogError("OnCheckEvent");
    }
}
