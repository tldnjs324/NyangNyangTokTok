using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Recipe2_2 : MonoBehaviour
{
    string ClickedRecipe;
    public string[] basicToast = { "식빵", "토스트기" };

    public List<string> _list = new List<string>();
    int i = 0;
    int wrongCnt = 0;
    int cnt = 0;
    public Text timeCounting;
    public int time = 20;

    public Image img;
    public GameObject plate;
    public Sprite[] sprites = new Sprite[4];
    public GameObject btnMachine;
    public Sprite sprite; //다 구워짐
    public Sprite sprite1; //구워지는 중간상태
    public Sprite sprite2; //원상태로

    public GameObject[] hintArrows = new GameObject[6];
    public GameObject popupCorrect;
    public GameObject popupWrong;
    public GameObject popupHelp;
    public GameObject popupBoss;
    public GameObject popupStart;

    public GameObject recipeSlider;
    
    public GameObject hint;

    public ParticleSystem particle; //접시에 완성용
    public ParticleSystem particleBasic; //항상
    public ParticleSystem particleHeart; //하트

    public Text bossText;
    public GameObject bossPanel;
    public GameObject boss;
    private string m_text;
    int t_i = 0;

    public AudioClip[] click;
    AudioSource audioSrc;
    //효과음 나오게 하기
    public void ClickSound(int x)
    {
        audioSrc.PlayOneShot(click[x]);
    }

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        ClickedRecipe = "";
        //Invoke("StartPopup", 0.5f);
        Invoke("BossTalk", 1f);
        //Invoke("BossShowUp", 1f);
    }
    void BossShowUp()
    {
        boss.SetActive(true);
        Invoke("BossTalk", 1f);
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
            boss.SetActive(true);
            bossPanel.SetActive(true);
            m_text = "축하해요! 이제 수습기간이 끝나 정식으로 ‘알바생’이 되었어요~";
            StartMethod();
            t_i++;
        }
        else if (t_i == 1)
        {
            StopMethod();
            m_text = "지금까지 메뉴를 너무 잘 만들어줘서 이제 ‘토스트’ 메뉴도 부탁할게요!";
            StartMethod();
            t_i++;
        }
        else if (t_i == 2)
        {
            StopMethod();
            boss.SetActive(false);
            bossPanel.SetActive(false);
            Invoke("StartPopup", 0.5f);
            t_i++;
        }
        else if (t_i == 3)
        {
            StopMethod();
            CancelInvoke("TimeCount");
            CancelInvoke("TimeEnd");
            boss.SetActive(true);
            bossPanel.SetActive(true);
            m_text = "이제 '기본 토스트'를 같이 만들어 볼까요?";
            StartMethod();
            t_i++;
        }
        else if (t_i == 4)
        {
            StopMethod();
            m_text = "외운 레시피 순서대로 재료를 선택해서 토스트를 완성해주세요!";
            StartMethod();
            t_i++;
        }
        else if (t_i == 5)
        {
            StopMethod();
            boss.SetActive(false);
            bossPanel.SetActive(false);
            t_i++;
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
            Invoke("Correct", 1.5f);
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
        popupStart.GetComponent<Animator>().SetTrigger("sclose");
    }

    void BtnReScale()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        clickObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1); //원래대로
    }
    void PlateReScale()
    {
        RectTransform rectTran = plate.GetComponent<RectTransform>();
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1250);
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1250); //그릇 원래대로
    }
    void BtnImgChange()
    {
        btnMachine.GetComponent<Image>().sprite = sprite; //다구워짐
    }

    public void RecipeClickedBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        ClickedRecipe = clickObject.GetComponentInChildren<Text>().text;
        _list.Add(ClickedRecipe);
        clickObject.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1); //클릭시 크기커지게
        Invoke("BtnReScale", 0.1f);

        cnt = 2;
        if (_list[i] == basicToast[i])
        {
            if (i == 0)//빵
            {
                audioSrc.PlayOneShot(click[3]);
            }
            if (i == 1)//토스터
            {
                audioSrc.PlayOneShot(click[4]);
            }
            if (i > 0)
            {
                if (i != cnt - 1)
                {
                    particleBasic.Play();
                }
                img.sprite = sprites[i - 1]; //이미지 변경
                RectTransform rectTran = plate.GetComponent<RectTransform>();
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1350);
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1350); //그릇 커지게
                Invoke("PlateReScale", 0.1f);
            }


            i++;
            recipeSlider.GetComponent<Image>().fillAmount += 0.5f; //2개용
            hintArrows[0].SetActive(false);
            StopCoroutine(coroutine);
            hintArrows[i].SetActive(false);
            wrongCnt = 0;

            if (i == 1)
            {
                btnMachine.GetComponent<Image>().sprite = sprite1; //구워지는 중
                Invoke("BtnImgChange", 0.8f);
                //식빵이 기계에 들어감(버튼 사진 변경)
            }
            if (i == 2)
            {
                btnMachine.GetComponent<Image>().sprite = sprite2;
                particle.Play(); //그릇에 완성파티클
                particleHeart.Play();
                MapManager.secondT = 1;
                Invoke("CorrectSound", 1f);//1초 뒤 정답 효과음
            }
        }
        else
        {
            _list.RemoveAt(i);
            wrongCnt++;
            audioSrc.PlayOneShot(click[2]);//오답 효과음
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

    }
    public void Show_Recipe()
    {
        Invoke("PanelStart", 1f);
    }
    public void Help_Click()
    {
        Popup pop = popupHelp.GetComponent<Popup>();
        audioSrc.PlayOneShot(click[0]);
        pop.PopUp();
        hintArrows[0].SetActive(false);
       
    }
    public void Correct()
    {
        Popup pop = popupCorrect.GetComponent<Popup>();
        pop.PopUp();
        MapManager.secondT = 1;
    }
    public void CorrectSound()
    {
        audioSrc.PlayOneShot(click[2]);//정답 효과음
    }

    public void NextBtn()
    {
        //audioSrc.PlayOneShot(click, 0.5f);
        GameManager.ResetMenu();
        
        SceneManager.LoadScene("Main"); //2단계 정식 시작! (메인으로)
    }
}
