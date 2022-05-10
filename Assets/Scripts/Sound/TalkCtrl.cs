using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkCtrl : MonoBehaviour
{
    AudioSource audioSrc;
    public AudioClip[] MenuVoice;

    int menuCount = 0;//주문한 메뉴 수


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

    public void NaviTalkStart(int x)
    {


        audioSrc.PlayOneShot(MenuVoice[x]);
        WaitForSeconds();
    }
    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(1.0f);
    }











    // Update is called once per frame
    void Update()
    {
        
    }
}
