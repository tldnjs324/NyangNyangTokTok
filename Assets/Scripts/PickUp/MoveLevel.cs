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

    public GameObject CountPopup;//카운트가 1,2가 됐을 때 팝업
    public GameObject Count3Popup;//카운트가 3이 됐을 때 팝업
    public GameObject LevelPopup;//레벨 팝업

    private string[] b_text = { "오늘도 고생 많았어요!\n내일도 즐겁게 일해요~!", " 되신걸 축하드려요~!\n앞으로도 같이 재미있게 일해요!",
        "수습기간 끝난거 축하해요!\n이제부터는 알바생님께 토스트도 맡겨볼게요~!", "오랫동안 같이 일해줘서 고마워요~!\n내일도 같이 즐겁게 일해요:)" };
    private static int textOrder = 0;//b_text 나올 숫자 저장
    private string[] position = { "정식 알바생이", "우수 알바생이", "부매니저가", "매니저가"};//직급 저장

    //고양이
    public GameObject talkPanel; //나비
    public GameObject cat1;

    public AudioClip click;
    AudioSource audioSrc;

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

                    //팝업 띄우기
                    Count3Popup.SetActive(true);
                    
                }else if (GameManager.currentLevel == 5){//레벨5인데 또 3개 카운트 채운 경우
                    textOrder = 3;
                    //사장님 나타나서 고맙다는 인사와 함께 계속해달라는 메시지 전하기
                    ShowBoss();
                }
            }
            else//카운트가 1이나 2로 채워졌을 때
            {
                textOrder = 0;
                //팝업 띄우기
                CountPopup.SetActive(true);
            }
        }
        else//한번이라도 틀리면 발자국, 레벨업 없음. 사장님이랑 인사하고 다시 출근하기ㄱㄱ
        {
            textOrder = 0;
            ShowBoss();
        }
        cat1.SetActive(false);
        talkPanel.SetActive(false);
        //PlayerPrefs.Save();//데이터 저장
    }

    //데이터 저장
    public void SaveData()
    {
        PlayerPrefs.SetInt("tmpLevel", GameManager.currentLevel);
        PlayerPrefs.SetInt("tmpCount", GameManager.currentCount);
        PlayerPrefs.SetInt("tmpHeart", GameManager.currentHeart);
        PlayerPrefs.Save();//PlayerPrefs를 저장
    }

    public void ShowBoss()
    {
        Debug.Log("쇼보스 함수 실행");
        //audioSrc.PlayOneShot(click, 0.5f);

        bossPanel.SetActive(true);
        boss.SetActive(true);
        WaitForSeconds();
        //BossTalkStart();
        //StartCoroutine(_typing(textOrder));
        Invoke("BossTalkStart", 1f); //추후 음성에 맞게 초 수정
    }

    // Start is called before the first frame update
    void Start()
    {
    }


    void BossTalkStart()
    {
        StartCoroutine(_typing(textOrder));
    }

    IEnumerator _typing(int a)
    {
        yield return new WaitForSeconds(0f);
        for (int i = 0; i <= b_text[a].Length; i++)
        {
            bossText.text = b_text[a].Substring(0, i);
            yield return new WaitForSeconds(0.07f);
        }
    }

    public void CloseBtn()//팝업 닫기 버튼
    {
        CountPopup.SetActive(false);
        LevelPopup.SetActive(false);
        //ShowBoss();
    }
    public void NextBtn()//팝업 다음버튼
    {
        Count3Popup.SetActive(false);
        LevelPopup.SetActive(true);
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
            SceneManager.LoadScene("Start");
        }
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(1.0f);
    }
}
