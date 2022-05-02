using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHeart : MonoBehaviour
{
    public void FirstCorrect()
    {
        if(GameManager.currentHeart + 3 < 100000)
        {
            GameManager.currentHeart += 3;
        }
        else
        {
            GameManager.currentHeart = 99999;
        }
    }
    public void SecondCorrect()
    {
        if (GameManager.currentHeart + 2 < 100000)
        {
            GameManager.currentHeart += 2;
        }
        else
        {
            GameManager.currentHeart = 99999;
        }
    }
    public void ThirdCorrect()
    {
        if (GameManager.currentHeart + 1 < 100000)
        {
            GameManager.currentHeart += 1;
        }
        else
        {
            GameManager.currentHeart = 99999;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
