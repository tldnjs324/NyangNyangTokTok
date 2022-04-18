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

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        ClickedMenu = "";

        if (sumCount == 1)
        {
            _list.Add(GameManager1.OrderMenu1);
            FreshSlot();
        }
        Invoke("BossTalk", 1f);
    }
    public void BossTalk()
    {
        if (i == 0)
        {
            m_text = "�̹����� �ܿ� �޴� �� 'ť�� ����ũ' �޴��� ����ּ���~";
            StartMethod();
            i++;
        }
        else if (i == 1)
        {
            StopMethod();
            m_text = "�򰥸��ٸ� ���� ����� ���� ��ư �������ƿ�!";
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
            _list.Add(ClickedMenu); //����Ʈ�� string Ÿ��
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
            popupWrong.SetActive(true);
            audioSrc.PlayOneShot(wrong, 0.5f);
        }

        if (GameManager1.cubeCount == 1)
        {
            if (_list.Count == (sumCount + 1) && _list.Contains(GameManager1.OrderMenu2))
            {
                popupCorrect.SetActive(true);
                audioSrc.PlayOneShot(correct, 0.5f);

            }
            else if (_list.Contains(GameManager1.OrderMenu2))
            {
                int idx = _list.FindIndex(cube => cube.Contains(GameManager1.OrderMenu2));
                for (int i = sumCount; i < _list.Count; i++)
                {
                    if (i != idx)
                    {
                        //������ �ִٸ�
                        popupWrong.SetActive(true);
                        audioSrc.PlayOneShot(wrong, 0.5f);
                        Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        //�������� �߰� �ʿ�
                    }
                }
            }
            else
            {
                for (int i = sumCount; i < _list.Count; i++)
                {
                    popupWrong.SetActive(true);
                    audioSrc.PlayOneShot(wrong, 0.5f);
                    Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                    _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                    //�������� �߰� �ʿ�
                }
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