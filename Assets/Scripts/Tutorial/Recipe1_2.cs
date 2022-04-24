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
    public Sprite[] sprites = new Sprite[4];

    public GameObject[] hintArrows = new GameObject[5];
    public GameObject popupCorrect;
    public GameObject popupWrong;
    public GameObject popupHelp;
    public GameObject popupBoss;
    public GameObject popupRecipe;
    public GameObject popupName;
    public GameObject coffeeShot;

    public Text bossText;
    public GameObject bossPanel;
    public GameObject boss;
    private string m_text;
    public GameObject focus1;
    public GameObject focus2;
    int t_i = 0;
    //int t_cnt = 0;

    void Start()
    {
        ClickedRecipe = "";
        Invoke("BossTalk", 1f);
    }
    public void BossTalk()
    {
        if (t_i == 0)
        {
            m_text = "지금부턴 주문받은 메뉴를 만들어 볼 차례예요. 먼저 '아이스 아메리카노'부터 만들어 주세요!";
            StartMethod();
            t_i++;
        }
        else if (t_i == 1)
        {
            boss.SetActive(false);
            bossPanel.SetActive(false);
            StopMethod();
            Show_Name();
        }
        else if (t_i == 2)
        {
            StopMethod();
            bossPanel.SetActive(false);
            Invoke("PanelStart", 1f);  
            t_i++;
        }
        else if (t_i == 3)
        {
            CancelInvoke("TimeCount");
            CancelInvoke("TimeEnd");
            boss.SetActive(true);
            bossPanel.SetActive(true);
            m_text = "이제 외운 레시피 순서대로 재료를 선택해야 돼요!";
            StartMethod();
            t_i++;
        }
        else if( t_i == 4)
        {
            StopMethod();
            boss.SetActive(false);
            focus2.SetActive(true);
            m_text = "기억이 잘 나지 않을 땐 언제든 도움말 버튼을 눌러 레시피를 다시 볼 수 있답니다~";
            StartMethod();
            t_i++;
        }
        else if (t_i == 5)
        {
            StopMethod();
            focus2.SetActive(false);
            boss.SetActive(true);
            bossPanel.SetActive(true);
            m_text = "우선 첫 번째 재료인 '얼음'부터 클릭해 컵에 담아주세요~";
            StartMethod();
            t_i++;
        }
        else if (t_i == 6)
        {
            StopMethod();
            m_text = "";
            StartMethod();
            boss.SetActive(false);
            bossPanel.SetActive(false);
            t_i++;
        }
        else if (t_i == 7)
        {
            t_i++;
            StopMethod();
            m_text = "이제 남은 재료들도 순서대로 클릭해주세요!";
            StartMethod();
            bossPanel.SetActive(true);
            boss.SetActive(true);     
            
        }
        else if (t_i == 8)
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
            Invoke("Correct", 1.5f);         
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
        popupRecipe.SetActive(false);
        BossTalk();
        t_i++;
    }

    public void RecipeClickedBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        ClickedRecipe = clickObject.GetComponentInChildren<Text>().text;
        _list.Add(ClickedRecipe);

       
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
                    Invoke("BossTalk", 1.5f);
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
    }
    public void Show_Name()
    {
        popupName.SetActive(true);
    }
    public void Show_Recipe()
    {
        popupName.SetActive(false);
        popupRecipe.SetActive(true);
        bossPanel.SetActive(true);
        m_text = "아이스 아메리카노를 만드는 레시피예요! 레시피를 순서대로 20초 동안 외워주세요~";
        StartMethod();
        t_i++;

        
    }
    public void Help_Click()
    {
        popupHelp.SetActive(true);
        hintArrows[0].SetActive(false);

        focus2.SetActive(false);
        boss.SetActive(false);
        bossPanel.SetActive(false);
    }
    public void Correct()
    {
        popupCorrect.SetActive(true);
    }

    public void NextBtn()
    {
        //audioSrc.PlayOneShot(click, 0.5f);
        SceneManager.LoadScene("T_PickUp");
    }
}
