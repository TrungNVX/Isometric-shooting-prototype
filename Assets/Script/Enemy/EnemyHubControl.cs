using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHubControl : MonoBehaviour
{
    [SerializeField]
    private RectTransform rect_trans;
    private Transform anchor;
    private RectTransform parentUI;
    private Camera cam;
    public Image hp_group;
    public Image hp_progress;
    private float timeCount;
    private float val = 1;
    private Tweener tween_;
    // Start is called before the first frame update
    void Start()
    {
        val = 1;
        hp_group.gameObject.SetActive(false);
        cam = Camera.main;
    }

    // Update is called once per frame

    private void Update()
    {
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(cam, anchor.position);
        Vector2 localPoint = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentUI, screenPoint, null, out localPoint);
        rect_trans.anchoredPosition = localPoint;

        timeCount -= Time.deltaTime;
        hp_group.gameObject.SetActive(timeCount > 0);
    }
    public void Init(Transform anchor)
    {
        this.anchor = anchor;
        this.parentUI = IngameUI.instance.parentHub;
        rect_trans.SetParent(parentUI, false);
        
    }
    public void UpdateHP(int hp, int maxHP)
    {
        val = (float)hp / (float)maxHP;

        if (tween_ != null)
            tween_.Kill();
        tween_ = hp_progress.DOFillAmount(val, 0.5f);
        timeCount = 0.5f;
    }
}
