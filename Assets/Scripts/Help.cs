using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public GameObject Help_Popup;

    //AudioClip 소리
    public AudioClip popup;
    public AudioClip click;
    AudioSource audioSrc;

    //검은 화면
    public GameObject black_screen;

    public void Help_Click()
    {
        //Help_Popup.SetActive(true);
        Popup pop = Help_Popup.GetComponent<Popup>();
        pop.PopUp();
        audioSrc.PlayOneShot(popup, 0.5f);
        //black_screen.SetActive(true);
    }
    public void Close_Help()
    {
        //Help_Popup.SetActive(false);
        audioSrc.PlayOneShot(click, 0.5f);
        //black_screen.SetActive(false);
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
