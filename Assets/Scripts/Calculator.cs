using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
}
