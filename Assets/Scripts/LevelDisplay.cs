using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    //public Text levelText;
    public Text heartText;//하트 표시 글자
    public GameObject[] level;//레벨 표시되어있는 발자국
    public GameObject[] count;//카운트 표시

    public GameObject[] HelpPopup;//하트, 발자국, 도움말 팝업
    public GameObject HeartEffect;
    public GameObject StepsEffect;
    public GameObject BlackScreen;
    

    // Start is called before the first frame update
    void Start()
    {
        Display();
    }

    public void Display()
    {
        //현재 하트 가져와서 상단바에 표시
        heartText.text = GameManager.currentHeart.ToString();
        //현재 레벨 가져와서 상단바에 표시
        for (int i = 1; i < 6; i++)
        {
            if (GameManager.currentLevel == i)
            {
                level[i-1].SetActive(true);
            }
        }
        //현재 발자국 개수 가져와서 상단바에 표시
        for (int i = 0; i < 4; i++)
        {
            if (GameManager.currentCount == i)
            {
                count[i].SetActive(true);
            }
        }
    }

    public void OpenHeartHelp()
    {
        Popup pop = HeartEffect.GetComponent<Popup>();
        pop.PopUp();
        Invoke("ShowGif1", 0.5f);
        //HelpPopup[0].SetActive(true);
        //BlackScreen.SetActive(true);
    }
    public void OpenStepsHelp()
    {
        Popup pop = StepsEffect.GetComponent<Popup>();
        pop.PopUp();
        Invoke("ShowGif2", 0.5f);
    }
    void ShowGif1()
    {
        HelpPopup[0].SetActive(true);
    }
    void ShowGif2()
    {
        HelpPopup[1].SetActive(true);
    }

    public void OpenHelp()
    {
        Popup pop = HelpPopup[2].GetComponent<Popup>();
        pop.PopUp5();
        //HelpPopup[2].SetActive(true);
        //BlackScreen.SetActive(true);
    }

    public void CloseHelp()
    {
        for(int i = 0; i<3; i++)
        {
            HelpPopup[i].SetActive(false);
            BlackScreen.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
