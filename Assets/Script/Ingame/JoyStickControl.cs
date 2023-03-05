using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickControl : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerDownHandler,IPointerUpHandler
{
    public RectTransform parentJS;
    public RectTransform anchorJS;
    public RectTransform rect_js;
    public RectTransform bound_js;
    public RectTransform knod_js;
    public float limit_radious = 200;
    public Vector2 moveDir;

    void Start()
    {
        knod_js.anchoredPosition = anchorJS.anchoredPosition;
        bound_js.anchoredPosition = anchorJS.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.LogError("OnBeginDrag: " + eventData.pointerClick);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 screenPos = eventData.position;
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect_js, screenPos, null, out localPoint);
        
        knod_js.anchoredPosition = localPoint;
        if (Vector2.Distance(localPoint, bound_js.anchoredPosition) >= limit_radious)
        {
            Vector2 dir = localPoint - bound_js.anchoredPosition;
            bound_js.anchoredPosition = localPoint - dir.normalized * limit_radious;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
     
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        knod_js.anchoredPosition = anchorJS.anchoredPosition;
        bound_js.anchoredPosition = anchorJS.anchoredPosition; 
    }

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        moveDir.x = (knod_js.anchoredPosition.x - anchorJS.anchoredPosition.x) / limit_radious;
        moveDir.y = (knod_js.anchoredPosition.y - anchorJS.anchoredPosition.y) / limit_radious;
        moveDir.x += Input.GetAxis("Horizontal");
        moveDir.y += Input.GetAxis("Vertical");
        moveDir.x = Mathf.Clamp(moveDir.x, -1f, 1f);
        moveDir.y = Mathf.Clamp(moveDir.y, -1f, 1f);

        FirstControlInput.instance.OnMoveInput(moveDir);
    }
   
}
