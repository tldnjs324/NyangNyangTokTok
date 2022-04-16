using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderHelp : MonoBehaviour
{
    public GameObject popupHelp;
    public Text helpText;
    //string menu = "";

    string hint = "";
    string hint1;
    string hint2;
    string hint3;
    string hint4;

    void Start()
    {
        hint1 = "";
        hint2 = "";
        hint3 = "";
        hint4 = "";

        //문자열 길이로 메뉴개수 판단
        if (GameManager.OrderMenu3.Length > 2 && GameManager.OrderMenu4.Length < 2) //메뉴 3개
        {
            FindHint(GameManager.OrderMenu1);
            hint1 = hint;
            FindHint(GameManager.OrderMenu2);
            hint2 = hint;
            FindHint(GameManager.OrderMenu3);
            hint3 = hint;
        }
        else if (GameManager.OrderMenu4.Length > 2) //메뉴 4개
        {
            FindHint(GameManager.OrderMenu1);
            hint1 = hint;
            FindHint(GameManager.OrderMenu2);
            hint2 = hint;
            FindHint(GameManager.OrderMenu3);
            hint3 = hint;
            FindHint(GameManager.OrderMenu4);
            hint4 = hint;
        }
        else //메뉴 2개
        {
            FindHint(GameManager.OrderMenu1);
            hint1 = hint;
            FindHint(GameManager.OrderMenu2);
            hint2 = hint;
        }

        helpText.text += hint1 + "\n" + hint2 + "\n" + hint3 + "\n" + hint4;
    }
    
    void Update()
    {
        
    }

    void FindHint(string menu)
    {
        switch (menu)
        {
            case "따뜻한 아메리카노":
                hint = "ㄸㄸㅎ ㅇㅁㄹㅋㄴ";
                break;
            case "아이스 아메리카노":
                hint = "ㅇㅇㅅ ㅇㅁㄹㅋㄴ";
                break;
            case "따뜻한 카페라떼":
                hint = "ㄸㄸㅎ ㅋㅍㄹㄸ";
                break;
            case "아이스 카페라떼":
                hint = "ㅇㅇㅅ ㅋㅍㄹㄸ";
                break;
            case "따뜻한 바닐라라떼":
                hint = "ㄸㄸㅎ ㅂㄴㄹㄹㄸ";
                break;
            case "아이스 바닐라라떼":
                hint = "ㅇㅇㅅ ㅂㄴㄹㄹㄸ";
                break;
            case "따뜻한 카페모카":
                hint = "ㄸㄸㅎ ㅋㅍㅁㅋ";
                break;
            case "아이스 카페모카":
                hint = "ㅇㅇㅅ ㅋㅍㅁㅋ";
                break;

            case "기본 토스트":
                hint = "ㄱㅂ ㅌㅅㅌ";
                break;
            case "초코 토스트":
                hint = "ㅊㅋ ㅌㅅㅌ";
                break;
            case "딸기 토스트":
                hint = "ㄸㄱ ㅌㅅㅌ";
                break;
            case "블루베리 토스트":
                hint = "ㅂㄹㅂㄹ ㅌㅅㅌ";
                break;
            case "딸기 블루베리 토스트":
                hint = "ㄸㄱ ㅂㄹㅂㄹ ㅌㅅㅌ";
                break;
            case "냥냥 토스트":
                hint = "ㄴㄴ ㅌㅅㅌ";
                break;

            case "3구 큐브케이크":
                hint = "3ㄱ ㅋㅂㅋㅇㅋ";
                break;
            case "4구 큐브케이크":
                hint = "4ㄱ ㅋㅂㅋㅇㅋ";
                break;
            case "5구 큐브케이크":
                hint = "5ㄱ ㅋㅂㅋㅇㅋ";
                break;
            case "6구 큐브케이크":
                hint = "6ㄱ ㅋㅂㅋㅇㅋ";
                break;
            case "7구 큐브케이크":
                hint = "7ㄱ ㅋㅂㅋㅇㅋ";
                break;
            case "8구 큐브케이크":
                hint = "8ㄱ ㅋㅂㅋㅇㅋ";
                break;
        }
    }
}
