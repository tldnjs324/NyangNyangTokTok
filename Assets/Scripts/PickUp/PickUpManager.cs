using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PickUpManager : MonoBehaviour
{
    public AudioClip click;
    AudioSource audioSrc;

    public Text playerText;
    public Text bossText;
    public Text talkText;
    public GameObject playerPanel;
    public GameObject bossPanel;
    public GameObject talkPanel; //나비
    
    public GameObject nextButton;
    public GameObject nextButton2;

    public GameObject p_nextButton;

    public GameObject big_counter;
    public GameObject big_background;

    public GameObject boss;
    public GameObject cat1;
    //private string[] cats = { "cat1", "cat2", "cat3" }; //여러 마리의 고양이 캐릭터 예정

    private string[] m_text = { "와 너무 맛있겠다냥!\n", "덕분에 행복해졌다냥!\n좋은 하루 되시라냥~!" };

    private string[] thanktext = { "이 집 커피향이 참 좋다냥~!", "알록달록한 케이크가 먹음직스럽다냥~!", "저번에 왔을 때 보다 더 잘 만들어줬다냥~!", "토스트가 너무 귀엽다냥~!", "많이 시켰는데 고생 많았다냥~!" };

    private string p_text = "주문하신 메뉴 나왔습니다 :)\n";
    private string[] watchout_text = { "커피가 뜨거우니 젤리를 조심하세요!", "케이크를 조심히 들고가세요!", "토스트가 뜨거우니 젤리를 조심하세요!" };

    private int first_text;//1단계 랜덤값
    private int yes_coffee_text;//커피 있을 때 랜덤값
    private int low_no_coffee_text;//낮은 레벨에서 커피 없을 때
    private int high_no_coffee_text;//높은 레벨에서 커피 없을 때

    private int p_coffee_text;
    private int p_noncoffee_text;

    void Start()
    {

        audioSrc = GetComponent<AudioSource>();
        //this.animator = GetComponent<Animation>().speed = 0.0f;

        //Invoke("CatShowUp", 1f);
        PlayerTalkStart();

    }
    
    void Update()
    {

    }
    public void P_NextBtn()
    {
        playerPanel.SetActive(false);
        big_background.SetActive(false);
        big_counter.SetActive(false);
        talkPanel.SetActive(true);
        Invoke("CatShowUp", 1f);
    }
    void CatShowUp()
    {
        cat1.SetActive(true);
        Invoke("CatTalkStart", 1f);
    }
    void CatTalkStart()
    {
        /*
        playerPanel.SetActive(false);
        big_background.SetActive(false);
        big_counter.SetActive(false);

        talkPanel.SetActive(true);*/
        first_text = Random.Range(0, 2)
;       yes_coffee_text = Random.Range(0, 3);
        low_no_coffee_text = Random.Range(1, 4);
        high_no_coffee_text = Random.Range(1, 5);
        if (GameManager.currentLevel == 1)//1단계
        {
            m_text[0] += thanktext[first_text];
        }else if(GameManager.currentLevel == 2)//2단계
        {
            if (SpecifyNumber.MakingMenu[0] <= 7)//커피 메뉴를 시켰을 때 
            {
                m_text[0] += thanktext[yes_coffee_text];
            }
            else//토스트랑 큐브만 있을 때
            {
                m_text[0] += thanktext[low_no_coffee_text];
            }
        }
        else//3,4,5단계
        {
            if (SpecifyNumber.MakingMenu[0] <= 7)//커피 메뉴를 시켰을 때 
            {
                m_text[0] += thanktext[yes_coffee_text];
            }
            else//토스트랑 큐브만 있을 때
            {
                m_text[0] += thanktext[high_no_coffee_text];
            }
        }

        StartCoroutine(_typing(0));
    }
    void PlayerTalkStart()
    {
        p_coffee_text = Random.Range(0, 2);
        p_noncoffee_text = Random.Range(1, 3);

        if (SpecifyNumber.MakingMenu[0] <= 7)//커피 메뉴를 시켰을 때 
        {
            if (SpecifyNumber.MakingMenu[0] % 2 == 0 || SpecifyNumber.MakingMenu[1] % 2 == 0)//커피가 뜨거울 때
            {
                p_text += watchout_text[p_coffee_text];
            }
            else//차가운 커피만 있을 때
            {
                p_text += "잔이 미끄러우니 젤리로 꼭 붙드세요!";
            }
        }
        else//토스트랑 큐브만 있을 때
        {
            p_text += watchout_text[p_noncoffee_text];
        }
        StartCoroutine(_typing2());
    }

    void CatTalkStart2()
    {

    }

    public void NextTalk()
    {
        StartCoroutine(_typing(1));
        nextButton.SetActive(false);
        nextButton2.SetActive(true);
    }

    public void Ending()
    {
        //틀리거나, 맞았거나, 맞아서 레벨 높아지는거 나누는 코드
    }


    public void ShowBoss()
    {
        audioSrc.PlayOneShot(click, 0.5f); 

        cat1.SetActive(false);
        talkPanel.SetActive(false);
        bossPanel.SetActive(true);
        boss.SetActive(true);
        Invoke("BossTalkStart", 1f); //추후 음성에 맞게 초 수정
    }



    IEnumerator _typing(int x)
    {
        yield return new WaitForSeconds(0f);
        for (int i=0; i<= m_text[x].Length; i++)
        {
            talkText.text = m_text[x].Substring(0, i);
            yield return new WaitForSeconds(0.07f);
        }
    }
    IEnumerator _typing2()
    {
        yield return new WaitForSeconds(0f);
        for (int i = 0; i <= p_text.Length; i++)
        {
            playerText.text = p_text.Substring(0, i);
            yield return new WaitForSeconds(0.07f);
        }
    }


}
