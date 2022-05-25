using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OrderCube1 : MonoBehaviour
{
    string ClickedMenu;
    public List<string> _list = new List<string>();
    public GameObject[] Slot = new GameObject[4];
    public GameObject[] cancleBtn = new GameObject[4];

    //public List<string> _list3 = OrderCoffee._list;

    public GameObject popupCorrect;
    public GameObject popupWrong;
    public GameObject popupWrong0;
    public GameObject popupStart;
    public GameObject popupHelp;

    public static int sumCount = GameManager1.coffeeCount;

    public AudioClip click;
    public AudioClip popup;
    public AudioClip correct;
    public AudioClip wrong;
    AudioSource audioSrc;

    public Text bossText;
    public GameObject bossPanel;
    public GameObject boss;
    private string m_text;
    int i = 0;
    string orderMenu1 = "아이스 아메리카노";
    string orderMenu2 = "3구 큐브케이크";

    void Start()
    {
        Invoke("StartPopup", 0.5f);

        audioSrc = GetComponent<AudioSource>();
        ClickedMenu = "";

        if (sumCount == 1)
        {
            _list.Add(orderMenu1);
            FreshSlot();
        }
        //Invoke("BossTalk", 1f);
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
        Popup pop = popupHelp.GetComponent<Popup>();
        pop.PopUp4();
    }

    public void BossTalk()
    {
        if (i == 0)
        {
            bossPanel.SetActive(true);
            boss.SetActive(true);
            m_text = "이번에는 외운 메뉴 중 '큐브 케이크' 메뉴를 골라주세요~";
            StartMethod();
            i++;
        }
        else if (i == 1)
        {
            StopMethod();
            m_text = "헷갈린다면 우측 상단의 도움말 버튼 잊지말아요!";
            StartMethod();
            i++;
        }
        else if (i == 2)
        {
            bossPanel.SetActive(false);
            boss.SetActive(false);
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
        for (int j = 0; j < sumCount; j++)
        {
            cancleBtn[j].SetActive(false);
        }
    }

    public void ConfirmMenu()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        if (_list.Count == 0)
        {
            Popup pop = popupWrong0.GetComponent<Popup>();
            pop.PopUp();
            audioSrc.PlayOneShot(wrong, 0.5f);
        }

        if (_list.Count == (sumCount + 1) && _list.Contains(orderMenu2))
        {
            Popup pop = popupCorrect.GetComponent<Popup>();
            pop.PopUp();
            audioSrc.PlayOneShot(correct, 0.5f);
        
        }
        else if (_list.Contains(orderMenu2))
        {
            int idx = _list.FindIndex(cube => cube.Contains(orderMenu2));
            for (int i = sumCount; i < _list.Count; i++)
            {
                if (i != idx)
                {
                    //오답이 있다면
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    audioSrc.PlayOneShot(wrong, 0.5f);
                    Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                    _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                    //깜빡깜빡 추가 필요
                }
            }
        }
        else
        {
            for (int i = sumCount; i < _list.Count; i++)
            {
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
        SceneManager.LoadScene("T_Calculate");
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