using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Recipe2 : MonoBehaviour
{
    string ClickedRecipe;
    public string[] basicToast = { "식빵", "토스트기" };
    public string[] chocoToast = { "식빵", "토스트기", "초코시럽"};
    public string[] strawberryToast = { "식빵", "토스트기", "딸기잼", "딸기" };
    public string[] blueberryToast = { "식빵", "토스트기", "블루베리잼", "블루베리" };
    public string[] strawblueToast = { "식빵", "토스트기", "블루베리잼", "딸기" };
    public string[] nyangnyangToast = { "식빵", "토스트기", "딸기잼", "블루베리", "초코시럽" };

    public List<string> _list = new List<string>();
    int i = 0;
    int wrongCnt = 0;
    //int time = 5; //원래 20초

    public Image img;
    public Sprite[] sprites = new Sprite[4];
    public GameObject btnMachine;
    public Sprite sprite;

    public GameObject[] hintArrows = new GameObject[6];
    public GameObject popupCorrect;
    public GameObject popupWrong;
    public GameObject popupHelp;
    public GameObject popupBoss;

    void Start()
    {
        ClickedRecipe = "";
    }

    public void RecipeClickedBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        ClickedRecipe = clickObject.GetComponentInChildren<Text>().text;
        _list.Add(ClickedRecipe);

        if (SceneManager.GetActiveScene().name == "BasicToast") //기본토스트
        {
            if (_list[i] == basicToast[i])
            {
                if (i > 0)
                {
                    img.sprite = sprites[i - 1]; //이미지 변경
                } 
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 2)
                {
                    popupCorrect.SetActive(true);
                }
                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite;
                    //식빵이 기계에 들어감(버튼 사진 변경)
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
}
