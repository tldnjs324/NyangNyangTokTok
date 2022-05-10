using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkCtrl : MonoBehaviour
{
    AudioSource audioSrc;
    public AudioClip[] NaviMenuVoice;
    public AudioClip NaviPlease;

    int menuCount = 0;//주문한 메뉴 수
    float time = 1.2f;

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

    public void NaviTalkStart()
    {
        WaitForTalk();
        for (int i = 0; i<menuCount; i++)
        {
            Invoke("NaviTalkMenu", time*i+1);
        }
        Invoke("NaviTalkPlease", time*menuCount+1);
    }


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
    public void NaviTalkPlease()
    {
        audioSrc.PlayOneShot(NaviPlease);
    }

    IEnumerator WaitForTalk()
    {
        yield return new WaitForSeconds(1.0f);
    }
    IEnumerator WaitForSeconds(int x)
    {
        yield return new WaitForSeconds(x);
    }











    // Update is called once per frame
    void Update()
    {
        
    }
}
