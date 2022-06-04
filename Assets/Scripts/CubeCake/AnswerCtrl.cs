using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCtrl : MonoBehaviour
{
    
    float scaleheight = ((float)Screen.width / Screen.height) / ((float)18.5 / 9);
    //float scalewidth = 1f / scaleheight;

    //질문 어디서 본 모양을 고르세요
    public GameObject[] QuestionList;
    //질문 지정을 위한 숫자
    private int random;

    //카메라 리스트(오앞위왼)
    public List<Camera> CameraList = new List<Camera>();
    //버튼 리스트(오앞위왼)
    public List<Button> ButtonList = new List<Button>();

    //카메라 위치 리스트(카메라 위치 랜덤 설정 할 때 사용 / 오앞위왼 순)
    public List<Rect> RectList = new List<Rect>() {
        new Rect(0.475f, 0.434f, 0.23f, 0.363f), new Rect(0.475f, 0.052f, 0.23f, 0.363f), new Rect(0.71f, 0.052f, 0.23f, 0.363f), new Rect(0.71f, 0.434f, 0.23f, 0.363f)}; //원본
    public List<Rect> RectList2 = new List<Rect>() {
        new Rect(0.475f, 0.434f, 0.2f, 0.363f), new Rect(0.475f, 0.052f, 0.2f, 0.363f), new Rect(0.68f, 0.052f, 0.2f, 0.363f), new Rect(0.68f, 0.434f, 0.2f, 0.363f)}; //가로 긺
    public List<Rect> RectList3 = new List<Rect>() {
        new Rect(0.475f, 0.434f, 0.23f, 0.363f), new Rect(0.475f, 0.11f, 0.23f, 0.363f), new Rect(0.71f, 0.11f, 0.23f, 0.363f), new Rect(0.71f, 0.434f, 0.23f, 0.363f)}; //세로 긺


    //맞았을 시 팝업
    public GameObject sign_yes;
    //틀렸을 시 팝업
    public GameObject[] sign_no;
    //정답 팝업 뜰 때 검은 배경 화면
    //public GameObject black_screen;
    //오답 팝업 뜰 때 검은 배경 화면
    //public GameObject black_screen_no;

    //팝업 위치
    public string[] position = { "우측", "앞", "위", "좌측" };
    //팝업 위치 텍스트
    public Text position_text;

    //큐브 틀린 수 
    public static int cube_wrong;

    //효과음
    public AudioClip[] click;
    AudioSource audioSrc;

    //효과음 나오게 하기
    public void ClickSound(int x)
    {
        audioSrc.PlayOneShot(click[x]);
    }


    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        if (scaleheight < 1) //세로 길쭉
        {
            //카메라 위치 랜덤 설정
            for (int i = 0; i < 4; i++)
            {
                int rand = Random.Range(0, RectList3.Count);
                CameraList[i].rect = RectList3[rand];
                RectList3.RemoveAt(rand);
            }
            random = Random.Range(0, 4);
            //정답 지정
            for (int i = 0; i < 4; i++)
            {
                if (random == i)
                {
                    QuestionList[i].SetActive(true);
                    position_text.text = position[i];
                }
            }
        }
        else if (scaleheight > 1)//가로 길쭉
        {
            //카메라 위치 랜덤 설정
            for (int i = 0; i < 4; i++)
            {
                int rand = Random.Range(0, RectList2.Count);
                CameraList[i].rect = RectList2[rand];
                RectList2.RemoveAt(rand);
            }
            random = Random.Range(0, 4);
            //정답 지정
            for (int i = 0; i < 4; i++)
            {
                if (random == i)
                {
                    QuestionList[i].SetActive(true);
                    position_text.text = position[i];
                }
            }
        }
        else if (scaleheight == 1)//원래
        {
            //카메라 위치 랜덤 설정
            for (int i = 0; i < 4; i++)
            {
                int rand = Random.Range(0, RectList.Count);
                CameraList[i].rect = RectList[rand];
                RectList.RemoveAt(rand);
            }
            random = Random.Range(0, 4);
            //정답 지정
            for (int i = 0; i < 4; i++)
            {
                if (random == i)
                {
                    QuestionList[i].SetActive(true);
                    position_text.text = position[i];
                }
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Btn0Clicked()
    {
        if (scaleheight < 1) //세로 길쭉
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.475f, 0.434f, 0.23f, 0.363f))
                {
                    if (i == random)
                    {
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //하트 올리는 코드
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[0].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }
        else if(scaleheight > 1) //가로 길쭉
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.475f, 0.434f, 0.2f, 0.363f))
                {
                    if (i == random)
                    {
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //하트 올리는 코드
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[0].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }
        else if(scaleheight == 1) //원본
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.475f, 0.434f, 0.23f, 0.363f))
                {
                    if (i == random)
                    {
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //하트 올리는 코드
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[0].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }

        
    }
    public void Btn1Clicked()
    {
        if (scaleheight < 1) //세로 길쭉
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.71f, 0.434f, 0.23f, 0.363f))
                {
                    if (i == random)
                    {
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        //하트 올리는 코드
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[1].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }
        else if (scaleheight > 1) //가로 길쭉
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.68f, 0.434f, 0.2f, 0.363f))
                {
                    if (i == random)
                    {
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        //하트 올리는 코드
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[1].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }
        else if (scaleheight == 1) //원본
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.71f, 0.434f, 0.23f, 0.363f))
                {
                    if (i == random)
                    {
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        //하트 올리는 코드
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[1].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }

        
    }
    public void Btn2Clicked()
    {
        if (scaleheight < 1) //세로 길쭉
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.475f, 0.11f, 0.23f, 0.363f))
                {
                    if (i == random)
                    {
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        //하트 올리는 코드
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[2].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }
        else if (scaleheight > 1) //가로 길쭉
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.475f, 0.052f, 0.2f, 0.363f))
                {
                    if (i == random)
                    {
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        //하트 올리는 코드
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[2].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }
        else if (scaleheight == 1) //원본
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.475f, 0.052f, 0.23f, 0.363f))
                {
                    if (i == random)
                    {
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        //하트 올리는 코드
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[2].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }


        
    }
    public void Btn3Clicked()
    {
        if (scaleheight < 1) //세로 길쭉
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.71f, 0.11f, 0.23f, 0.363f))
                {
                    if (i == random)
                    {
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        //하트 올리는 코드
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[3].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }
        else if (scaleheight > 1) //가로 길쭉
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.68f, 0.052f, 0.2f, 0.363f))
                {
                    if (i == random)
                    {
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        //하트 올리는 코드
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[3].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }
        else if (scaleheight == 1) //원본
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.71f, 0.052f, 0.23f, 0.363f))
                {
                    if (i == random)
                    {
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        //하트 올리는 코드
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[3].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }


        
    }

    /*
    public void Close_No()
    {
        for(int i = 0; i<4; i++)
        {
            sign_no[i].SetActive(false);
        }  
        black_screen_no.SetActive(false);
    }
    */
    
}
