using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Auth;


public class GameManager : MonoBehaviour
{
    public AudioClip click;
    AudioSource audioSrc;

    public Text bossText;
    public Text talkText;
    public GameObject bossPanel;
    public GameObject talkPanel; //나비

    public GameObject boss;
    public GameObject cat1;
    //private string[] cats = { "cat1", "cat2", "cat3" }; //여러 마리의 고양이 캐릭터 예정

    public static int currentLevel; //레벨!!
    public static int currentCount; //발자국 수

    //public Text levelText;

    //1단계용 메뉴 목록
    private string[] level1_Coffee_menu = { "따뜻한 아메리카노", "아이스 아메리카노", "따뜻한 카페라떼" };
    private string level1_Cube_menu = "3구 큐브케이크";
    int randomCoffee1;

    //2단계용 메뉴 목록 
    private int level2_random;
    private string[] level2_Coffee_menu = { "따뜻한 아메리카노", "아이스 아메리카노", "따뜻한 카페라떼", "아이스 카페라떼" };
    private string[] level2_Toast_menu = { "기본 토스트", "초코 토스트" };
    private string level2_Cube_menu = "4구 큐브케이크";
    int randomCoffee2;
    int randomToast2;

    //3단계용 메뉴 목록 
    private int level3_random;
    private string[] level3_Coffee_menu = { "따뜻한 아메리카노", "아이스 아메리카노", "따뜻한 카페라떼", "아이스 카페라떼", "따뜻한 바닐라라떼", "아이스 바닐라라떼" };
    private string[] level3_Coffee_menu_1 = { "따뜻한 아메리카노", "아이스 아메리카노", "따뜻한 카페라떼", "아이스 카페라떼", "아이스 바닐라라떼" };
    private string[] level3_Toast_menu = { "기본 토스트", "초코 토스트", "딸기 토스트", "블루베리 토스트", "딸기 초코 토스트" };
    private string[] level3_Cube_menu = { "4구 큐브케이크", "5구 큐브케이크", "6구 큐브케이크" };
    int randomCoffee3;
    int randomCoffee3_1;
    int randomToast3;
    int randomToast3_1;
    int randomCube3;

    //4단계용 메뉴 목록 
    private int level4_random;
    private string[] level4_Coffee_menu = { "따뜻한 아메리카노", "아이스 아메리카노", "따뜻한 카페라떼", "아이스 카페라떼", "따뜻한 바닐라라떼", "아이스 바닐라라떼", "따뜻한 카페모카" };
    private string[] level4_Toast_menu = { "딸기 토스트", "블루베리 토스트", "딸기 초코 토스트" };
    private string[] level4_Cube_menu = { "5구 큐브케이크", "6구 큐브케이크", "7구 큐브케이크" };
    int randomCoffee4;
    int randomCoffee4_1;
    int randomToast4;
    int randomToast4_1;
    int randomCube4;

    //5단계용 메뉴 목록 
    private int level5_random;
    private string[] level5_Coffee_menu = { "따뜻한 아메리카노", "아이스 아메리카노", "따뜻한 카페라떼", "아이스 카페라떼", "따뜻한 바닐라라떼", "아이스 카페모카", "아이스 바닐라라떼", "따뜻한 카페모카" };
    private string[] level5_Coffee_menu_1 = { "따뜻한 아메리카노", "아이스 아메리카노", "따뜻한 카페라떼", "아이스 카페라떼", "따뜻한 바닐라라떼",  "아이스 바닐라라떼", "따뜻한 카페모카", "아이스 카페모카"};
    private string[] level5_Toast_menu = { "딸기 토스트", "블루베리 토스트", "딸기 초코 토스트", "냥냥 토스트" };
    private string[] level5_Cube_menu = { "5구 큐브케이크", "6구 큐브케이크", "7구 큐브케이크", "8구 큐브케이크" };
    int randomCoffee5;
    int randomCoffee5_1;
    int randomToast5;
    int randomToast5_1;
    int randomCube5;
    int randomCube5_1;



    //총 4개 메뉴 주문 가능
    public static string OrderMenu1 = "";
    public static string OrderMenu2 = "";
    public static string OrderMenu3 = "";
    public static string OrderMenu4 = "";

    public static int coffeeCount;
    public static int toastCount;
    public static int cubeCount;

    private string m_text;
    private string[] m = new string[4];
    private string[] m_ = { "주", "세", "요", "냥", "~" };


    //Animation animator;

    void Start()
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;


        audioSrc = GetComponent<AudioSource>();
        //this.animator = GetComponent<Animation>().speed = 0.0f;

        //levelText.text = currentLevel.ToString();

        if (currentLevel == 1) //1단계
        {
            randomCoffee1 = Random.Range(0, 3); 
            OrderMenu1 = level1_Coffee_menu[randomCoffee1];
            ++coffeeCount;
            OrderMenu2 = level1_Cube_menu;
            ++cubeCount;
        }
        else if(currentLevel == 2) //2단계
        {
            
            level2_random = Random.Range(1, 3); 
            randomCoffee2 = Random.Range(0, 4);
            randomToast2 = Random.Range(0, 2);

            switch (level2_random)
            {
                case 1:
                    OrderMenu1 = level2_Coffee_menu[randomCoffee2];
                    ++coffeeCount;
                    OrderMenu2 = level2_Cube_menu;
                    ++cubeCount;
                    break;
                case 2:
                    OrderMenu1 = level2_Toast_menu[randomToast2];
                    ++toastCount;
                    OrderMenu2 = level2_Cube_menu;
                    ++cubeCount;
                    break;
            }     
        }
        else if (currentLevel == 3) //3단계
        {

            level3_random = Random.Range(1, 4);
            randomCoffee3 = Random.Range(0, 6);
            randomCoffee3_1 = Random.Range(0, 5);
            randomToast3 = Random.Range(0, 4);
            randomToast3_1 = Random.Range(1, 4);
            randomCube3 = Random.Range(0, 2);

            switch (level3_random)
            {
                case 1:
                    OrderMenu1 = level3_Coffee_menu[randomCoffee3];
                    ++coffeeCount;
                    OrderMenu2 = level3_Toast_menu[randomToast3];
                    ++toastCount;
                    OrderMenu3 = level3_Cube_menu[1];
                    ++cubeCount;
                    break;
                case 2:
                    OrderMenu1 = level3_Coffee_menu_1[randomCoffee3_1];
                    ++coffeeCount;
                    OrderMenu2 = level3_Coffee_menu[4];
                    ++coffeeCount;
                    OrderMenu3 = level3_Cube_menu[randomCube3];
                    ++cubeCount;
                    break;
                case 3:
                    OrderMenu1 = level3_Toast_menu[randomToast3_1];
                    ++toastCount;
                    OrderMenu2 = level3_Toast_menu[4];
                    ++toastCount;
                    OrderMenu3 = level3_Cube_menu[2];
                    ++cubeCount;
                    break;
            }
        }
        else if (currentLevel == 4) //4단계
        {

            level4_random = Random.Range(1, 4);
            randomCoffee4 = Random.Range(5, 7);
            randomCoffee4_1 = Random.Range(0, 5);
            randomToast4 = Random.Range(0, 2);
            randomToast4_1 = Random.Range(1, 3);
            randomCube4 = Random.Range(0, 2);

            switch (level4_random)
            {
                case 1:
                    OrderMenu1 = level4_Coffee_menu[randomCoffee4];
                    ++coffeeCount;
                    OrderMenu2 = level4_Toast_menu[randomToast4];
                    ++toastCount;
                    OrderMenu3 = level4_Cube_menu[randomCube4];
                    ++cubeCount;
                    break;
                case 2:
                    OrderMenu1 = level4_Coffee_menu[randomCoffee4_1];
                    ++coffeeCount;
                    OrderMenu2 = level4_Coffee_menu[6];
                    ++coffeeCount;
                    OrderMenu3 = level4_Cube_menu[randomCube4];
                    ++cubeCount;
                    break;
                case 3:
                    OrderMenu1 = level4_Toast_menu[randomToast4_1];
                    ++toastCount;
                    OrderMenu2 = level4_Cube_menu[1];
                    ++cubeCount;
                    OrderMenu3 = level4_Cube_menu[2];
                    ++cubeCount;
                    break;
            }
        }
        else if (currentLevel == 5) //5단계
        {

            level5_random = Random.Range(1, 5);
            randomCoffee5 = Random.Range(0, 6);
            randomCoffee5_1 = Random.Range(0, 6);
            randomToast5 = Random.Range(2, 4);
            randomToast5_1 = Random.Range(0, 3);
            randomCube5 = Random.Range(0, 2);
            randomCube5_1 = Random.Range(2, 4);

            switch (level5_random)
            {
                case 1:
                    OrderMenu1 = level5_Coffee_menu[randomCoffee5];
                    ++coffeeCount;
                    OrderMenu2 = level5_Coffee_menu[6];
                    ++coffeeCount;
                    OrderMenu3 = level5_Coffee_menu[7];
                    ++coffeeCount;
                    OrderMenu4 = level5_Cube_menu[randomCube5];
                    ++cubeCount;
                    break;
                case 2:
                    OrderMenu1 = level5_Coffee_menu_1[randomCoffee5_1];
                    ++coffeeCount;
                    OrderMenu2 = level5_Coffee_menu_1[7];
                    ++coffeeCount;
                    OrderMenu3 = level5_Toast_menu[randomToast5];
                    ++toastCount;
                    OrderMenu4 = level5_Cube_menu[2];
                    ++cubeCount;
                    break;
                case 3:
                    OrderMenu1 = level5_Coffee_menu_1[7];
                    ++coffeeCount;
                    OrderMenu2 = level5_Toast_menu[randomToast5_1];
                    ++toastCount;
                    OrderMenu3 = level5_Toast_menu[3];
                    ++toastCount;
                    OrderMenu4 = level5_Cube_menu[randomCube5_1];
                    ++cubeCount;
                    break;
                case 4:
                    OrderMenu1 = level5_Coffee_menu_1[randomCoffee5_1];
                    ++coffeeCount;
                    OrderMenu2 = level5_Coffee_menu_1[7];
                    ++coffeeCount;
                    OrderMenu3 = level5_Cube_menu[randomCube5];
                    ++cubeCount;
                    OrderMenu4 = level5_Cube_menu[3];
                    ++cubeCount;
                    break;
            }
        }


        Invoke("BossShowUp", 1f);

    }


    
    void Update()
    {

    }
    void BossShowUp()
    {
        boss.SetActive(true);
        Invoke("BossTalkStart", 1f);
    }
    void BossTalkStart()
    {
        //bossText.text = "좋은 아침입니다~\n오늘 하루도 힘내서 카페를 운영해봅시다~!";
        m_text = "좋은 아침입니다~\n오늘 하루도 힘내서 카페를 운영해봅시다~!";
        StartCoroutine(_typing());
    }
    public void ShowCat()
    {
        audioSrc.PlayOneShot(click, 0.5f); 

        boss.SetActive(false);
        bossPanel.SetActive(false);
        talkPanel.SetActive(true);
        cat1.SetActive(true);
        Invoke("CatTalkStart", 1f); //추후 음성에 맞게 초 수정
    }

    void CatTalkStart()
    {
        

        if (currentLevel == 1) //1단계
        {
            m[0] = "<color=#d85b00>" + OrderMenu1 + "</color>" + "랑 ";
            m[1] = "<color=#d85b00>" + OrderMenu2 + "</color>";
        }
        else if(currentLevel == 2) //2단계
        {
            m[0] = "<color=#d85b00>" + OrderMenu1 + "</color>" + "랑 ";
            m[1] = "<color=#d85b00>" + OrderMenu2 + "</color>";
        }
        else if (currentLevel == 3) //3단계
        {
            
            m[0] = "<color=#d85b00>" + OrderMenu1 + "</color>" + "랑 ";
            m[1] = "<color=#d85b00>" + OrderMenu2 + "</color>" + "랑 ";
            m[2] = "<color=#d85b00>" + OrderMenu3 + "</color>";

        }
        else if (currentLevel == 4) //4단계
        {
            m[0] = "<color=#d85b00>" + OrderMenu1 + "</color>" + "랑 ";
            m[1] = "<color=#d85b00>" + OrderMenu2 + "</color>" + "랑 ";
            m[2] = "<color=#d85b00>" + OrderMenu3 + "</color>";
        }
        else if (currentLevel == 5) //5단계
        {
            m[0] = "<color=#d85b00>" + OrderMenu1 + "</color>" + "랑 ";
            m[1] = "<color=#d85b00>" + OrderMenu2 + "</color>" + "랑 ";
            m[2] = "<color=#d85b00>" + OrderMenu3 + "</color>" + "랑 ";
            m[3] = "<color=#d85b00>" + OrderMenu4 + "</color>";
        }
        StartCoroutine(_typing2());
    }

    IEnumerator _typing()
    {
        yield return new WaitForSeconds(0f);
        for(int i=0; i<= m_text.Length; i++)
        {
            bossText.text = m_text.Substring(0, i);
            yield return new WaitForSeconds(0.07f);
        }
    }
    IEnumerator _typing2()
    {
        yield return new WaitForSeconds(0f);
        for (int i = 0; i < 4; i++)
        {
            talkText.text += m[i];
            yield return new WaitForSeconds(0.3f);
        }
        for (int i = 0; i < 5; i++)
        {
            talkText.text += m_[i];
            yield return new WaitForSeconds(0.07f);
        }
    }
    public void SceneMove()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        SceneManager.LoadScene("MemorizeMenu");
    }
}
