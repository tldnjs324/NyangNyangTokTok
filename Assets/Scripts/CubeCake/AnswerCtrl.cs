using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCtrl : MonoBehaviour
{
    //질문 어디서 본 모양을 고르세요
    public GameObject[] QuestionList;
    //질문 지정을 위한 숫자
    private int random;

    //카메라 리스트(오앞위왼)
    public List<Camera> CameraList = new List<Camera>();
    //버튼 리스트(오앞위왼)
    public List<Button> ButtonList = new List<Button>();

    //카메라 위치 리스트(카메라 위치 랜덤 설정 할 때 사용)
    public List<Rect> RectList = new List<Rect>() {
        new Rect(0.475f, 0.405f, 0.23f, 0.34f), new Rect(0.475f, 0.049f, 0.23f, 0.34f), new Rect(0.71f, 0.049f, 0.23f, 0.34f), new Rect(0.71f, 0.405f, 0.23f, 0.34f)};

    //맞았을 시 팝업
    public GameObject sign_yes;
    //틀렸을 시 팝업
    public GameObject[] sign_no;
    //팝업 뜰 때 검은 배경 화면
    public GameObject black_screen;

    // Start is called before the first frame update
    void Start()
    {
        //카메라 위치 랜덤 설정
        for (int i = 0; i<4; i++)
        {
            int rand = Random.Range(0, RectList.Count);
            CameraList[i].rect = RectList[rand];
            RectList.RemoveAt(rand);
        }
        random = Random.Range(0, 4);
        //정답 지정
        for(int i = 0; i<4; i++)
        {
            if(random == i)
            {
                QuestionList[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Btn0Clicked()
    {
        for(int i = 0; i<4; i++)
        {
            if (CameraList[i].rect == new Rect(0.475f, 0.405f, 0.23f, 0.34f))
            {
                if(i == random)
                {
                    sign_yes.SetActive(true);
                    black_screen.SetActive(true);
                }
                else
                {
                    sign_no[i].SetActive(true);
                    black_screen.SetActive(true);
                    ButtonList[0].interactable = false;
                }
            }
        }
    }
    public void Btn1Clicked()
    {
        for (int i = 0; i < 4; i++)
        {
            if (CameraList[i].rect == new Rect(0.71f, 0.405f, 0.23f, 0.34f))
            {
                if (i == random)
                {
                    sign_yes.SetActive(true);
                    black_screen.SetActive(true);
                }
                else
                {
                    sign_no[i].SetActive(true);
                    black_screen.SetActive(true);
                    ButtonList[1].interactable = false;
                }
            }
        }
    }
    public void Btn2Clicked()
    {
        for (int i = 0; i < 4; i++)
        {
            if (CameraList[i].rect == new Rect(0.475f, 0.049f, 0.23f, 0.34f))
            {
                if (i == random)
                {
                    sign_yes.SetActive(true);
                    black_screen.SetActive(true);
                }
                else
                {
                    sign_no[i].SetActive(true);
                    black_screen.SetActive(true);
                    ButtonList[2].interactable = false;
                }
            }
        }
    }
    public void Btn3Clicked()
    {
        for (int i = 0; i < 4; i++)
        {
            if (CameraList[i].rect == new Rect(0.71f, 0.049f, 0.23f, 0.34f))
            {
                if (i == random)
                {
                    sign_yes.SetActive(true);
                    black_screen.SetActive(true);
                }
                else
                {
                    sign_no[i].SetActive(true);
                    black_screen.SetActive(true);
                    ButtonList[3].interactable = false;
                }
            }
        }
    }

    public void Close_No()
    {
        for(int i = 0; i<4; i++)
        {
            sign_no[i].SetActive(false);
        }  
        black_screen.SetActive(false);
    }

    public void NextScene()
    {
        //씬 넘어가는 코드
    }
}
