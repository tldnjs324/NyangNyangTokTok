using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Starting : MonoBehaviour
{
    int time = 3;

    public void Start()
    {
        TimeStart();
    }
    void TimeStart()
    {
        InvokeRepeating("TimeCount", 0f, 1f);
        Invoke("TimeEnd", 3f);
    }
    void TimeCount()
    {
        --time;
    }
    void TimeEnd()
    {
        CancelInvoke("TimeCount");
        SceneLoad.LoadScene("LevelMap");
    }
    /*
    public void StartBtn()
    {
        SceneLoad.LoadScene("LevelMap");
    }*/
}

