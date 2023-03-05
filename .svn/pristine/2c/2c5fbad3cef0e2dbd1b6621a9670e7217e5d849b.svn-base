using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeViewAnimation : BaseViewAnimation
{
    public Animator animator;
    private Action callback;
    public void EnShowAnim()
    {
        callback?.Invoke();
    }
    public override void OnShowViewAnimation(Action callback)
    {
        this.callback = callback;
        animator.Play("In", 0, 0);
    }
    public void EndHideAnim()
    {
        callback?.Invoke();
    }
    public override void OnHideViewAnimation(Action callback)
    {
        this.callback = callback;
        animator.Play("Out", 0, 0);
    }
}
