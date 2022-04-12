using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Recipe : MonoBehaviour
{
    string ClickedRecipe;
    public string[] hotAmericano = { "물", "커피머신", "샷" };
    public string[] iceAmericano = { "얼음", "물", "커피머신", "샷" };
    public string[] hotLatte = { "우유", "커피머신", "샷" };
    public string[] iceLatte = { "얼음", "우유", "커피머신", "샷" };
    public string[] hotVanillaLatte = { "우유", "커피머신", "샷", "바닐라시럽" };
    public string[] iceVanillaLatte = { "얼음", "우유", "커피머신", "샷", "바닐라시럽" };
    public string[] hotCafeMocha = { "우유", "초코시럽", "커피머신", "샷", "휘핑", "초코시럽" };
    public string[] iceCafeMocha = { "얼음", "우유", "초코시럽", "커피머신", "샷", "휘핑", "초코시럽" };

    public List<string> _list = new List<string>();
    int i = 0;
    int wrongCnt = 0;
    int cnt = 0;
    //int time = 5; //원래 20초

    public Image img;
    public Sprite[] sprites = new Sprite[7];

    public GameObject[] hintArrows = new GameObject[8];
    public GameObject popupCorrect;
    public GameObject popupWrong;
    public GameObject popupHelp;
    public GameObject popupBoss;

    public GameObject coffeeShot;
    public GameObject choco_img;

    void Start()
    {
        ClickedRecipe = "";
    }
    private void Update()
    {
        if (i != 0 && i == cnt)
        {
            Invoke("Correct", 1.5f);
            
        }
    }

    public void RecipeClickedBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        ClickedRecipe = clickObject.GetComponentInChildren<Text>().text;
        _list.Add(ClickedRecipe);

        if (SceneManager.GetActiveScene().name == "HotAmericano") //따뜻한아메리카노
        {
            cnt = 3;
            if (_list[i] == hotAmericano[i])
            {
                img.sprite = sprites[i]; //이미지 변경
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 2)
                {
                    coffeeShot.SetActive(true); //샷 생성
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
        if (SceneManager.GetActiveScene().name == "IceAmericano") //아이스아메리카노
        {
            cnt = 4;
            if (_list[i] == iceAmericano[i])
            {
                img.sprite = sprites[i]; //이미지 변경
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 3)
                {
                    coffeeShot.SetActive(true); //샷 생성
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
        if (SceneManager.GetActiveScene().name == "HotLatte") //따뜻한라떼
        {
            cnt = 3;
            if (_list[i] == hotLatte[i])
            {
                img.sprite = sprites[i]; //이미지 변경
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 2)
                {
                    coffeeShot.SetActive(true); //샷 생성
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
        if (SceneManager.GetActiveScene().name == "IceLatte") //아이스라떼
        {
            cnt = 4;
            if (_list[i] == iceLatte[i])
            {
                img.sprite = sprites[i]; //이미지 변경
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 3)
                {
                    coffeeShot.SetActive(true); //샷 생성
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
        if (SceneManager.GetActiveScene().name == "HotVanillaLatte") //따뜻한바닐라라떼
        {
            cnt = 4;
            if (_list[i] == hotVanillaLatte[i])
            {
                img.sprite = sprites[i]; //이미지 변경
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 2)
                {
                    coffeeShot.SetActive(true); //샷 생성
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
        if (SceneManager.GetActiveScene().name == "IceVanillaLatte") //아이스바닐라라떼
        {
            cnt = 5;
            if (_list[i] == iceVanillaLatte[i])
            {
                img.sprite = sprites[i]; //이미지 변경
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 3)
                {
                    coffeeShot.SetActive(true); //샷 생성
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
        if (SceneManager.GetActiveScene().name == "IceCafeMocha") //아이스카페모카
        {
            cnt = 7;
            if (_list[i] == iceCafeMocha[i])
            {
                img.sprite = sprites[i]; //이미지 변경
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 3)
                {
                    choco_img.SetActive(true); //초코시럽 생성
                }
                if (i == 4)
                {
                    coffeeShot.SetActive(true); //샷 생성
                    choco_img.SetActive(false);
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
        if (SceneManager.GetActiveScene().name == "HotCafeMocha") //따뜻한카페모카
        {
            cnt = 6;
            if (_list[i] == hotCafeMocha[i])
            {
                img.sprite = sprites[i]; //이미지 변경
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 2)
                {
                    choco_img.SetActive(true); //초코시럽 생성
                }
                if (i == 3)
                {
                    coffeeShot.SetActive(true); //샷 생성
                    choco_img.SetActive(false);
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
    public void Help_Click()
    {
        popupHelp.SetActive(true);
        hintArrows[0].SetActive(false);
    }
    public void Correct()
    {
        popupCorrect.SetActive(true);
    }
}
