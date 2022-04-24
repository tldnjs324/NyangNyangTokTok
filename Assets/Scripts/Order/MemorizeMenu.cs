using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MemorizeMenu : MonoBehaviour
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

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        nextButton_1.SetActive(false);
        //memorizePanel.SetActive(false);
        retryBtn.SetActive(false);
        timeCountImg.SetActive(false);

        Invoke("PanelStart", 0f);
        Invoke("TimeEnd", 20f); 
    }
    
    void Update()
    {
        
    }

    void PanelStart()
    {
        //memorizePanel.SetActive(true);
        timeCountImg.SetActive(true);

        if(GameManager.OrderMenu3.Length > 2 && GameManager.OrderMenu4.Length < 2) //문자열 길이로 메뉴개수 판단
        {
            memoText.text = GameManager.OrderMenu1 + "\n" + GameManager.OrderMenu2
                + "\n" + GameManager.OrderMenu3;
        }else if(GameManager.OrderMenu4.Length > 2)
        {
            memoText.text = GameManager.OrderMenu1 + "\n" + GameManager.OrderMenu2
                + "\n" + GameManager.OrderMenu3 + "\n" + GameManager.OrderMenu4;
        }
        else
        {
            memoText.text = GameManager.OrderMenu1 + "\n" + GameManager.OrderMenu2;
        }
        
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
        //timeCountImg.GetComponent<Image>().fillAmount -= 0.05f;
        --time;
        timeCounting.text = time.ToString();
    }
    public void NextBtn()
    {
        audioSrc.PlayOneShot(click, 0.5f);

        if (GameManager.coffeeCount > 0)
        {
            SceneManager.LoadScene("OrderMenu"); //커피 고르기씬
        }
        else if(GameManager.coffeeCount == 0 && GameManager.toastCount > 0)
        {
            SceneManager.LoadScene("OrderToast");
        }
        
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
