using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Recipe1_2 : MonoBehaviour
{
    string ClickedRecipe;
    public string[] iceAmericano = { "얼음", "물", "커피머신", "샷" };

    public List<string> _list = new List<string>();
    int i = 0;
    int wrongCnt = 0;
    int cnt = 0;
    public Text timeCounting;
    public int time = 20;

    public Image img;
    public GameObject cup;
    public Sprite[] sprites = new Sprite[4];
    public GameObject btnMachine;
    public Sprite sprite1; //커피 내리는중
    public Sprite sprite2; //원상태로

    public GameObject[] hintArrows = new GameObject[5];
    public GameObject popupCorrect;
    public GameObject popupWrong;
    public GameObject popupHelp;
    public GameObject popupBoss;
    public GameObject popupStart;
    public GameObject coffeeShot;

    //private IEnumerator coroutine;
    public GameObject hint;

    public GameObject recipeSlider;
    public ParticleSystem particle; //컵용
    public ParticleSystem particleBasic; //항상
    public ParticleSystem particleHeart; //하트

    public Text bossText;
    public GameObject bossPanel;
    public GameObject boss;
    private string m_text;
    public GameObject focus1;
    public GameObject focus2;
    int t_i = 0;
    //int t_cnt = 0;

    //효과음
    public AudioClip[] click;
    AudioSource audioSrc;
    //효과음 나오게 하기
    public void ClickSound(int x)
    {
        audioSrc.PlayOneShot(click[x]);
    }

    void Start()
    {
        ClickedRecipe = "";
        Invoke("StartPopup", 0.5f);
        //Invoke("BossTalk", 1f);
        audioSrc = GetComponent<AudioSource>();
    }
    void StartPopup()
    {
        Popup pop = popupStart.GetComponent<Popup>();
        pop.PopUp2();
    }
    public void Interval()
    {
        Invoke("BossTalk", 0.8f);
    }
    public void BossTalk()
    {
        if (t_i == 0)
        {
            CancelInvoke("TimeCount");
            CancelInvoke("TimeEnd");
            boss.SetActive(true);
            bossPanel.SetActive(true);
            m_text = "지금부턴 주문받은 메뉴를 만들어 볼 차례예요. 먼저 '아이스 아메리카노'부터 만들어 주세요!";
            StartMethod();
            t_i++;
        }
        else if (t_i == 1)
        {
            StopMethod();
            m_text = "이제 외운 레시피 순서대로 재료를 선택해야 돼요!";
            StartMethod();
            t_i++;
        }
        else if (t_i == 2)
        {
            StopMethod();
            m_text = "기억이 잘 나지 않을 땐 언제든 도움말 버튼을 눌러 레시피를 다시 볼 수 있답니다~";
            StartMethod();
            t_i++;
        }
        else if (t_i == 3)
        {
            StopMethod();
            m_text = "우선 첫 번째 재료인 '얼음'부터 클릭해 컵에 담아주세요~";
            StartMethod();
            t_i++;
        }
        else if( t_i == 4)
        {
            StopMethod();
            m_text = "";
            StartMethod();
            boss.SetActive(false);
            bossPanel.SetActive(false);
            t_i++;
        }
        else if (t_i == 5)
        {
            t_i++;
            StopMethod();
            m_text = "이제 남은 재료들도 순서대로 클릭해주세요!";
            StartMethod();
            bossPanel.SetActive(true);
            boss.SetActive(true);
        }
        else if (t_i == 6)
        {
            StopMethod();
            boss.SetActive(false);
            bossPanel.SetActive(false);
        }

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

    private void Update()
    {
        if (i != 0 && i == cnt)
        {
            Invoke("Correct", 1.0f);
            recipeSlider.GetComponent<Image>().fillAmount = 1f;
        }
    }
    IEnumerator HintActive()
    {
        while (true)
        {
            hint.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.7f);

            hint.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.7f);
        }

    }
    void PanelStart()
    {
        InvokeRepeating("TimeCount", 0f, 1f);
        Invoke("TimeEnd", 20f);
    }
    void TimeCount()
    {
        --time;
        timeCounting.text = time.ToString();
    }
    void TimeEnd()
    {
        CancelInvoke("TimeCount");
       
        //popupRecipe.SetActive(false);
        popupStart.GetComponent<Animator>().SetTrigger("sclose");
        Invoke("BossTalk", 0.8f);
        //BossTalk();
        //t_i++;
    }
    void BtnReScale()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        clickObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1); //원래대로
    }
    void CupReScale()
    {
        RectTransform rectTran = cup.GetComponent<RectTransform>();
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 310);
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 310); //원래대로
    }
    void BtnImgChange()
    {
        btnMachine.GetComponent<Image>().sprite = sprite2; //샷 추출완료
        coffeeShot.SetActive(true); //샷 생성
    }
    void BtnShot()
    {
        coffeeShot.SetActive(false);
    }
    public void RecipeClickedBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        ClickedRecipe = clickObject.GetComponentInChildren<Text>().text;
        _list.Add(ClickedRecipe);

        cnt = 4;
        if (_list[i] == iceAmericano[i])
        {
            img.sprite = sprites[i]; //이미지 변경
            if (i == 0)//얼음
            {
                audioSrc.PlayOneShot(click[5]);
            }
            if (i == 1)//물
            {
                audioSrc.PlayOneShot(click[6]);
            }
            if (i == 2)//커피머신
            {
                audioSrc.PlayOneShot(click[7]);
            }
            if (i == 3)//샷
            {
                audioSrc.PlayOneShot(click[10]);
            }
            i++;
            recipeSlider.GetComponent<Image>().fillAmount += 0.25f; //4개용
            hintArrows[0].SetActive(false);
            StopCoroutine(coroutine);
            hintArrows[i].SetActive(false);
            wrongCnt = 0;

            if (i == 1)
            {
                Invoke("BossTalk", 1.0f);
            }
            if (i != 3)
            {
                if (i != 4)
                {
                    particleBasic.Play();
                }
                RectTransform rectTran = cup.GetComponent<RectTransform>();
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350);
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 350); //컵 커지게
                Invoke("CupReScale", 0.1f);
            }
            if (i == 3)
            {
                btnMachine.GetComponent<Image>().sprite = sprite1; //커피잔 머신위에
                Invoke("BtnImgChange", 0.8f);
            }
            if (i == 4)
            {
                Invoke("BtnShot", 0.3f);
                particle.Play(); //완성파티클
                Invoke("CorrectSound", 1f);//1초 뒤 정답 효과음
                particleHeart.Play();
            }
        }
        else
        {
            _list.RemoveAt(i);
            wrongCnt++;
            audioSrc.PlayOneShot(click[3]);//오답 효과음
            hintArrows[0].SetActive(false);
            StopCoroutine(coroutine);
            if (wrongCnt == 1)
            {
                Popup pop = popupWrong.GetComponent<Popup>();
                pop.PopUp();
                MoveLevel.wrongCount += 1;
            }
            else if (wrongCnt == 2)
            {
                Popup pop = popupWrong.GetComponent<Popup>();
                pop.PopUp();
                hintArrows[0].SetActive(true); //도움말힌트강조
                StartCoroutine(coroutine);
            }
            else if (wrongCnt == 3)
            {
                Popup pop = popupBoss.GetComponent<Popup>();
                pop.PopUp();
                hintArrows[i + 1].SetActive(true); //재료를 알려줌
            }
        }

        /*
         if (SceneManager.GetActiveScene().name == "T_IceAmericano") //아이스아메리카노
         {
             cnt = 4;

             if (_list[i] == iceAmericano[i])
             {
                 img.sprite = sprites[i]; //이미지 변경
                 i++;
                 hintArrows[i].SetActive(false);
                 wrongCnt = 0;

                 if (i == 1)
                 {
                     Invoke("BossTalk", 1.0f);
                 }

                 if (i == 3)
                 {
                     coffeeShot.SetActive(true); //샷 생성
                 }
                 if (i == 4)
                 {
                     coffeeShot.SetActive(false);
                 }
             }
             else
             {
                 _list.RemoveAt(i);
                 wrongCnt++;
                 hintArrows[0].SetActive(false);
                 if (wrongCnt == 1)
                 {
                     popupWrong.SetActive(true);
                     MoveLevel.wrongCount += 1;
                 }
                 else if (wrongCnt == 2)
                 {
                     popupWrong.SetActive(true);
                     hintArrows[0].SetActive(true); //도움말힌트강조
                 }
                 else if (wrongCnt == 3)
                 {
                     popupBoss.SetActive(true);
                     hintArrows[i + 1].SetActive(true); //재료를 알려줌
                 }
             }
         }
         */
    }
    public void Show_Name()
    {
        //popupName.SetActive(true);
    }
    public void Show_Recipe()
    {
        //popupName.SetActive(false);
        //popupRecipe.SetActive(true);
        //bossPanel.SetActive(true);
        //m_text = "아이스 아메리카노를 만드는 레시피예요! 레시피를 순서대로 20초 동안 외워주세요~";
        //StartMethod();
        //t_i++;
        Invoke("PanelStart", 1f);

    }
    public void Help_Click()
    {
        Popup pop = popupHelp.GetComponent<Popup>();
        audioSrc.PlayOneShot(click[0]);
        pop.PopUp();
        hintArrows[0].SetActive(false);

        focus2.SetActive(false);
        boss.SetActive(false);
        bossPanel.SetActive(false);
    }
    public void Correct()
    {
        Popup pop = popupCorrect.GetComponent<Popup>();
        pop.PopUp();
    }
    public void CorrectSound()
    {
        audioSrc.PlayOneShot(click[2]);//정답 효과음
    }

    public void NextBtn()
    {
        //audioSrc.PlayOneShot(click, 0.5f);
        SceneManager.LoadScene("T_3CubeCakeScene1");
    }
}
