using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public AudioClip click;
    AudioSource audioSrc;

    public Text bossText;
    public Text talkText;
    public GameObject bossPanel;
    public GameObject talkPanel; //나비
    public GameObject startPopup;
    public GameObject boss;
    public GameObject cat1;
   
    public static string OrderMenu1 = "";
    public static string OrderMenu2 = "";

    public static int coffeeCount;
    public static int cubeCount;

    private string m_text;
    private string[] m = new string[4];
    private string[] m_ = { "주", "세", "요", "냥", "~" };

    int i = 0;

    public AudioClip[] bossVoice;
    //나비 목소리
    public AudioClip[] NaviVoice;

    public void BossTalk(int a)
    {
        audioSrc.PlayOneShot(bossVoice[a]);
    }
    public void NaviTalk1()
    {
        audioSrc.PlayOneShot(NaviVoice[0]);
    }
    public void NaviTalk2()
    {
        audioSrc.PlayOneShot(NaviVoice[1]);
    }
    public void NaviTalk3()
    {
        audioSrc.PlayOneShot(NaviVoice[2]);
    }

    void Start()
    {

        audioSrc = GetComponent<AudioSource>();
        OrderMenu1 = "아이스 아메리카노";
        ++coffeeCount;
        OrderMenu2 = "3구 큐브케이크";
        ++cubeCount;

        Invoke("BossShowUp", 1f);

    }
    void BossShowUp()
    {
        boss.SetActive(true);
        Invoke("BossTalk", 1f);
    }

    public void BossTalk()
    {
        if (i == 0)
        {
            m_text = "반가워요~ 오늘부터 당신은 우리 카페의 '수습 알바생'이에요!";
            audioSrc.PlayOneShot(bossVoice[0]);
            StartMethod();
            i++;
        }
        else if (i == 1)
        {
            StopMethod();
            m_text = "주문을 받고 메뉴를 만드는 과정까지 내가 도와줄테니 잘 보고 따라해주세요~";
            audioSrc.Stop();
            audioSrc.PlayOneShot(bossVoice[1]);
            StartMethod();
            i++;
        }
        else if (i == 2)
        {
            audioSrc.Stop();
            audioSrc.PlayOneShot(click, 0.5f);
            StopMethod();
            boss.SetActive(false);
            bossPanel.SetActive(false);
            Popup pop = startPopup.GetComponent<Popup>();
            pop.PopUp();

            
        }
    }
    public void PopupBtn()
    {
        talkPanel.SetActive(true);
        cat1.SetActive(true);
        Invoke("CatTalk", 1f); //추후 음성에 맞게 초 수정
        Invoke("NaviTalk1", 1);
        Invoke("NaviTalk2", 2.2f);
        Invoke("NaviTalk3", 3.4f);
        i = 0;
    }
    void CatTalk()
    {
        m[0] = "<color=#d85b00>" + OrderMenu1 + "</color>" + ", " ;
        m[1] = "<color=#d85b00>" + OrderMenu2 + "</color>";
        StartCoroutine(_typing2());
    }


    IEnumerator _typing()
    {
        yield return new WaitForSeconds(0f);
        for(int i=0; i<= m_text.Length; i++)
        {
            bossText.text = m_text.Substring(0, i);
            yield return new WaitForSeconds(0.07f);
        }
    }
    IEnumerator _typing2()
    {
        yield return new WaitForSeconds(0f);
        for (int i = 0; i < 4; i++)
        {
            talkText.text += m[i];
            yield return new WaitForSeconds(0.3f);
        }
        for (int i = 0; i < 5; i++)
        {
            talkText.text += m_[i];
            yield return new WaitForSeconds(0.07f);
        }
    }

    IEnumerator coroutine;
    void StartMethod()
    {
        coroutine = _typing();
        StartCoroutine(coroutine);
    }
    void StopMethod()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    public void SceneMove()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        SceneManager.LoadScene("T_MemorizeMenu");
    }
}
