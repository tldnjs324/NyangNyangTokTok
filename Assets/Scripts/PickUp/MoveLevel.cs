using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MoveLevel : MonoBehaviour
{
    public static int wrongCount = 0;

    public Text bossText;
    public GameObject bossPanel;
    public GameObject boss;
    public GameObject bossBtn;

    //오디오
    public AudioClip levelup;
    public AudioClip popup;
    public AudioClip[] bossTalk;

    public GameObject CountPopups;
    //public GameObject CountPopup;//카운트가 1,2가 됐을 때 팝업
    //public GameObject CountInfoPopup;//카운트 설명해주는 팝업
    public GameObject LevelPopup;//레벨업 팝업(카운트가 3이 됐을 때 팝업)
    public GameObject Gifsteps;

    //레벨업 팝업 이미지
    public GameObject[] PopupImg;
    //레벨 텍스트에 들어갈 글
    private string[] LvText = { "Lv.1\n수습기간\n알바생", "Lv.2\n알바생", "Lv.3\n우수 알바생", "Lv.4\n부매니저", "Lv.5\n매니저" };
    //레벨 텍스트
    public Text BeforeLevel;//현재 레벨
    public Text AfterLevel;//승진할 레벨
    //발자국
    public GameObject Step1;
    public GameObject Step2;



    private string[] b_text = { "오늘도 고생 많았어요!\n내일도 즐겁게 일해요~!", " 되신 걸 축하드려요~!\n앞으로도 같이 재미있게 일해요!",
        "수습기간 끝난거 축하해요!\n이제부터는 알바생님께 토스트도 맡겨볼게요~!", "오랫동안 같이 일해줘서 고마워요~!\n내일도 같이 즐겁게 일해요!" };
    private static int textOrder = 0;//b_text 나올 숫자 저장
    private string[] position = { "정식 알바생이", "우수 알바생이", "부매니저가", "매니저가"};//직급 저장

    //고양이
    public GameObject[] talkPanel; //나비, 냐옹, 체리
    public GameObject[] cat;//나비, 냐옹, 체리

    //AudioSource audioSrc;
    void Start()
    {
        
    }

    public void MovingLevel()
    {
        if(wrongCount == 0)//한번도 틀리지 않았을 때
        {
            GameManager.currentCount += 1;//카운트 올리고
            if (GameManager.currentCount == 3)//카운트가 3 채워졌을 때 레벨 올려야 함
            {
                if(GameManager.currentLevel < 5)//레벨 5가 아닐 때
                {
                    GameManager.currentLevel += 1;//현재 레벨을 올리고!
                    GameManager.currentCount = 0;//데베에 카운트 0으로 업데이트! 3개가 차면 레벨업 후 다시 0이 되기 때문

                    if (GameManager.currentLevel == 2)//정식 알바생이 돼서 이제 토스트를 배워야 할 때
                    {
                        textOrder = 2;
                    }
                    else//정식 알바생 외 진급
                    {
                        //직급 멘트 수정
                        b_text[1] = position[GameManager.currentLevel - 2] + b_text[1];
                        textOrder = 1;
                    }
                    for(int i = 2; i<6; i++)
                    {
                        if (GameManager.currentLevel == i)
                        {
                            PopupImg[i - 2].SetActive(true);
                        }
                    }

                    //레벨 업 팝업 띄우기
                    //LevelPopup.SetActive(true);
                    Popup pop = LevelPopup.GetComponent<Popup>();
                    Invoke("UpSound", 0.5f);
                    pop.PopUp7();
                    Invoke("ShowGif", 0.25f);

                }
                else if (GameManager.currentLevel == 5){//레벨5인데 또 3개 카운트 채운 경우
                    textOrder = 3;
                    //사장님 나타나서 고맙다는 인사와 함께 계속해달라는 메시지 전하기
                    ShowBoss();
                }
            }
            else//카운트가 1이나 2로 채워졌을 때
            {
                textOrder = 0;
                //팝업 띄우기
                for(int i = 1; i<5; i++)
                {
                    if(GameManager.currentLevel == i)
                    {
                        BeforeLevel.text = LvText[i-1];
                        AfterLevel.text = LvText[i];
                    }
                }
                if(GameManager.currentCount == 1)
                {
                    Step1.SetActive(true);
                }else if (GameManager.currentCount == 2)
                {
                    Step1.SetActive(true);
                    Step2.SetActive(true);
                }
                //설명 팝업 같이 띄우기
                //CountInfoPopup.SetActive(true);
                Popup pop = CountPopups.GetComponent<Popup>();
                pop.PopUp6();
                Invoke("PopSound", 0.5f);
                //카운트 올라가는 팝업 띄우기(다음버튼 누르고로 변경)
                //CountPopup.SetActive(true);
            }
        }
        else//한번이라도 틀리면 발자국, 레벨업 없음. 사장님이랑 인사하고 다시 출근하기ㄱㄱ
        {
            textOrder = 0;
            ShowBoss();
        }
        cat[GameManager.random].SetActive(false);
        talkPanel[GameManager.random].SetActive(false);
        //PlayerPrefs.Save();//데이터 저장
    }
    void ShowGif()
    {
        Gifsteps.SetActive(true);
    }
    public void ShowCountPopup()
    {
        //CountInfoPopup.SetActive(false);
        //CountPopup.SetActive(true);
    }

    //데이터 저장
    public void SaveData()
    {
        PlayerPrefs.SetInt("tmpLevel", GameManager.currentLevel);
        PlayerPrefs.SetInt("tmpCount", GameManager.currentCount);
        PlayerPrefs.SetInt("tmpHeart", GameManager.currentHeart);
        PlayerPrefs.SetInt("tmpFirstT", MapManager.firstT);
        PlayerPrefs.SetInt("tmpSecondT", MapManager.secondT);
        PlayerPrefs.Save();//PlayerPrefs를 저장
    }

    public void ShowBoss()
    {
        bossPanel.SetActive(true);
        boss.SetActive(true);
        //BossTalkStart();
        StartCoroutine(_typing(textOrder));
        StartCoroutine(bossTalking(textOrder));
        //Invoke("BossTalkStart", 1f); //추후 음성에 맞게 초 수정
    }

    IEnumerator bossTalking(int x)
    {
        yield return new WaitForSeconds(1f);

        if(x == 0)
        {
            PickUpManager.audioSrc.PlayOneShot(bossTalk[0]);
            yield return new WaitForSeconds(1.9f);
            PickUpManager.audioSrc.PlayOneShot(bossTalk[1]);
        }
        if (x == 1)
        {
            PickUpManager.audioSrc.PlayOneShot(bossTalk[GameManager.currentLevel]);
            yield return new WaitForSeconds(2.5f);
            PickUpManager.audioSrc.PlayOneShot(bossTalk[6]);
        }
        if (x == 2)
        {
            PickUpManager.audioSrc.PlayOneShot(bossTalk[7]);
            yield return new WaitForSeconds(2.5f);
            PickUpManager.audioSrc.PlayOneShot(bossTalk[8]);
        }
        if (x == 3)
        {
            PickUpManager.audioSrc.PlayOneShot(bossTalk[9]);
            yield return new WaitForSeconds(2.5f);
            PickUpManager.audioSrc.PlayOneShot(bossTalk[10]);
        }


    }

    private void UpSound()
    {
        PickUpManager.audioSrc.PlayOneShot(levelup);
    }
    private void PopSound()
    {
        PickUpManager.audioSrc.PlayOneShot(popup);
    }
    /*
    void BossTalkStart()
    {
        StartCoroutine(_typing(textOrder));
    }*/

    IEnumerator _typing(int a)
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i <= b_text[a].Length; i++)
        {
            bossText.text = b_text[a].Substring(0, i);
            yield return new WaitForSeconds(0.07f);
        }
    }

    public void CloseBtn()//팝업 닫기 버튼
    {
        //CountPopup.SetActive(false);
        //LevelPopup.SetActive(false);
        //ShowBoss();
    }

    public void BossBtn()//사장님 끝인사 패널 버튼
    {
        if(textOrder == 2)
        {
            //토스트튜토리얼로 이동
            SceneManager.LoadScene("T_BasicToast");
        }
        else
        {
            SceneManager.LoadScene("LevelMap");
        }
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(1.0f);
    }
}
