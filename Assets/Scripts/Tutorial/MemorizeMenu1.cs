using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MemorizeMenu1 : MonoBehaviour
{
    public GameObject memorizePanel;
    public Text memoText; //"외울 메뉴"
    public GameObject memoText_1;
    public GameObject timeCountImg;
    public Text timeCounting;
    public int time = 20;
    public Button nextButton; 
    public GameObject nextButton_1;
    public GameObject retryBtn;

    public AudioClip click;
    public AudioClip popup;
    AudioSource audioSrc;

    public Text bossText;
    public GameObject bossPanel;
    public GameObject boss;
    private string m_text;
    int i = 0;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        nextButton_1.SetActive(false);
        retryBtn.SetActive(false);
        timeCountImg.SetActive(false);

        Invoke("BossTalk", 1f);
        
    }
    public void BossTalk()
    {
        if (i == 0)
        {
            m_text = "주문이 들어왔네요! 이제 주문 받은 메뉴들을 20초 동안 외워주세요~";
            StartMethod();
            i++;
        }
        else if (i == 1)
        {
            StopMethod();
            m_text = "20초가 지나더라도 다시 메뉴를 확인할 수 있으니 부담은 가지지 말아요~";
            StartMethod();
            i++;
        }
        else if (i == 2)
        {
            boss.SetActive(false);
            bossPanel.SetActive(false);
            Invoke("PanelStart", 1f);
            Invoke("TimeEnd", 20f);
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

    void PanelStart()
    {
        timeCountImg.SetActive(true);
        memoText.text = GameManager1.OrderMenu1 + "\n" + GameManager1.OrderMenu2;
        
        nextButton_1.SetActive(true);
        InvokeRepeating("TimeCount", 1f, 1f);
    }
    void TimeEnd()
    {
        memoText_1.SetActive(false);
        time = 20;
        CancelInvoke("TimeCount");
        retryBtn.SetActive(true);
    }
    public void RetryBtn()
    {
        audioSrc.PlayOneShot(click, 0.5f);

        retryBtn.SetActive(false);
        memoText_1.SetActive(true);

        InvokeRepeating("TimeCount", 1f, 1f);
        Invoke("TimeEnd", 20f); 
    }
    void TimeCount()
    {
        --time;
        timeCounting.text = time.ToString();
    }
    public void NextBtn()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        SceneManager.LoadScene("T_OrderMenu");     
    }
    
    public void ClickSound()
    {
        audioSrc.PlayOneShot(click, 0.5f);
    }
    public void PopupSound()
    {
        audioSrc.PlayOneShot(popup, 0.5f);
    }
}
