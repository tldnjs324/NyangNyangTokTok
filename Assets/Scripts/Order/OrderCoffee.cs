using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OrderCoffee : MonoBehaviour
{
    string ClickedMenu;
    public List<string> _list = new List<string>();
    public GameObject[] Slot = new GameObject[4];
    public GameObject[] cancleBtn = new GameObject[4];

    public GameObject popupCorrect;
    public GameObject popupWrong;

    public AudioClip click;
    public AudioClip popup;
    public AudioClip correct;
    public AudioClip wrong;
    AudioSource audioSrc;

    void Start()
    {
        ClickedMenu = "";
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {

    }


    public void MenuClickedBtn()
    {
        audioSrc.PlayOneShot(click, 0.5f);

        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        ClickedMenu = clickObject.GetComponentInChildren<Text>().text;

        if (_list.Count < 4)
        {
            _list.Add(ClickedMenu); //¸®½ºÆ®´Â string Å¸ÀÔ
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
    }

    public void ConfirmMenu()
    {
        audioSrc.PlayOneShot(click, 0.5f);

        if(_list.Count == 0)
        {
            popupWrong.SetActive(true);
            MoveLevel.wrongCount += 1;
            audioSrc.PlayOneShot(wrong, 0.5f);
        }

        if (GameManager.coffeeCount == 1)
        {

            if (_list.Count == 1 && _list.Contains(GameManager.OrderMenu1))
            {
                //Á¤´äÀÌ¶ó¸é
                popupCorrect.SetActive(true);
                audioSrc.PlayOneShot(correct, 0.5f);
            }
            else if (_list.Contains(GameManager.OrderMenu1))
            {
                int idxCoffee = _list.FindIndex(coffee => coffee.Contains(GameManager.OrderMenu1));
                for (int i = 0; i < _list.Count; i++)
                {
                    if (i != idxCoffee)
                    {
                        //¿À´äÀÌ ÀÖ´Ù¸é
                        MoveLevel.wrongCount += 1;
                        popupWrong.SetActive(true);
                        audioSrc.PlayOneShot(wrong, 0.5f);
                        Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        //±ôºý±ôºý Ãß°¡ ÇÊ¿ä
                    }
                }
            }
            else
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    popupWrong.SetActive(true);
                    MoveLevel.wrongCount += 1;
                    audioSrc.PlayOneShot(wrong, 0.5f);
                    Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                    _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                    //±ôºý±ôºý Ãß°¡ ÇÊ¿ä
                }
            }
        }
        else if (GameManager.coffeeCount == 2)
        {
            if (_list.Count == 2 && _list.Contains(GameManager.OrderMenu1) && _list.Contains(GameManager.OrderMenu2))
            {
                //Á¤´äÀÌ¶ó¸é
                popupCorrect.SetActive(true);
                audioSrc.PlayOneShot(correct, 0.5f);
            }
            else if (_list.Contains(GameManager.OrderMenu1) || _list.Contains(GameManager.OrderMenu2))
            {
                int idxCoffee1 = _list.FindIndex(coffee => coffee.Contains(GameManager.OrderMenu1));
                int idxCoffee2 = _list.FindIndex(coffee => coffee.Contains(GameManager.OrderMenu2));
                for (int i = 0; i < _list.Count; i++)
                {
                    if (i != idxCoffee1 && i != idxCoffee2)
                    {
                        //¿À´äÀÌ ÀÖ´Ù¸é
                        popupWrong.SetActive(true);
                        MoveLevel.wrongCount += 1;
                        audioSrc.PlayOneShot(wrong, 0.5f);
                        Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        //±ôºý±ôºý Ãß°¡ ÇÊ¿ä
                    }
                }
                //
                if (_list.Count == 1)
                {
                    popupWrong.SetActive(true);
                    MoveLevel.wrongCount += 1;
                    audioSrc.PlayOneShot(wrong, 0.5f);
                }
            }
            else
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    popupWrong.SetActive(true);
                    MoveLevel.wrongCount += 1;
                    audioSrc.PlayOneShot(wrong, 0.5f);
                    Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                    _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                    //±ôºý±ôºý Ãß°¡ ÇÊ¿ä
                }
            }
        }
        else if (GameManager.coffeeCount == 3)
        {
            if (_list.Count == 3 && _list.Contains(GameManager.OrderMenu1) && _list.Contains(GameManager.OrderMenu2) && _list.Contains(GameManager.OrderMenu3))
            {
                //Á¤´äÀÌ¶ó¸é
                popupCorrect.SetActive(true);
                audioSrc.PlayOneShot(correct, 0.5f);
            }
            else if (_list.Contains(GameManager.OrderMenu1) || _list.Contains(GameManager.OrderMenu2) || _list.Contains(GameManager.OrderMenu3))
            {
                int idxCoffee1 = _list.FindIndex(coffee => coffee.Contains(GameManager.OrderMenu1));
                int idxCoffee2 = _list.FindIndex(coffee => coffee.Contains(GameManager.OrderMenu2));
                int idxCoffee3 = _list.FindIndex(coffee => coffee.Contains(GameManager.OrderMenu3));
                for (int i = 0; i < _list.Count; i++)
                {
                    if (i != idxCoffee1 && i != idxCoffee2 && i != idxCoffee3)
                    {
                        //¿À´äÀÌ ÀÖ´Ù¸é
                        popupWrong.SetActive(true);
                        MoveLevel.wrongCount += 1;
                        audioSrc.PlayOneShot(wrong, 0.5f);
                        Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        //±ôºý±ôºý Ãß°¡ ÇÊ¿ä
                    }
                }
                //
                if (_list.Count == 1)
                {
                    popupWrong.SetActive(true);
                    MoveLevel.wrongCount += 1;
                    audioSrc.PlayOneShot(wrong, 0.5f);
                }
                else if (_list.Count == 2)
                {
                    popupWrong.SetActive(true);
                    MoveLevel.wrongCount += 1;
                    audioSrc.PlayOneShot(wrong, 0.5f);
                }
            }
            else
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    popupWrong.SetActive(true);
                    MoveLevel.wrongCount += 1;
                    audioSrc.PlayOneShot(wrong, 0.5f);
                    Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                    _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                    //±ôºý±ôºý Ãß°¡ ÇÊ¿ä
                }
            }
        }

    }
    public void NextBtn()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        if (GameManager.toastCount > 0)
        {
            SceneManager.LoadScene("OrderToast");
        }
        else if (GameManager.toastCount == 0 && GameManager.cubeCount > 0)
        {
            SceneManager.LoadScene("OrderCube");

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
    public void CorretSound()
    {
        audioSrc.PlayOneShot(correct, 0.5f);
    }
    public void WrongSound()
    {
        audioSrc.PlayOneShot(wrong, 0.5f);
    }
}