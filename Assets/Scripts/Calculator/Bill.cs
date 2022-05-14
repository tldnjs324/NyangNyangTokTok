using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Bill : MonoBehaviour
{
    //메뉴 가격 1~4 배열 넣기 위한 변수
    [SerializeField] Text[] menu_price_;
    //메뉴 이름 1~4 배열 넣기 위한 변수
    [SerializeField] Text[] menu_;
    //1의자리수~10000의자리수 변수
    [SerializeField] Text sum_1;
    [SerializeField] Text sum_10;
    [SerializeField] Text sum_100;
    [SerializeField] Text sum_1000;
    [SerializeField] Text sum_10000;

    public GameObject popupStart;
    //맞았을 시 팝업
    public GameObject sign_yes;
    //한번 틀렸을 시/ 두번 틀렸을 시 / 3, 4번 틀렸을 시 / 5번 이상 틀렸을 시 팝업
    public GameObject[] sign_no_;
    //Calculator 가져오기
    private Calculator cal;
    //menu1~4 계산 값(정답)
    string sum_doing = "";
    //틀린 횟수
    int wrong_count = 0;
    //메뉴 가격 넣을 변수
    string menu_price = "";

    //AudioClip 소리
    public AudioClip click;
    public AudioClip correct;
    public AudioClip wrong;
    AudioSource audioSrc;

    public GameObject black_screen;//검은 화면

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartPopup", 0.5f);

        cal = GameObject.Find("Calculator").GetComponent<Calculator>();

        //오디오 컴포넌트 가져오기
        audioSrc = GetComponent<AudioSource>();

        //문자열 길이로 메뉴개수 판단해서 메뉴 이름 및 가격 변수에 넣는 과정
        if (GameManager.OrderMenu3.Length > 2 && GameManager.OrderMenu4.Length < 2) //메뉴 3개
        {
            FindPrice(GameManager.OrderMenu1);
            menu_price_[0].text = menu_price;
            menu_[0].text = GameManager.OrderMenu1;

            FindPrice(GameManager.OrderMenu2);
            menu_price_[1].text = menu_price;
            menu_[1].text = GameManager.OrderMenu2;

            FindPrice(GameManager.OrderMenu3);
            menu_price_[2].text = menu_price;
            menu_[2].text = GameManager.OrderMenu3;
        }
        else if (GameManager.OrderMenu4.Length > 2) //메뉴 4개
        {
            FindPrice(GameManager.OrderMenu1);
            menu_price_[0].text = menu_price;
            menu_[0].text = GameManager.OrderMenu1;

            FindPrice(GameManager.OrderMenu2);
            menu_price_[1].text = menu_price;
            menu_[1].text = GameManager.OrderMenu2;

            FindPrice(GameManager.OrderMenu3);
            menu_price_[2].text = menu_price;
            menu_[2].text = GameManager.OrderMenu3;

            FindPrice(GameManager.OrderMenu4);
            menu_price_[3].text = menu_price;
            menu_[3].text = GameManager.OrderMenu4;
        }
        else //메뉴 2개
        {
            FindPrice(GameManager.OrderMenu1);
            menu_price_[0].text = menu_price;
            menu_[0].text = GameManager.OrderMenu1;

            FindPrice(GameManager.OrderMenu2);
            menu_price_[1].text = menu_price;
            menu_[1].text = GameManager.OrderMenu2;
        }

        sum_doing = (int.Parse(menu_price_[0].text) + int.Parse(menu_price_[1].text) + int.Parse(menu_price_[2].text) + int.Parse(menu_price_[3].text)).ToString();

        //총 가격이 10000원이 넘지 않는다면 10000의 자리 빈칸 모양 없애기
        if (int.Parse(sum_doing) < 10000)
        {
            sum_10000.text = null;
        }
        //가격이 0인 곳은 빈칸 만들기
        for (int i = 0; i < 4; i++)
        {
            if (int.Parse(menu_price_[i].text) < 1)
            {
                menu_price_[i].text = "";
            }
        }
    }
    void StartPopup()
    {
        Popup pop = popupStart.GetComponent<Popup>();
        pop.PopUp();
    }

    void FindPrice(string menu)
    {
        switch (menu)
        {
            case "따뜻한 아메리카노":
                menu_price = "2000";
                break;
            case "아이스 아메리카노":
                menu_price = "2000";
                break;
            case "따뜻한 카페라떼":
                menu_price = "3000";
                break;
            case "아이스 카페라떼":
                menu_price = "3500";
                break;
            case "따뜻한 바닐라라떼":
                menu_price = "4200";
                break;
            case "아이스 바닐라라떼":
                menu_price = "4700";
                break;
            case "따뜻한 카페모카":
                menu_price = "5100";
                break;
            case "아이스 카페모카":
                menu_price = "5600";
                break;

            case "기본 토스트":
                menu_price = "1000";
                break;
            case "초코 토스트":
                menu_price = "2000";
                break;
            case "딸기 토스트":
                menu_price = "2500";
                break;
            case "블루베리 토스트":
                menu_price = "2500";
                break;
            case "딸기 초코 토스트":
                menu_price = "2700";
                break;
            case "냥냥 토스트":
                menu_price = "2900";
                break;

            case "3구 큐브케이크":
                menu_price = "5000";
                break;
            case "4구 큐브케이크":
                menu_price = "6500";
                break;
            case "5구 큐브케이크":
                menu_price = "7900";
                break;
            case "6구 큐브케이크":
                menu_price = "9200";
                break;
            case "7구 큐브케이크":
                menu_price = "10400";
                break;
            case "8구 큐브케이크":
                menu_price = "11500";
                break;
        }
    }

    //정답 확인 버튼 눌러서 맞았는지 비교
    public void Compare()
    {
        if (cal.InputField.text == sum_doing)//정답이라면
        {
            //1, 10, 100, 1000, 10000의자리 수 전부 표시
            sum_1.text = (int.Parse(sum_doing) % 10).ToString();//그냥 '0'이라 해도 됨
            sum_10.text = ((int.Parse(sum_doing) % 100) / 10).ToString();
            sum_100.text = ((int.Parse(sum_doing) % 1000) / 100).ToString();
            sum_1000.text = ((int.Parse(sum_doing) % 10000) / 1000).ToString();
            if (int.Parse(sum_doing) >= 10000)
            {
                sum_10000.text = (int.Parse(sum_doing) / 10000).ToString();
            }

            //sum_Result.text = sum_doing;
            sign_yes.SetActive(true);
            //StartCoroutine(WaitForYes());

            audioSrc.PlayOneShot(correct, 0.5f);
            black_screen.SetActive(true);
        }
        else//틀렸다면
        {
            cal.InputField.text = "0";//텍스트 필드 0으로
            wrong_count++;//틀린 수 세기
            if (wrong_count == 1)//한번 틀리면 그냥 다시하라고 함
            {
                sign_no_[0].SetActive(true);//한번 틀린 팝업
                MoveLevel.wrongCount += 1;
                //StartCoroutine(WaitForNo(0));
            }
            else if (wrong_count == 2)//두번 틀리면 1000의 자리수 알려줌
            {
                sign_no_[1].SetActive(true);//두번 틀린 팝업
                //StartCoroutine(WaitForNo(1));
                sum_1000.text = ((int.Parse(sum_doing) % 10000) / 1000).ToString();
            }
            else if (wrong_count == 3)//세번 틀리면 100의자리 수 알려줌
            {
                sign_no_[2].SetActive(true);//3, 4번 틀린 팝업
                //StartCoroutine(WaitForNo(2));
                sum_100.text = ((int.Parse(sum_doing) % 1000) / 100).ToString();
            }
            else if (wrong_count == 4)//네번 틀리면 10의자리 수 알려줌
            {
                sign_no_[2].SetActive(true);//3, 4번 틀린 팝업
                //StartCoroutine(WaitForNo(2));
                sum_10.text = ((int.Parse(sum_doing) % 100) / 10).ToString();
            }
            else if (wrong_count == 5)//다섯번 틀리면 1의자리 수, 10000보다 클 시 10000의자리 수 까지 알려줌
            {
                sign_no_[3].SetActive(true);//다섯번 이상 틀린 팝업
                //StartCoroutine(WaitForNo(3));
                sum_1.text = (int.Parse(sum_doing) % 10).ToString();
                if (int.Parse(sum_doing) >= 10000)
                {
                    sum_10000.text = (int.Parse(sum_doing) / 10000).ToString();
                }

            }
            else//다섯번 넘게 틀리면 답을 빨간색으로 적어줌
            {
                sign_no_[3].SetActive(true);//다섯번 이상 틀린 팝업
                //StartCoroutine(WaitForNo(3));
                sum_1.text = "<color=#D85B00>" + sum_1.text + "</color>";
                sum_10.text = "<color=#D85B00>" + sum_10.text + "</color>";
                sum_100.text = "<color=#D85B00>" + sum_100.text + "</color>";
                sum_1000.text = "<color=#D85B00>" + sum_1000.text + "</color>";
                sum_10000.text = "<color=#D85B00>" + sum_10000.text + "</color>";
            }

            audioSrc.PlayOneShot(wrong, 0.5f);
            black_screen.SetActive(true);
        }

    }

    //닫기 버튼 누를 때
    public void Close_No(int num)
    {
        sign_no_[num].SetActive(false);
        audioSrc.PlayOneShot(click, 0.5f);
        black_screen.SetActive(false);
    }

    public void NextScene()
    {
        //씬 넘어가는 코드
    }
    /*
    IEnumerator WaitForYes()
    {
        yield return new WaitForSeconds(3.0f);
        //씬 넘어가는 코드

    }
    
    IEnumerator WaitForNo(int num)
    {
        yield return new WaitForSeconds(3.0f);
        sign_no_[num].SetActive(false);
    }
    */



    // Update is called once per frame
    void Update()
    {

    }
}
