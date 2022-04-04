using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNextMenu : MonoBehaviour
{

    public void Move1to2()
    {
        for (int i = 0; i < 20; i++)
        {
            if (SpecifyNumber.MakingMenu[0] == i)
            {
                SceneManager.LoadScene(i + 9);
            }
        }
    }

    public void Move2to3()
    {
        for (int i = 0; i < 20; i++)
        {
            if (SpecifyNumber.MakingMenu[1] == i)
            {
                SceneManager.LoadScene(i + 9);
            }
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
