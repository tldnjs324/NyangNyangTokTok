using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Bill1 : MonoBehaviour
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
    //string menu_price = "";

    //AudioClip 소리
    public AudioClip click;
    public AudioClip correct;
    public AudioClip wrong;
    AudioSource audioSrc;

    public GameObject black_screen;//검은 화면

    public Text bossText;
    public GameObject bossPanel;
    public GameObject boss;
    private string m_text;
    public GameObject focus1;
    public GameObject focus2;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("BossTalk", 1f);

        cal = GameObject.Find("Calculator").GetComponent<Calculator>();

        //오디오 컴포넌트 가져오기
        audioSrc = GetComponent<AudioSource>();

        //문자열 길이로 메뉴개수 판단해서 메뉴 이름 및 가격 변수에 넣는 과정
        menu_price_[0].text = "2000";
        menu_[0].text = GameManager1.OrderMenu1; //아아

        menu_price_[1].text = "5000";
        menu_[1].text = GameManager1.OrderMenu2;//3구


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
    public void BossTalk()
    {
        if (i == 0)
        {
            m_text = "이제 주문 받은 메뉴들의 총 가격을 계산해 볼 거예요!";
            StartMethod();
            i++;
        }
        else if (i == 1)
        {
            StopMethod();
            boss.SetActive(false);
            focus1.SetActive(true); //계산서
            m_text = "계산서에 나온 메뉴의 가격을 모두 더해서 숫자를 입력해주세요~";
            StartMethod();
            i++;
        }
        else if (i == 2)
        {
            
            focus1.SetActive(false);
            bossPanel.SetActive(false);
        }
    }
    IEnumerator _typing()
    {
        yield return new WaitForSeconds(0f);
        for (int i = 0; i <= m_text.Length; i++)
        {
            bossText.text = m_text.Substring(0, i);
            yield return new WaitForSeconds(0.07f);
        }
    }
    IEnumerator coroutine;
    void StartMethod()
    {
        coroutine = _typing();
        StartCoroutine(coroutine);
    }
    void StopMethod()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
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
        audioSrc.PlayOneShot(click, 0.5f);
        SceneManager.LoadScene("T_IceAmericano");
    }

}
