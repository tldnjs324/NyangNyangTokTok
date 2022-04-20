using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCharacter : MonoBehaviour
{
    public float y1;
    public float x;
    void Start()
    {
        x = this.GetComponent<RectTransform>().anchoredPosition.x;
        y1 = this.GetComponent<RectTransform>().anchoredPosition.y;
    }
    
    void Update()
    {
        if (this.GetComponent<RectTransform>().anchoredPosition.y < 0)
        {
            y1 += 10.0f;
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(x, y1);
        }


    }
}
