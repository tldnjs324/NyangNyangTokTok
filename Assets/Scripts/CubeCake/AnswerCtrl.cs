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

    //카메라 리스트(오앞위뒤)
    public List<Camera> CameraList = new List<Camera>();
    //버튼 리스트(오앞위뒤)
    public List<Button> ButtonList = new List<Button>();
    //틀렸을 때 가려지는 회색 이미지 리스트(오앞위뒤)
    public List<Image> NoneList = new List<Image>();

    //카메라 위치 리스트
    public List<Rect> RectList = new List<Rect>() {
        new Rect(0.5f, 0.5f, 0.25f, 0.5f), new Rect(0.5f, 0, 0.25f, 0.5f), new Rect(0.75f, 0, 0.25f, 0.5f), new Rect(0.75f, 0.5f, 0.25f, 0.5f)};

    // Start is called before the first frame update
    void Start()
    {
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

    public void RandAnswer()
    {
        if(random == 0)
        {
            question.text = "앞에서 본 모양을 고르세요.";
        }else if(random == 1)
        {
            question.text = "왼쪽에서 본 모양을 고르세요.";
        }
        else if (random == 2)
        {
            question.text = "오른쪽에서 본 모양을 고르세요.";
        }
        else if (random == 3)
        {
            question.text = "위에서 본 모양을 고르세요.";
        }
    }
}
