using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    //레벨맵
    public GameObject[] LevelMap;
    //발자국 수 별로 묶음
    public GameObject[] Step1;//발자국이 1개일 때
    public GameObject[] Step2;//발자국이 2개일 때


    public static bool firstT = false;//첫번째 튜토리얼
    public static bool secondT = false;//두번재 튜토리얼


    // Start is called before the first frame update
    void Start()
    {
        ShowLevel();
        ShowSteps();
        //TimeStart();
    }

    //레벨 맵 띄우기
    public void ShowLevel()
    {
        for(int i = 1; i<6; i++)
        {
            if(GameManager.currentLevel == i)
            {
                LevelMap[i-1].SetActive(true);
            } 
        }
    }

    //발자국 띄우기
    public void ShowSteps()
    {
        for(int i = 1; i<6; i++)//레벨 1~5 돌기
        {
            if(GameManager.currentLevel == i)
            {
                if (GameManager.currentCount == 1)//발자국이 1일때
                {
                    Step1[i - 1].SetActive(true);//각 단계의 발자국 1 찍기
                }
                if (GameManager.currentCount == 2)//각 단계의 발자국 1, 2 찍기
                {
                    Step1[i - 1].SetActive(true);
                    Step2[i - 1].SetActive(true);
                }
            }
            
        }
    }

    
    public void GameStart()
    {
        GameManager.ResetMenu();
        if (GameManager.currentLevel == 1 && GameManager.currentCount == 0)
        {
            SceneManager.LoadScene("T_Main");
        }else if (GameManager.currentLevel == 2 && GameManager.currentCount == 0)
        {
            SceneManager.LoadScene("T_BasicToast");
        }
        else
        {
            SceneManager.LoadScene("Main");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
