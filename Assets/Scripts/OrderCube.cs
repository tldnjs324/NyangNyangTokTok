using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OrderCube : MonoBehaviour
{
    string ClickedMenu;
    public List<string> _list = new List<string>();
    public GameObject[] Slot = new GameObject[4];
    public GameObject[] cancleBtn = new GameObject[4];

    //public List<string> _list3 = OrderCoffee._list;

    public GameObject popupCorrect;
    public GameObject popupWrong;

    public static int sumCount = GameManager.coffeeCount + GameManager.toastCount;

    public AudioClip click;
    public AudioClip popup;
    public AudioClip correct;
    public AudioClip wrong;
    AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        ClickedMenu = "";

        if (sumCount == 1)
        {
            _list.Add(GameManager.OrderMenu1);
            FreshSlot();
        }
        else if (sumCount == 2)
        {
            _list.Add(GameManager.OrderMenu1);
            _list.Add(GameManager.OrderMenu2);
            FreshSlot();
        }
        else if (sumCount == 3)
        {
            _list.Add(GameManager.OrderMenu1);
            FreshSlot();
            _list.Add(GameManager.OrderMenu2);
            FreshSlot();
            _list.Add(GameManager.OrderMenu3);
            FreshSlot();
        }
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
        for (int j = 0; j < sumCount; j++)
        {
            cancleBtn[j].SetActive(false);
        }
    }

    public void ConfirmMenu()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        ///////¸Þ´º 3°³
        if (GameManager.OrderMenu3.Length > 2 && GameManager.OrderMenu4.Length < 2)
        {
            if (GameManager.cubeCount == 1)
            {
                if (_list.Count == (sumCount + 1) && _list.Contains(GameManager.OrderMenu3))
                {
                    popupCorrect.SetActive(true);
                    audioSrc.PlayOneShot(correct, 0.5f);

                }
                else if (_list.Contains(GameManager.OrderMenu3))
                {
                    int idx = _list.FindIndex(cube => cube.Contains(GameManager.OrderMenu3));
                    for (int i = sumCount; i < _list.Count; i++)
                    {
                        if (i != idx)
                        {
                            //¿À´äÀÌ ÀÖ´Ù¸é
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
                    for (int i = sumCount; i < _list.Count; i++)
                    {
                        popupWrong.SetActive(true);
                        audioSrc.PlayOneShot(wrong, 0.5f);
                        Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        //±ôºý±ôºý Ãß°¡ ÇÊ¿ä
                    }
                }
            }
            else if (GameManager.cubeCount == 2)
            {
                if (_list.Count == (sumCount + 2) && _list.Contains(GameManager.OrderMenu2) && _list.Contains(GameManager.OrderMenu3))
                {
                    popupCorrect.SetActive(true);
                    audioSrc.PlayOneShot(correct, 0.5f);

                }
                else if (_list.Contains(GameManager.OrderMenu2) || _list.Contains(GameManager.OrderMenu3))
                {
                    int idx1 = _list.FindIndex(cube => cube.Contains(GameManager.OrderMenu2));
                    int idx2 = _list.FindIndex(cube => cube.Contains(GameManager.OrderMenu3));
                    for (int i = sumCount; i < _list.Count; i++)
                    {
                        if (i != idx1 && i != idx2)
                        {
                            //¿À´äÀÌ ÀÖ´Ù¸é
                            popupWrong.SetActive(true);
                            audioSrc.PlayOneShot(wrong, 0.5f);
                            Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                            _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                            //±ôºý±ôºý Ãß°¡ ÇÊ¿ä
                        }
                    }
                    if (_list.Count == (sumCount + 1))
                    {
                        popupWrong.SetActive(true);
                        audioSrc.PlayOneShot(wrong, 0.5f);
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
                        //±ôºý±ôºý Ãß°¡ ÇÊ¿ä
                    }
                }
            }

        }
        ////////¸Þ´º 4°³
        else if (GameManager.OrderMenu4.Length > 2)
        {
            if (GameManager.cubeCount == 1)
            {
                if (_list.Count == (sumCount + 1) && _list.Contains(GameManager.OrderMenu4))
                {
                    popupCorrect.SetActive(true);
                    audioSrc.PlayOneShot(correct, 0.5f);
                }
                else if (_list.Contains(GameManager.OrderMenu4))
                {
                    int idx = _list.FindIndex(cube => cube.Contains(GameManager.OrderMenu3));
                    for (int i = sumCount; i < _list.Count; i++)
                    {
                        if (i != idx)
                        {
                            //¿À´äÀÌ ÀÖ´Ù¸é
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
                    for (int i = sumCount; i < _list.Count; i++)
                    {
                        popupWrong.SetActive(true);
                        audioSrc.PlayOneShot(wrong, 0.5f);
                        Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        //±ôºý±ôºý Ãß°¡ ÇÊ¿ä
                    }
                }
            }
            else if (GameManager.cubeCount == 2)
            {
                if (_list.Count == (sumCount + 2) && _list.Contains(GameManager.OrderMenu3) && _list.Contains(GameManager.OrderMenu4))
                {
                    popupCorrect.SetActive(true);
                    audioSrc.PlayOneShot(correct, 0.5f);

                }
                else if (_list.Contains(GameManager.OrderMenu3) || _list.Contains(GameManager.OrderMenu4))
                {
                    int idx1 = _list.FindIndex(cube => cube.Contains(GameManager.OrderMenu3));
                    int idx2 = _list.FindIndex(cube => cube.Contains(GameManager.OrderMenu4));
                    for (int i = sumCount; i < _list.Count; i++)
                    {
                        if (i != idx1 && i != idx2)
                        {
                            //¿À´äÀÌ ÀÖ´Ù¸é
                            popupWrong.SetActive(true);
                            audioSrc.PlayOneShot(wrong, 0.5f);
                            Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                            _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                            //±ôºý±ôºý Ãß°¡ ÇÊ¿ä
                        }
                    }
                    if (_list.Count == (sumCount + 1))
                    {
                        popupWrong.SetActive(true);
                        audioSrc.PlayOneShot(wrong, 0.5f);
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
                        //±ôºý±ôºý Ãß°¡ ÇÊ¿ä
                    }
                }
            }
        }
        ///////¸Þ´º 2°³
        else
        {
            if (GameManager.cubeCount == 1)
            {
                if (_list.Count == (sumCount + 1) && _list.Contains(GameManager.OrderMenu2))
                {
                    popupCorrect.SetActive(true);
                    audioSrc.PlayOneShot(correct, 0.5f);

                }
                else if (_list.Contains(GameManager.OrderMenu2))
                {
                    int idx = _list.FindIndex(cube => cube.Contains(GameManager.OrderMenu2));
                    for (int i = sumCount; i < _list.Count; i++)
                    {
                        if (i != idx)
                        {
                            //¿À´äÀÌ ÀÖ´Ù¸é
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
                    for (int i = sumCount; i < _list.Count; i++)
                    {
                        popupWrong.SetActive(true);
                        audioSrc.PlayOneShot(wrong, 0.5f);
                        Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        //±ôºý±ôºý Ãß°¡ ÇÊ¿ä
                    }
                }
            }
        }


    }
    public void NextBtn()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        SceneManager.LoadScene("Calculate");
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