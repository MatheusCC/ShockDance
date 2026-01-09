/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualJoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

    // Use this for initialization

    private Image touchScreenImg;
    public Vector3 InputDirection { set; get; }

	void Start () {

        touchScreenImg = GetComponent<Image>();
	}
	
    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos = Vector2.zero;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(touchScreenImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / touchScreenImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / touchScreenImg.rectTransform.sizeDelta.y);

            float x = (touchScreenImg.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
            float y = (touchScreenImg.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

            InputDirection = new Vector3(x, 0, y);
            //InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

            //Debug.Log(InputDirection);

        }

    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        InputDirection = Vector3.zero;
    }
}
*/