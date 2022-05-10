using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkCtrl : MonoBehaviour
{
    AudioSource audioSrc;
    
    //나비 목소리
    public AudioClip[] NaviMenuVoice;
    public AudioClip NaviPlease;
    
    //냐옹 목소리
    public AudioClip[] NyaongMenuVoice;
    public AudioClip NyaongPlease;

    //체리 목소리
    public AudioClip[] CherryMenuVoice;
    public AudioClip CherryPlease;

    int menuCount = 0;//주문한 메뉴 수
    float time = 1.2f;//말하는 시간
    int random;

    public static List<int> num = new List<int>() { 0, 1, 2, 3 };

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        if (SpecifyNumber.MakingMenu[2] > 19)//3번째 메뉴가 고유번호를 받지 못했을 때(주문한 메뉴가 2개일 때)
        {
            menuCount = 2;
        }else if(SpecifyNumber.MakingMenu[3] > 19)//4번째 메뉴가 고유번호를 받지 못했을 때(주문한 메뉴가 3개일 때)
        {
            menuCount = 3;
        }
        else//주문한 메뉴가 4개일 때
        {
            menuCount = 4;
        }

    }

    public void CatTalkStart()
    {
        if(GameManager.random == 0)
        {
            Invoke("NaviTalkStart", 1);
        }else if (GameManager.random == 1)
        {
            Invoke("NyaongTalkStart", 1);
        }
        else
        {
            Invoke("CherryTalkStart", 1);
        }


    }

    //나비 말하게 하기
    public void NaviTalkStart()
    {
        for (int i = 0; i<menuCount; i++)
        {
            Invoke("NaviTalkMenu", time*i);
        }
        Invoke("NaviTalkPlease", time*menuCount);
    }
    //나비 메뉴 말하기
    public void NaviTalkMenu()
    {
        for (int i = 0; i < 20; i++)//i는 메뉴의 고유번호
        {
            if (SpecifyNumber.MakingMenu[num[0]] == i)//num[0]+1번째 메뉴가 고유번호 i 메뉴를 받았다면
            {
                audioSrc.PlayOneShot(NaviMenuVoice[i]);
            }
        }
        num.RemoveAt(0);
    }
    //나비 주세요 말하기
    public void NaviTalkPlease()
    {
        audioSrc.PlayOneShot(NaviPlease);
    }

    //냐옹 말하게 하기
    public void NyaongTalkStart()
    {
        for (int i = 0; i < menuCount; i++)
        {
            Invoke("NyaongTalkMenu", time * i);
        }
        Invoke("NyaongTalkPlease", time * menuCount);
    }
    //냐옹 메뉴 말하기
    public void NyaongTalkMenu()
    {
        for (int i = 0; i < 20; i++)//i는 메뉴의 고유번호
        {
            if (SpecifyNumber.MakingMenu[num[0]] == i)//num[0]+1번째 메뉴가 고유번호 i 메뉴를 받았다면
            {
                audioSrc.PlayOneShot(NyaongMenuVoice[i]);
            }
        }
        num.RemoveAt(0);
    }
    //냐옹 주세요 말하기
    public void NyaongTalkPlease()
    {
        audioSrc.PlayOneShot(NyaongPlease);
    }

    //체리 말하게 하기
    public void CherryTalkStart()
    {
        for (int i = 0; i < menuCount; i++)
        {
            Invoke("CherryTalkMenu", time * i);
        }
        Invoke("CherryTalkPlease", time * menuCount);
    }
    //나비 메뉴 말하기
    public void CherryTalkMenu()
    {
        for (int i = 0; i < 20; i++)//i는 메뉴의 고유번호
        {
            if (SpecifyNumber.MakingMenu[num[0]] == i)//num[0]+1번째 메뉴가 고유번호 i 메뉴를 받았다면
            {
                audioSrc.PlayOneShot(CherryMenuVoice[i]);
            }
        }
        num.RemoveAt(0);
    }
    //나비 주세요 말하기
    public void CherryTalkPlease()
    {
        audioSrc.PlayOneShot(CherryPlease);
    }











    // Update is called once per frame
    void Update()
    {
        
    }
}
