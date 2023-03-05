using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ShowInfoHandle(string mess);
public class SampleEvent : MonoBehaviour
{
    //1 define event 
    public event ShowInfoHandle OnShowInfoHandle;
    public event Action<bool> OnCheckAge;
    // Start is called before the first frame update
    void Start()
    {
        StudentA a = new StudentA();

        a.Setup(this);

        StudentB b = new StudentB();
        // register
        this.OnShowInfoHandle += b.Answer;

        StartCoroutine(LoopCall());
        OnCheckAge += (x) =>
        {

        };
    }
    IEnumerator LoopCall()
    {
        yield return new WaitForSeconds(1);
        //3. call event
        OnShowInfoHandle?.Invoke(" Mess");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

public class StudentA
{
    public void Setup(SampleEvent sampleEvent)
    {
        sampleEvent.OnShowInfoHandle += OnShowInfoHandle;
    }

    private void OnShowInfoHandle(string mess)
    {
        ShowInfo(mess);
    }

    public void ShowInfo(string mess)
    {
        Debug.LogError(" ShowInfo !!!"+mess);
        
    }
}
public class StudentB
{

    public void Answer(string mess)
    {
        Debug.LogError(" Answer !!!"+mess);
    }
}
public class SampleIEnum : IEnumerable<int>
{
    public List<int> ages;
    public IEnumerator GetEnumerator()
    {
        return this.GetEnumerator();
    }

    IEnumerator<int> IEnumerable<int>.GetEnumerator()
    {
        return ((IEnumerable<int>)ages).GetEnumerator();
    }
}