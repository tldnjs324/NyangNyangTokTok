using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class NewStartBtn : MonoBehaviour
{
    bool startBtnDown;

    public void gameStartPressed()
    {
        startBtnDown = true;
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        if (startBtnDown)
        {
            SceneManager.LoadScene("Start");
        }
    }
}
