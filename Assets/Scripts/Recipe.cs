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
    public string[] iceAmericano = { "얼음", "커피머신", "샷" };
    public string[] hotLattee = { "우유", "커피머신", "샷" };
    public string[] iceLattee = { "얼음", "우유", "커피머신", "샷" };
    public string[] hotVanillaLatte = { "우유", "커피머신", "샷", "바닐라시럽" };
    public string[] iceVanillaLatte = { "얼음", "우유", "커피머신", "샷", "바닐라시럽" };
    public string[] hotCafeMocha = { "우유", "초코시럽", "커피머신", "샷", "휘핑", "초코시럽" };
    public string[] iceCafeMocha = { "얼음", "우유", "초코시럽", "커피머신", "샷", "휘핑", "초코시럽" };
    //다른메뉴도 추가

    public List<string> _list = new List<string>();
    int i = 0;
    int wrongCnt = 0;
    //int time = 5; //원래 20초

    public Image img;
    public Sprite[] sprites = new Sprite[7];

    public GameObject[] hintArrows = new GameObject[8];
    public GameObject popupCorrect;
    public GameObject popupWrong;
    public GameObject popupHelp;
    public GameObject popupBoss;
    public GameObject coffeeShot; //카페모카용

    void Start()
    {
        ClickedRecipe = ""; 
    }

    public void RecipeClickedBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        ClickedRecipe = clickObject.GetComponentInChildren<Text>().text;
        _list.Add(ClickedRecipe);

        if(_list[i] == iceCafeMocha[i]) //아이스카페모카
        {
            img.sprite = sprites[i]; //이미지 변경
            i++;
            hintArrows[i].SetActive(false);
            wrongCnt = 0;
            if (i == 7)
            {
                popupCorrect.SetActive(true);
            }
            if (i == 4)
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
            }else if(wrongCnt == 2)
            {
                popupWrong.SetActive(true);
                hintArrows[0].SetActive(true); //도움말힌트강조
            }
            else if (wrongCnt == 3)
            {
                popupBoss.SetActive(true);
                hintArrows[i+1].SetActive(true); //재료를 알려줌
            }        
        }

        

    }
    public void Help_Click()
    {
        popupHelp.SetActive(true);
        hintArrows[0].SetActive(false);
    }
}
