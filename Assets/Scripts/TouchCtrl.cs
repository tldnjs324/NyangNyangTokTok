using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool isBtnDown = false;

    private void Update()
    {
        if (isBtnDown)
        {
            Debug.Log("BTN DOWN");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isBtnDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isBtnDown = false;
    }
}
