using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    RectTransform rectTran;
    void Start()
    {
        rectTran = gameObject.GetComponent<RectTransform>();
        Size90();
        Invoke("Size110", 0.2f);
        Invoke("Size100", 0.3f);
    }
    
    void Update()
    {
        /*
        if(Recipe2.popup == false)
        {
            Size110();
            Invoke("Size90_2", 0.2f);
            //Invoke("Size100", 0.3f);
        }
        */
    }

    void Size90()
    {
        rectTran.localScale = new Vector3(0.8f, 0.8f, 1);
    }
    void Size90_2()
    {
        rectTran.localScale = new Vector3(0.8f, 0.8f, 1);
        gameObject.SetActive(false);
    }
    void Size100()
    {
        rectTran.localScale = new Vector3(1, 1, 1);
    }
    void Size110()
    {
        rectTran.localScale = new Vector3(1.2f, 1.2f, 1);
    }
}
