using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PickUpManager : MonoBehaviour
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

    private string m_text;


    void Start()
    {

        audioSrc = GetComponent<AudioSource>();
        //this.animator = GetComponent<Animation>().speed = 0.0f;

        Invoke("CatShowUp", 1f);

    }
    
    void Update()
    {

    }
    void CatShowUp()
    {
        boss.SetActive(true);
        Invoke("CatTalkStart", 1f);
    }
    void CatTalkStart()
    {
        m_text = "좋은 아침입니다~\n오늘 하루도 힘내서 카페를 운영해봅시다~!";
        if(SpecifyNumber.MakingMenu[0] <= 7)//커피 메뉴를 시켰을 때 
        {

        }
        StartCoroutine(_typing());
    }
    public void ShowBoss()
    {
        audioSrc.PlayOneShot(click, 0.5f); 

        cat1.SetActive(false);
        talkPanel.SetActive(false);
        talkPanel.SetActive(true);
        cat1.SetActive(true);
        Invoke("BossTalkStart", 1f); //추후 음성에 맞게 초 수정
    }



    IEnumerator _typing()
    {
        for(int i=0; i<= m_text.Length; i++)
        {
            bossText.text = m_text.Substring(0, i);
            yield return new WaitForSeconds(0.07f);
        }
    }


}
