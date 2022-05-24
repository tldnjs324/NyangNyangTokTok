using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PickUpManager : MonoBehaviour
{
    public static AudioSource audioSrc;

    public Text playerText;
    public Text bossText;
    public Text[] talkText;//나비 냐옹 나비 텍스트
    public GameObject playerPanel;
    public GameObject bossPanel;
    public GameObject[] talkPanel; //나비 냐옹 체리 말하는 패널
    
    public GameObject[] nextButton;//첫번째 대사 넘어갈 때 버튼
    public GameObject[] nextButton2;//두번째 패널에 있는 다음 버튼

    public GameObject p_nextButton;

    public GameObject big_counter;
    public GameObject big_background;
    public GameObject counter;

    public GameObject boss;
    public GameObject[] cat; //나비 냐옹 체리

    //나비 대사
    private string[] m_text = { "와 너무 맛있겠다냥!\n", "덕분에 행복해졌다냥!\n좋은 하루 되시라냥~!" };
    private string[] thanktext = { "이 집 커피향이 참 좋다냥~!", "알록달록한 케이크가 먹음직스럽다냥~!", "저번에 왔을 때 보다 더 잘 만들어줬다냥~!", "토스트가 너무 귀엽다냥~!", "많이 시켰는데 고생 많았다냥~!" };
    public AudioClip[] naviThank;
    //냐옹 대사
    private string[] m2_text = { "우와 맛있어 보인다냥!\n", "맛있게 만들어줘서 고맙다냥!\n좋은 하루 되시라냥~!" };
    private string[] thank2text = { "군침이 삭 돈다냥! 역시 커피는 여기가 최고라냥!", "내 동년배 고양이들은 모두 여기 카페만 온다냥!"};
    public AudioClip[] nyaongThank;
    //체리 대사
    private string[] m3_text = { "꺄 얼른 먹고싶다냥!\n", "덕분에 기분이 좋아졌다냥!\n좋은 하루 되시라냥~!" };
    private string[] thank3text = { "깊고 진한 커피향에 취한다냥~!", "체리 취향에 딱 맞을 것 같다냥~!"};
    public AudioClip[] cherryThank;

    private string p_text = "주문하신 메뉴 나왔습니다~!\n";
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
        PlayerTalkStart();

    }
    
    void Update()
    {

    }
    public void P_NextBtn()
    {
        playerPanel.SetActive(false);
        big_background.SetActive(false);
        counter.SetActive(true);
        big_counter.SetActive(false);
        talkPanel[GameManager.random].SetActive(true);
        Invoke("CatShowUp", 1f);
    }
    void CatShowUp()
    {
        cat[GameManager.random].SetActive(true);
        if(GameManager.random == 0)
        {
            Invoke("CatTalkStart", 1f);
        }else if (GameManager.random == 1)
        {
            Invoke("Cat2TalkStart", 1f);
        }else if (GameManager.random == 2)
        {
            Invoke("Cat3TalkStart", 1f);
        }

    }
    //나비
    void CatTalkStart()
    {
        first_text = Random.Range(0, 2);
        yes_coffee_text = Random.Range(0, 3);
        low_no_coffee_text = Random.Range(1, 4);
        high_no_coffee_text = Random.Range(1, 5);

        audioSrc.PlayOneShot(naviThank[0]);

        if (GameManager.currentLevel == 1)//1단계
        {
            m_text[0] += thanktext[first_text];

            StartCoroutine(catsTalking(first_text + 3));
            //catsTalking(first_text+3);
        }else if(GameManager.currentLevel == 2)//2단계
        {
            if (SpecifyNumber.MakingMenu[0] <= 7)//커피 메뉴를 시켰을 때 
            {
                m_text[0] += thanktext[yes_coffee_text];
                StartCoroutine(catsTalking(yes_coffee_text + 3));
                //catsTalking(yes_coffee_text + 3);
            }
            else//토스트랑 큐브만 있을 때
            {
                m_text[0] += thanktext[low_no_coffee_text];
                StartCoroutine(catsTalking(low_no_coffee_text + 3));
                //catsTalking(low_no_coffee_text + 3);
            }
        }
        else//3,4,5단계
        {
            if (SpecifyNumber.MakingMenu[0] <= 7)//커피 메뉴를 시켰을 때 
            {
                m_text[0] += thanktext[yes_coffee_text];
                StartCoroutine(catsTalking(yes_coffee_text + 3));
                //catsTalking(yes_coffee_text + 3);
            }
            else//토스트랑 큐브만 있을 때
            {
                m_text[0] += thanktext[high_no_coffee_text];
                StartCoroutine(catsTalking(high_no_coffee_text + 3));
                //catsTalking(high_no_coffee_text + 3);
            }
        }
        StopMethod();
        StartMethod(0);
        //StartCoroutine(_typing(0));
    }
    //냐옹
    void Cat2TalkStart()
    {
        int coffee = Random.Range(0, 2);

        audioSrc.PlayOneShot(nyaongThank[0]);

        if (SpecifyNumber.MakingMenu[0] <= 7)//커피 메뉴를 시켰을 때 
        {
            m2_text[0] += thank2text[coffee];
            StartCoroutine(catsTalking(coffee + 3));
            //catsTalking(coffee + 3);
        }
        else//토스트랑 큐브만 있을 때
        {
            m2_text[0] += thank2text[1];
            StartCoroutine(catsTalking(4));
            //catsTalking(4);
        }

        StopMethod();
        StartMethod(0);
    }
    //체리
    void Cat3TalkStart()
    {
        int coffee = Random.Range(0, 2);

        audioSrc.PlayOneShot(cherryThank[0]);

        if (SpecifyNumber.MakingMenu[0] <= 7)//커피 메뉴를 시켰을 때 
        {
            m3_text[0] += thank3text[coffee];
            StartCoroutine(catsTalking(coffee + 3));
            //catsTalking(coffee + 3);
        }
        else//토스트랑 큐브만 있을 때
        {
            m3_text[0] += thank3text[1];
            StartCoroutine(catsTalking(4));
            //catsTalking(4);
        }

        StopMethod();
        StartMethod(0);
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
        
        StartCoroutine(_typing2());//
    }


    public void NextTalk()
    {
        StopMethod();
        StartMethod(1);
        //나비, 냐옹, 체리 두번째 패널 대사
        StartCoroutine(catsTalking2());

        nextButton[GameManager.random].SetActive(false);
        nextButton2[GameManager.random].SetActive(true);
    }

    //고양이들 랜덤 대사 말하기(첫번째 패널)
    IEnumerator catsTalking(int x)
    {
        //나비
        if(GameManager.random == 0)
        {
            yield return new WaitForSeconds(1.7f);
            audioSrc.PlayOneShot(naviThank[x]);
        }
        //냐옹
        if (GameManager.random == 1)
        {
            yield return new WaitForSeconds(1.7f);
            audioSrc.PlayOneShot(nyaongThank[x]);
        }
        //체리
        if (GameManager.random == 2)
        {
            yield return new WaitForSeconds(1.9f);
            audioSrc.PlayOneShot(cherryThank[x]);
        }
    }

    //고양이들 대사 말하기(두번째 패널
    IEnumerator catsTalking2()
    {
        yield return new WaitForSeconds(0f);
        //첫번째 대사
        //나비
        if (GameManager.random == 0)
        {
            audioSrc.PlayOneShot(naviThank[1]);
            yield return new WaitForSeconds(1.5f);
        }
        //냐옹
        if (GameManager.random == 1)
        {
            audioSrc.PlayOneShot(nyaongThank[1]);
            yield return new WaitForSeconds(1.8f);
        }
        //체리
        if (GameManager.random == 2)
        {
            audioSrc.PlayOneShot(cherryThank[1]);
            yield return new WaitForSeconds(1.8f);
        }
        //두번째 대사
        //나비
        if (GameManager.random == 0)
        {
            audioSrc.PlayOneShot(naviThank[2]);
        }
        //냐옹
        if (GameManager.random == 1)
        {
            audioSrc.PlayOneShot(nyaongThank[2]);
        }
        //체리
        if (GameManager.random == 2)
        {
            audioSrc.PlayOneShot(cherryThank[2]);
        }
    }
    IEnumerator _typing(int x)
    {
        yield return new WaitForSeconds(0f);
        if(GameManager.random == 0)
        {
            for (int i = 0; i <= m_text[x].Length; i++)
            {
                talkText[0].text = m_text[x].Substring(0, i);
                yield return new WaitForSeconds(0.07f);
            }
        }else if (GameManager.random == 1)
        {
            for (int i = 0; i <= m2_text[x].Length; i++)
            {
                talkText[1].text = m2_text[x].Substring(0, i);
                yield return new WaitForSeconds(0.07f);
            }
        }else if (GameManager.random == 2)
        {
            for (int i = 0; i <= m3_text[x].Length; i++)
            {
                talkText[2].text = m3_text[x].Substring(0, i);
                yield return new WaitForSeconds(0.07f);
            }
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

    IEnumerator coroutine;
    void StartMethod(int x)
    {
        coroutine = _typing(x);
        StartCoroutine(coroutine);
    }
    void StopMethod()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }
}
