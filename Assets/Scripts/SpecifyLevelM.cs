using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecifyLevelM : MonoBehaviour
{

    public void Level2()
    {
        GameManager.currentLevel = 2;
        GameManager.currentCount = 2;
        GameManager.currentHeart = 107;

        GameManager.ResetMenu();
        SceneManager.LoadScene("Main");
    }
    public void Level3()
    {
        GameManager.currentLevel = 3;
        GameManager.currentCount = 2;
        GameManager.currentHeart = 177;

        GameManager.ResetMenu();
        SceneManager.LoadScene("Main");
    }
    public void Level4()
    {
        GameManager.currentLevel = 4;
        GameManager.currentCount = 2;
        GameManager.currentHeart = 267;

        GameManager.ResetMenu();
        SceneManager.LoadScene("Main");
    }
    public void Level5()
    {
        GameManager.currentLevel = 5;
        GameManager.currentCount = 2;
        GameManager.currentHeart = 497;

        GameManager.ResetMenu();
        SceneManager.LoadScene("Main");
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
