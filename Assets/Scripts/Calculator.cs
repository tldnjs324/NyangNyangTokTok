using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Calculator : MonoBehaviour
{
    [SerializeField]
    public Text InputField;

    string InputString;

    //AudioClip 소리
    public AudioClip click;
    AudioSource audioSrc;

    public void ButtonPressed()
    {
        audioSrc.PlayOneShot(click, 0.5f);//숫자버튼 누를 때 클릭 소리

        Debug.Log(EventSystem.current.currentSelectedGameObject.name);

        string buttonValue = EventSystem.current.currentSelectedGameObject.name;
        
        InputString = buttonValue;

        if(InputField.text == "0")
        {
            if(InputString == "00")
            {
                InputField.text = "0";
            }
            else
            {
                InputField.text = InputString;
            }
            
        }
        else
        {
            InputField.text += InputString;
        }
        
    }

    public void BackSpace()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        InputField.text = (int.Parse(InputField.text)/10).ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        //오디오 컴포넌트 가져오기
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextBtn()
    {
        //audioSrc.PlayOneShot(click, 0.5f);
        if (GameManager.OrderMenu1 == "따뜻한 아메리카노")
        {
            SceneManager.LoadScene("HotAmericano");
        }
        else if (GameManager.OrderMenu1 == "아이스 아메리카노")
        {
            SceneManager.LoadScene("IceAmericano");
        }
        else if (GameManager.OrderMenu1 == "따뜻한 카페라떼")
        {
            SceneManager.LoadScene("HotLatte");
        }
        else if (GameManager.OrderMenu1 == "아이스 카페라떼")
        {
            SceneManager.LoadScene("IceLatte");
        }
        else if (GameManager.OrderMenu1 == "따뜻한 바닐라라떼")
        {
            SceneManager.LoadScene("HotVanillaLatte");
        }
        else if (GameManager.OrderMenu1 == "아이스 바닐라라떼")
        {
            SceneManager.LoadScene("IceVanillaLatte");
        }
        else if (GameManager.OrderMenu1 == "따뜻한 카페모카")
        {
            SceneManager.LoadScene("HotCafeMocha");
        }
        else if (GameManager.OrderMenu1 == "아이스 카페모카")
        {
            SceneManager.LoadScene("IceCafeMocha");
        }
        else if (GameManager.OrderMenu1 == "기본 토스트")
        {
            SceneManager.LoadScene("BasicToast");
        }
        else if (GameManager.OrderMenu1 == "초코 토스트")//
        {
            SceneManager.LoadScene("IceAmericano");
        }
        else if (GameManager.OrderMenu1 == "딸기 토스트")
        {
            SceneManager.LoadScene("IceAmericano");
        }
        else if (GameManager.OrderMenu1 == "블루베리 토스트")
        {
            SceneManager.LoadScene("IceAmericano");
        }
        else if (GameManager.OrderMenu1 == "딸기 블루베리 토스트")
        {
            SceneManager.LoadScene("IceAmericano");
        }
        else if (GameManager.OrderMenu1 == "냥냥 토스트")
        {
            SceneManager.LoadScene("IceAmericano");
        }
    }
}
