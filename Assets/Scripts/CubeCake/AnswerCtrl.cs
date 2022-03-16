using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCtrl : MonoBehaviour
{
    //질문 어디서 본 모양을 고르세요
    public Text question;
    //질문 지정을 위한 숫자
    private int random;

    //카메라 리스트(오앞위왼)
    public List<Camera> CameraList = new List<Camera>();
    //버튼 리스트(오앞위왼)
    public List<Button> ButtonList = new List<Button>();
    //틀렸을 때 가려지는 회색 이미지 리스트(오앞위왼)
    public List<Image> NoneList = new List<Image>();

    //카메라 위치 리스트(카메라 위치 랜덤 설정 할 때 사용)
    public List<Rect> RectList = new List<Rect>() {
        new Rect(0.5f, 0.5f, 0.25f, 0.5f), new Rect(0.5f, 0, 0.25f, 0.5f), new Rect(0.75f, 0, 0.25f, 0.5f), new Rect(0.75f, 0.5f, 0.25f, 0.5f)};

    //맞았을 시 팝업
    public GameObject sign_yes;
    //틀렸을 시 팝업
    public GameObject sign_no;
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
        RandAnswer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //정답 지정( 및 버튼 및 회색 이미지 지정)
    public void RandAnswer()
    {
        if(random == 0)
        {
            question.text = "오른쪽에서 본 모양을 고르세요.";
        }else if(random == 1)
        {
            question.text = "앞쪽에서 본 모양을 고르세요.";
        }
        else if (random == 2)
        {
            question.text = "위쪽에서 본 모양을 고르세요.";
        }
        else if (random == 3)
        {
            question.text = "왼쪽에서 본 모양을 고르세요.";
        }
    }

    public void Btn0Clicked()
    {
        for(int i = 0; i<4; i++)
        {
            if (CameraList[i].rect == new Rect(0.5f, 0.5f, 0.25f, 0.5f))
            {
                if(i == random)
                {
                    sign_yes.SetActive(true);
                    black_screen.SetActive(true);
                }
                else
                {
                    sign_no.SetActive(true);
                    black_screen.SetActive(true);
                }
            }
        }
    }
    public void Btn1Clicked()
    {
        for (int i = 0; i < 4; i++)
        {
            if (CameraList[i].rect == new Rect(0.75f, 0.5f, 0.25f, 0.5f))
            {
                if (i == random)
                {
                    sign_yes.SetActive(true);
                    black_screen.SetActive(true);
                }
                else
                {
                    sign_no.SetActive(true);
                    black_screen.SetActive(true);
                }
            }
        }
    }
    public void Btn2Clicked()
    {
        for (int i = 0; i < 4; i++)
        {
            if (CameraList[i].rect == new Rect(0.5f, 0, 0.25f, 0.5f))
            {
                if (i == random)
                {
                    sign_yes.SetActive(true);
                    black_screen.SetActive(true);
                }
                else
                {
                    sign_no.SetActive(true);
                    black_screen.SetActive(true);
                }
            }
        }
    }
    public void Btn3Clicked()
    {
        for (int i = 0; i < 4; i++)
        {
            if (CameraList[i].rect == new Rect(0.75f, 0, 0.25f, 0.5f))
            {
                if (i == random)
                {
                    sign_yes.SetActive(true);
                    black_screen.SetActive(true);
                }
                else
                {
                    sign_no.SetActive(true);
                    black_screen.SetActive(true);
                }
            }
        }
    }

    public void Close_No()
    {
        sign_no.SetActive(false);
        black_screen.SetActive(false);
    }

    public void NextScene()
    {
        //씬 넘어가는 코드
    }
}
