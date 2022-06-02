using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecifyLevel : MonoBehaviour
{

    public void Level2()
    {
        GameManager.currentLevel = 2;
        GameManager.currentCount = 2;
        GameManager.currentHeart = 107;
    }
    public void Level4()
    {
        GameManager.currentLevel = 4;
        GameManager.currentCount = 2;
        GameManager.currentHeart = 267;
    }
    public void Level5()
    {
        GameManager.currentLevel = 5;
        GameManager.currentCount = 2;
        GameManager.currentHeart = 497;
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
