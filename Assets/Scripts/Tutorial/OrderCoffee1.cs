using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OrderCoffee1 : MonoBehaviour
{
    string ClickedMenu;
    public List<string> _list = new List<string>();
    public GameObject[] Slot = new GameObject[4];
    public GameObject[] cancleBtn = new GameObject[4];

    public GameObject popupCorrect;
    public GameObject popupWrong;
    public GameObject popupWrong0;
    public GameObject popupStart;
    public GameObject popupHelp;

    public AudioClip click;
    public AudioClip popup;
    public AudioClip correct;
    public AudioClip wrong;
    AudioSource audioSrc;

    public Text bossText;
    public GameObject bossPanel;
    public GameObject boss;
    private string m_text;
    public GameObject focus_hint;
    public GameObject focus_c;
    int i = 0;
    int cnt = 0;
    string orderMenu1 = "아이스 아메리카노";

    public AudioClip[] bossVoice;


    void Start()
    {
        ClickedMenu = "";
        audioSrc = GetComponent<AudioSource>();
        //Invoke("BossTalk", 1f);
        Invoke("StartPopup", 0.5f);
    }
    void StartPopup()
    {
        Popup pop = popupStart.GetComponent<Popup>();
        pop.PopUp3();
    }
    public void Interval()
    {
        Invoke("BossTalk", 0.8f);
    }
    public void Help_Click()
    {
        bossPanel.SetActive(false);
        focus_hint.SetActive(false);
        Popup pop = popupHelp.GetComponent<Popup>();
        pop.PopUp4();
    }

    public void BossTalk()
    {
        if (i == 0)
        {
            boss.SetActive(true);
            bossPanel.SetActive(true);
            audioSrc.Stop();
            m_text = "이제 방금 외운 메뉴들을 포스기에 찍어 맞는지 확인해 볼 거예요~";
            audioSrc.PlayOneShot(bossVoice[0]);
            StartMethod();
            i++;
        }
        else if (i == 1)
        {
            StopMethod();
            audioSrc.Stop();
            m_text = "방금 외운 메뉴 중 '커피' 메뉴를 먼저 골라주세요!";
            audioSrc.PlayOneShot(bossVoice[1]);
            StartMethod();
            i++;
        }
        else if (i == 2)
        {
            StopMethod();
            boss.SetActive(false);
            focus_hint.SetActive(true);
            audioSrc.Stop();
            m_text = "기억이 잘 나지 않는다면 '도움말' 버튼을 눌러 초성 힌트를 확인할 수 있어요";
            audioSrc.PlayOneShot(bossVoice[2]);
            StartMethod();
            i++;
        }
        else if (i == 3)
        {
            bossPanel.SetActive(false);
            focus_hint.SetActive(false);
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


    public void MenuClickedBtn()
    {
        audioSrc.PlayOneShot(click, 0.5f);

        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        ClickedMenu = clickObject.GetComponentInChildren<Text>().text;

        if (_list.Count < 4)
        {
            _list.Add(ClickedMenu); //리스트는 string 타입
            FreshSlot();
        }
        if (cnt == 0)
        {
            focus_c.SetActive(true);
            cnt++;
        }
    }
    public void CancledBtn()
    {
        audioSrc.PlayOneShot(click, 0.5f);

        GameObject clickObject = EventSystem.current.currentSelectedGameObject;

        if (clickObject.tag == "slot1")
        {
            _list.RemoveAt(0);
            FreshSlot();
        }
        else if (clickObject.tag == "slot2")
        {
            _list.RemoveAt(1);
            FreshSlot();
        }
        else if (clickObject.tag == "slot3")
        {
            _list.RemoveAt(2);
            FreshSlot();
        }
        else if (clickObject.tag == "slot4")
        {
            _list.RemoveAt(3);
            FreshSlot();
        }

    }
    void FreshSlot()
    {
        int i = 0;
        for (; i < _list.Count && i < 4; i++)
        {
            Slot[i].GetComponentInChildren<Text>().text = _list[i];
            cancleBtn[i].SetActive(true);
        }
        for (; i < 4; i++)
        {
            Slot[i].GetComponentInChildren<Text>().text = null;
            cancleBtn[i].SetActive(false);
        }
    }

    public void ConfirmMenu()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        focus_c.SetActive(false);

        if(_list.Count == 0)
        {
            //popupWrong.SetActive(true);
            Popup pop = popupWrong0.GetComponent<Popup>();
            pop.PopUp();
            audioSrc.PlayOneShot(wrong, 0.5f);
        }
        if (_list.Count == 1 && _list.Contains(orderMenu1))
        {
            //정답이라면
            Popup pop = popupCorrect.GetComponent<Popup>();
            pop.PopUp();
            //popupCorrect.SetActive(true);
            audioSrc.PlayOneShot(correct, 0.5f);
        }
        else if (_list.Contains(orderMenu1))
        {
            int idxCoffee = _list.FindIndex(coffee => coffee.Contains(orderMenu1));
            for (int i = 0; i < _list.Count; i++)
            {
                if (i != idxCoffee)
                {
                    //오답이 있다면
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    //popupWrong.SetActive(true);
                    audioSrc.PlayOneShot(wrong, 0.5f);
                    Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                    _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                    //깜빡깜빡 추가 필요
                }
            }
        }
        else
        {
            for (int i = 0; i < _list.Count; i++)
            {
                //popupWrong.SetActive(true);
                Popup pop = popupWrong.GetComponent<Popup>();
                pop.PopUp();
                audioSrc.PlayOneShot(wrong, 0.5f);
                Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                //깜빡깜빡 추가 필요
            }
        }
        

    }
    public void NextBtn()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        SceneManager.LoadScene("T_OrderCube");
    }

    public void ClickSound()
    {
        audioSrc.PlayOneShot(click, 0.5f);
    }
    public void PopupSound()
    {
        audioSrc.PlayOneShot(popup, 0.5f);
    }
    public void CorretSound()
    {
        audioSrc.PlayOneShot(correct, 0.5f);
    }
    public void WrongSound()
    {
        audioSrc.PlayOneShot(wrong, 0.5f);
    }
}