using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecifyNumber : MonoBehaviour
{
    //OrderMenu1234를 하나씩 MakingMenu 배열에 메뉴 고유 숫자로 저장(초기화 숫자 20은 없는 고유번호)
    public static int[] MakingMenu = { 20, 20, 20, 20 };
    //고유 번호의 메뉴가 주문이 됐는지 안됐는지 여부, 고유 번호는 맨 아래 주석(일단은 모두 안됨으로 초기화)
    public static bool[] MenuNumber = {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};//고유 번호의 메뉴가 주문이 됐는지 안됐는지 여부, 고유 번호는 맨 아래 주석



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

        //OrderMenu2 저장
        if (GameManager.OrderMenu2 == "따뜻한 아메리카노")
        {
            MenuNumber[0] = true;
            MakingMenu[1] = 0;
        }
        else if (GameManager.OrderMenu2 == "아이스 아메리카노")
        {
            MenuNumber[1] = true;
            MakingMenu[1] = 1;
        }
        else if (GameManager.OrderMenu2 == "따뜻한 카페라떼")
        {
            MenuNumber[2] = true;
            MakingMenu[1] = 2;
        }
        else if (GameManager.OrderMenu2 == "아이스 카페라떼")
        {
            MenuNumber[3] = true;
            MakingMenu[1] = 3;
        }
        else if (GameManager.OrderMenu2 == "따뜻한 바닐라라떼")
        {
            MenuNumber[4] = true;
            MakingMenu[1] = 4;
        }
        else if (GameManager.OrderMenu2 == "아이스 바닐라라떼")
        {
            MenuNumber[5] = true;
            MakingMenu[1] = 5;
        }
        else if (GameManager.OrderMenu2 == "따뜻한 카페모카")
        {
            MenuNumber[6] = true;
            MakingMenu[1] = 6;
        }
        else if (GameManager.OrderMenu2 == "아이스 카페모카")
        {
            MenuNumber[7] = true;
            MakingMenu[1] = 7;
        }
        else if (GameManager.OrderMenu2 == "기본 토스트")
        {
            MenuNumber[8] = true;
            MakingMenu[1] = 8;
        }
        else if (GameManager.OrderMenu2 == "초코 토스트")//
        {
            MenuNumber[9] = true;
            MakingMenu[1] = 9;
        }
        else if (GameManager.OrderMenu2 == "딸기 토스트")
        {
            MenuNumber[10] = true;
            MakingMenu[1] = 10;
        }
        else if (GameManager.OrderMenu2 == "블루베리 토스트")
        {
            MenuNumber[11] = true;
            MakingMenu[1] = 11;
        }
        else if (GameManager.OrderMenu2 == "딸기 초코 토스트")
        {
            MenuNumber[12] = true;
            MakingMenu[1] = 12;
        }
        else if (GameManager.OrderMenu2 == "냥냥 토스트")
        {
            MenuNumber[13] = true;
            MakingMenu[1] = 13;
        }
        else if (GameManager.OrderMenu2 == "3구 큐브케이크")
        {
            MenuNumber[14] = true;
            MakingMenu[1] = 14;
        }
        else if (GameManager.OrderMenu2 == "4구 큐브케이크")
        {
            MenuNumber[15] = true;
            MakingMenu[1] = 15;
        }
        else if (GameManager.OrderMenu2 == "5구 큐브케이크")
        {
            MenuNumber[16] = true;
            MakingMenu[1] = 16;
        }
        else if (GameManager.OrderMenu2 == "6구 큐브케이크")
        {
            MenuNumber[17] = true;
            MakingMenu[1] = 17;
        }
        else if (GameManager.OrderMenu2 == "7구 큐브케이크")
        {
            MenuNumber[18] = true;
            MakingMenu[1] = 18;
        }
        else if (GameManager.OrderMenu2 == "8구 큐브케이크")
        {
            MenuNumber[19] = true;
            MakingMenu[1] = 19;
        }

        //OrderMenu3 저장
        if (GameManager.OrderMenu3 == "따뜻한 아메리카노")
        {
            MenuNumber[0] = true;
            MakingMenu[2] = 0;
        }
        else if (GameManager.OrderMenu3 == "아이스 아메리카노")
        {
            MenuNumber[1] = true;
            MakingMenu[2] = 1;
        }
        else if (GameManager.OrderMenu3 == "따뜻한 카페라떼")
        {
            MenuNumber[2] = true;
            MakingMenu[2] = 2;
        }
        else if (GameManager.OrderMenu3 == "아이스 카페라떼")
        {
            MenuNumber[3] = true;
            MakingMenu[2] = 3;
        }
        else if (GameManager.OrderMenu3 == "따뜻한 바닐라라떼")
        {
            MenuNumber[4] = true;
            MakingMenu[2] = 4;
        }
        else if (GameManager.OrderMenu3 == "아이스 바닐라라떼")
        {
            MenuNumber[5] = true;
            MakingMenu[2] = 5;
        }
        else if (GameManager.OrderMenu3 == "따뜻한 카페모카")
        {
            MenuNumber[6] = true;
            MakingMenu[2] = 6;
        }
        else if (GameManager.OrderMenu3 == "아이스 카페모카")
        {
            MenuNumber[7] = true;
            MakingMenu[2] = 7;
        }
        else if (GameManager.OrderMenu3 == "기본 토스트")
        {
            MenuNumber[8] = true;
            MakingMenu[2] = 8;
        }
        else if (GameManager.OrderMenu3 == "초코 토스트")//
        {
            MenuNumber[9] = true;
            MakingMenu[2] = 9;
        }
        else if (GameManager.OrderMenu3 == "딸기 토스트")
        {
            MenuNumber[10] = true;
            MakingMenu[2] = 10;
        }
        else if (GameManager.OrderMenu3 == "블루베리 토스트")
        {
            MenuNumber[11] = true;
            MakingMenu[2] = 11;
        }
        else if (GameManager.OrderMenu3 == "딸기 초코 토스트")
        {
            MenuNumber[12] = true;
            MakingMenu[2] = 12;
        }
        else if (GameManager.OrderMenu3 == "냥냥 토스트")
        {
            MenuNumber[13] = true;
            MakingMenu[2] = 13;
        }
        else if (GameManager.OrderMenu3 == "3구 큐브케이크")
        {
            MenuNumber[14] = true;
            MakingMenu[2] = 14;
        }
        else if (GameManager.OrderMenu3 == "4구 큐브케이크")
        {
            MenuNumber[15] = true;
            MakingMenu[2] = 15;
        }
        else if (GameManager.OrderMenu3 == "5구 큐브케이크")
        {
            MenuNumber[16] = true;
            MakingMenu[2] = 16;
        }
        else if (GameManager.OrderMenu3 == "6구 큐브케이크")
        {
            MenuNumber[17] = true;
            MakingMenu[2] = 17;
        }
        else if (GameManager.OrderMenu3 == "7구 큐브케이크")
        {
            MenuNumber[18] = true;
            MakingMenu[2] = 18;
        }
        else if (GameManager.OrderMenu3 == "8구 큐브케이크")
        {
            MenuNumber[19] = true;
            MakingMenu[2] = 19;
        }

        //OrderMenu4 저장
        if (GameManager.OrderMenu4 == "따뜻한 아메리카노")
        {
            MenuNumber[0] = true;
            MakingMenu[3] = 0;
        }
        else if (GameManager.OrderMenu4 == "아이스 아메리카노")
        {
            MenuNumber[1] = true;
            MakingMenu[3] = 1;
        }
        else if (GameManager.OrderMenu4 == "따뜻한 카페라떼")
        {
            MenuNumber[2] = true;
            MakingMenu[3] = 2;
        }
        else if (GameManager.OrderMenu4 == "아이스 카페라떼")
        {
            MenuNumber[3] = true;
            MakingMenu[3] = 3;
        }
        else if (GameManager.OrderMenu4 == "따뜻한 바닐라라떼")
        {
            MenuNumber[4] = true;
            MakingMenu[3] = 4;
        }
        else if (GameManager.OrderMenu4 == "아이스 바닐라라떼")
        {
            MenuNumber[5] = true;
            MakingMenu[3] = 5;
        }
        else if (GameManager.OrderMenu4 == "따뜻한 카페모카")
        {
            MenuNumber[6] = true;
            MakingMenu[3] = 6;
        }
        else if (GameManager.OrderMenu4 == "아이스 카페모카")
        {
            MenuNumber[7] = true;
            MakingMenu[3] = 7;
        }
        else if (GameManager.OrderMenu4 == "기본 토스트")
        {
            MenuNumber[8] = true;
            MakingMenu[3] = 8;
        }
        else if (GameManager.OrderMenu4 == "초코 토스트")//
        {
            MenuNumber[9] = true;
            MakingMenu[3] = 9;
        }
        else if (GameManager.OrderMenu4 == "딸기 토스트")
        {
            MenuNumber[10] = true;
            MakingMenu[3] = 10;
        }
        else if (GameManager.OrderMenu4 == "블루베리 토스트")
        {
            MenuNumber[11] = true;
            MakingMenu[3] = 11;
        }
        else if (GameManager.OrderMenu4 == "딸기 초코 토스트")
        {
            MenuNumber[12] = true;
            MakingMenu[3] = 12;
        }
        else if (GameManager.OrderMenu4 == "냥냥 토스트")
        {
            MenuNumber[13] = true;
            MakingMenu[3] = 13;
        }
        else if (GameManager.OrderMenu4 == "3구 큐브케이크")
        {
            MenuNumber[14] = true;
            MakingMenu[3] = 14;
        }
        else if (GameManager.OrderMenu4 == "4구 큐브케이크")
        {
            MenuNumber[15] = true;
            MakingMenu[3] = 15;
        }
        else if (GameManager.OrderMenu4 == "5구 큐브케이크")
        {
            MenuNumber[16] = true;
            MakingMenu[3] = 16;
        }
        else if (GameManager.OrderMenu4 == "6구 큐브케이크")
        {
            MenuNumber[17] = true;
            MakingMenu[3] = 17;
        }
        else if (GameManager.OrderMenu4 == "7구 큐브케이크")
        {
            MenuNumber[18] = true;
            MakingMenu[3] = 18;
        }
        else if (GameManager.OrderMenu4 == "8구 큐브케이크")
        {
            MenuNumber[19] = true;
            MakingMenu[3] = 19;
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
