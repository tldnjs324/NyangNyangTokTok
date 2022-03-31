using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecifyNumber : MonoBehaviour
{
    public static int[] MakingMenu;//OrderMenu1234를 하나씩 MakingMenu 배열에 메뉴 고유 숫자로 저장
    public static bool[] MenuNumber;//고유 번호의 메뉴가 주문이 됐는지 안됐는지 여부, 고유 번호는 맨 아래 주석



    // Start is called before the first frame update
    void Start()
    {
        //OrderMenu1 저장
        if (GameManager.OrderMenu1 == "따뜻한 아메리카노")
        {
            MenuNumber[0] = true;
            MakingMenu[0] = 0;
        }
        else if (GameManager.OrderMenu1 == "아이스 아메리카노")
        {
            MenuNumber[1] = true;
            MakingMenu[0] = 1;
        }
        else if (GameManager.OrderMenu1 == "따뜻한 카페라떼")
        {
            MenuNumber[2] = true;
            MakingMenu[0] = 2;
        }
        else if (GameManager.OrderMenu1 == "아이스 카페라떼")
        {
            MenuNumber[3] = true;
            MakingMenu[0] = 3;
        }
        else if (GameManager.OrderMenu1 == "따뜻한 바닐라라떼")
        {
            MenuNumber[4] = true;
            MakingMenu[0] = 4;
        }
        else if (GameManager.OrderMenu1 == "아이스 바닐라라떼")
        {
            MenuNumber[5] = true;
            MakingMenu[0] = 5;
        }
        else if (GameManager.OrderMenu1 == "따뜻한 카페모카")
        {
            MenuNumber[6] = true;
            MakingMenu[0] = 6;
        }
        else if (GameManager.OrderMenu1 == "아이스 카페모카")
        {
            MenuNumber[7] = true;
            MakingMenu[0] = 7;
        }
        else if (GameManager.OrderMenu1 == "기본 토스트")
        {
            MenuNumber[8] = true;
            MakingMenu[0] = 8;
        }
        else if (GameManager.OrderMenu1 == "초코 토스트")//
        {
            MenuNumber[9] = true;
            MakingMenu[0] = 9;
        }
        else if (GameManager.OrderMenu1 == "딸기 토스트")
        {
            MenuNumber[10] = true;
            MakingMenu[0] = 10;
        }
        else if (GameManager.OrderMenu1 == "블루베리 토스트")
        {
            MenuNumber[11] = true;
            MakingMenu[0] = 11;
        }
        else if (GameManager.OrderMenu1 == "딸기 초코 토스트")
        {
            MenuNumber[12] = true;
            MakingMenu[0] = 12;
        }
        else if (GameManager.OrderMenu1 == "냥냥 토스트")
        {
            MenuNumber[13] = true;
            MakingMenu[0] = 13;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



/*
0: 따뜻한 아메리카노
1: 아이스 아메리카노
2: 따뜻한 카페라떼
3: 아이스 카페라떼
4: 따뜻한 바닐라라떼
5: 아이스 바닐라라떼
6: 따뜻한 카페모카
7: 아이스 카페모카

8: 기본 토스트
9: 초코 토스트
10: 딸기 토스트
11: 블루베리 토스트
12: 딸기 초코 토스트
13: 냥냥 토스트

14: 3구 큐브케이크
15: 4구 큐브케이크
16: 5구 큐브케이크
17: 6구 큐브케이크
18: 7구 큐브케이크
19: 8구 큐브케이크
*/
