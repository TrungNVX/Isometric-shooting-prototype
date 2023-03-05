using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CreepStartState : FSM_State
{

    [NonSerialized]
    public CreepControl parent;
    private Coroutine coroutine_;
    public GameObject model;
    public override void OnEnter()
    {
        coroutine_ = parent.StartCoroutine(DelayAnim());
    }
    IEnumerator DelayAnim()
    {
        parent.trans.localRotation = Quaternion.Euler(0, UnityEngine.Random.Range(0, 180), 0);
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f,3f));
        model.SetActive(true);
        parent.dataBinding.Emerge = true;
    }
    public override void OnAnimationExist()
    {
        parent.GotoState(parent.chaseState);
        
    }
    public override void Exits()
    {
        base.Exits();
        if (coroutine_ != null)
            parent.StopCoroutine(coroutine_);
    }
}
