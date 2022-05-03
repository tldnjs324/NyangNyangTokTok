using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OrderToast : MonoBehaviour
{
    string ClickedMenu;
    public List<string> _list;// = new List<string>();
    public GameObject[] Slot = new GameObject[4];
    public GameObject[] cancleBtn = new GameObject[4];

    public GameObject popupCorrect;
    public GameObject popupWrong;

    public static int sumCount;// = GameManager.coffeeCount;

    public AudioClip click;
    public AudioClip popup;
    public AudioClip correct;
    public AudioClip wrong;
    AudioSource audioSrc;

    public static int toast_wrong = 0;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        ClickedMenu = "";
        //0425½Ã¿ø¼öÁ¤
        sumCount = GameManager.coffeeCount;
        //_list = new List<string>();
        //_list.RemoveRange(0, 3);

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
        if (_list.Count == sumCount)
        {
            popupWrong.SetActive(true);
            MoveLevel.wrongCount += 1;
            toast_wrong += 1;
            audioSrc.PlayOneShot(wrong, 0.5f);
        }

        /////////À½·á+Åä½ºÆ®=¸Þ´º 3°³
        if (sumCount + GameManager.toastCount == 3)
        {
            if (GameManager.toastCount == 1)
            {
                if (_list.Count == (sumCount + 1) && _list.Contains(GameManager.OrderMenu3))
                {
                    popupCorrect.SetActive(true);
                    audioSrc.PlayOneShot(correct, 0.5f);
                    //°è»ê±â ¾À ÀÌµ¿

                    //ÇÏÆ® ¿Ã¸®´Â ÄÚµå
                    GameManager.IncreaseHeart(toast_wrong);
                }
                else if (_list.Contains(GameManager.OrderMenu3))
                {
                    int idx = _list.FindIndex(toast => toast.Contains(GameManager.OrderMenu3));
                    for (int i = sumCount; i < _list.Count; i++)
                    {
                        if (i != idx)
                        {
                            //¿À´äÀÌ ÀÖ´Ù¸é
                            popupWrong.SetActive(true);
                            MoveLevel.wrongCount += 1;
                            toast_wrong += 1;
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
                        MoveLevel.wrongCount += 1;
                        toast_wrong += 1;
                        audioSrc.PlayOneShot(wrong, 0.5f);
                        Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        //±ôºý±ôºý Ãß°¡ ÇÊ¿ä
                    }
                }
            }
            else if (GameManager.toastCount == 2)
            {
                if (_list.Count == (sumCount + 2) && _list.Contains(GameManager.OrderMenu2) && _list.Contains(GameManager.OrderMenu3))
                {
                    popupCorrect.SetActive(true);
                    audioSrc.PlayOneShot(correct, 0.5f);
                    //°è»ê±â ¾À ÀÌµ¿
                }
                else if (_list.Contains(GameManager.OrderMenu2) || _list.Contains(GameManager.OrderMenu3))
                {
                    int idx1 = _list.FindIndex(toast => toast.Contains(GameManager.OrderMenu2));
                    int idx2 = _list.FindIndex(toast => toast.Contains(GameManager.OrderMenu3));
                    for (int i = sumCount; i < _list.Count; i++)
                    {
                        if (i != idx1 && i != idx2)
                        {
                            //¿À´äÀÌ ÀÖ´Ù¸é
                            popupWrong.SetActive(true);
                            MoveLevel.wrongCount += 1;
                            toast_wrong += 1;
                            audioSrc.PlayOneShot(wrong, 0.5f);
                            Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                            _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                            //±ôºý±ôºý Ãß°¡ ÇÊ¿ä
                        }
                    }
                    if (_list.Count == (sumCount + 1))
                    {
                        popupWrong.SetActive(true);
                        MoveLevel.wrongCount += 1;
                        toast_wrong += 1;
                        audioSrc.PlayOneShot(wrong, 0.5f);
                    }///
                }
                else
                {
                    for (int i = sumCount; i < _list.Count; i++)
                    {
                        popupWrong.SetActive(true);
                        MoveLevel.wrongCount += 1;
                        toast_wrong += 1;
                        audioSrc.PlayOneShot(wrong, 0.5f);
                        Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        //±ôºý±ôºý Ãß°¡ ÇÊ¿ä
                    }
                }
            }
        }
        ////////¸Þ´º 2°³
        else if (sumCount + GameManager.toastCount == 2)
        {
            if (GameManager.toastCount == 1)
            {
                if (_list.Count == (sumCount + 1) && _list.Contains(GameManager.OrderMenu2))
                {
                    popupCorrect.SetActive(true);
                    audioSrc.PlayOneShot(correct, 0.5f);
                    //°è»ê±â ¾À ÀÌµ¿
                }
                else if (_list.Contains(GameManager.OrderMenu2))
                {
                    int idx = _list.FindIndex(toast => toast.Contains(GameManager.OrderMenu2));
                    for (int i = sumCount; i < _list.Count; i++)
                    {
                        if (i != idx)
                        {
                            //¿À´äÀÌ ÀÖ´Ù¸é
                            popupWrong.SetActive(true);
                            MoveLevel.wrongCount += 1;
                            toast_wrong += 1;
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
                        MoveLevel.wrongCount += 1;
                        toast_wrong += 1;
                        audioSrc.PlayOneShot(wrong, 0.5f);
                        Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        //±ôºý±ôºý Ãß°¡ ÇÊ¿ä
                    }
                }
            }
            else if (GameManager.toastCount == 2)
            {
                if (_list.Count == 2 && _list.Contains(GameManager.OrderMenu1) && _list.Contains(GameManager.OrderMenu2))
                {
                    //Á¤´äÀÌ¶ó¸é
                    popupCorrect.SetActive(true);
                    audioSrc.PlayOneShot(correct, 0.5f);
                    //Å¥ºê °í¸£±â ¾ÀÀÌµ¿ Ãß°¡!
                }
                else if (_list.Contains(GameManager.OrderMenu1) || _list.Contains(GameManager.OrderMenu2))
                {
                    int idx1 = _list.FindIndex(toast => toast.Contains(GameManager.OrderMenu1));
                    int idx2 = _list.FindIndex(toast => toast.Contains(GameManager.OrderMenu2));
                    for (int i = 0; i < _list.Count; i++)
                    {
                        if (i != idx1 && i != idx2)
                        {
                            //¿À´äÀÌ ÀÖ´Ù¸é
                            popupWrong.SetActive(true);
                            MoveLevel.wrongCount += 1;
                            toast_wrong += 1;
                            audioSrc.PlayOneShot(wrong, 0.5f);
                            Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                            _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                            //±ôºý±ôºý Ãß°¡ ÇÊ¿ä
                        }
                    }
                    if (_list.Count == 1)
                    {
                        popupWrong.SetActive(true);
                        MoveLevel.wrongCount += 1;
                        toast_wrong += 1;
                        audioSrc.PlayOneShot(wrong, 0.5f);
                    }
                }
                else
                {
                    for (int i = 0; i < _list.Count; i++)
                    {
                        popupWrong.SetActive(true);
                        MoveLevel.wrongCount += 1;
                        toast_wrong += 1;
                        audioSrc.PlayOneShot(wrong, 0.5f);
                        Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                        //±ôºý±ôºý Ãß°¡ ÇÊ¿ä
                    }
                }
            }
        }
        /////////¸Þ´º 1°³
        else
        {
            if (sumCount + GameManager.toastCount == 1)
            {
                if (_list.Count == 1 && _list.Contains(GameManager.OrderMenu1))
                {
                    //Á¤´äÀÌ¶ó¸é
                    popupCorrect.SetActive(true);
                    audioSrc.PlayOneShot(correct, 0.5f);
                }
                else if (_list.Contains(GameManager.OrderMenu1))
                {
                    int idx = _list.FindIndex(toast => toast.Contains(GameManager.OrderMenu1));
                    for (int i = 0; i < _list.Count; i++)
                    {
                        if (i != idx)
                        {
                            //¿À´äÀÌ ÀÖ´Ù¸é
                            popupWrong.SetActive(true);
                            MoveLevel.wrongCount += 1;
                            toast_wrong += 1;
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
                        toast_wrong += 1;
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
        if (GameManager.cubeCount > 0)
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
}