using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public AudioClip click;
    AudioSource audioSrc;

    public Text bossText;
    public Text talkText;
    public GameObject bossPanel;
    public GameObject talkPanel; //나비

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
        Invoke("BossTalkStart", 1f);
    }
    void BossTalkStart()
    {
        m_text = "반가워요~ 오늘부터 당신은 우리 카페의 수습 알바생이에요!";
        StartCoroutine(_typing());
    }
    public void NextBtn()
    {
        if (i == 0)
        {
            m_text = "주문을 받고 메뉴를 만드는 과정까지 내가 도와줄테니 잘 보고 따라해주세요~";
            StartCoroutine(_typing());
            i++;
        }else if (i == 1)
        {
            audioSrc.PlayOneShot(click, 0.5f);

            boss.SetActive(false);
            bossPanel.SetActive(false);
            talkPanel.SetActive(true);
            cat1.SetActive(true);
            Invoke("CatTalkStart", 1f); //추후 음성에 맞게 초 수정
        }
       
    }
    void CatTalkStart()
    {
        m[0] = "<color=#d85b00>" + OrderMenu1 + "</color>" + "랑 ";
        m[1] = "<color=#d85b00>" + OrderMenu2 + "</color>";       
        StartCoroutine(_typing2());
    }

    IEnumerator _typing()
    {
        yield return new WaitForSeconds(0f);
        for (int i = 0; i <= m_text.Length; i++)
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
    public void SceneMove()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        SceneManager.LoadScene("MemorizeMenu");
    }
}
