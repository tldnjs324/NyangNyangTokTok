using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundCtrl : MonoBehaviour
{
    //효과음
    public AudioClip[] click;
    //시작 팝업 읽어주기
    public AudioClip firstSound;
    AudioSource audioSrc;

    public void ClickSound(int x)
    {
        audioSrc.PlayOneShot(click[x]);
    }

    public void PopupSound()
    {
        audioSrc.PlayOneShot(click[0]);
    }
    public void ClickBtn()
    {
        audioSrc.PlayOneShot(click[1]);
    }
    public void TrueBtn()
    {
        audioSrc.PlayOneShot(click[2]);
    }
    public void FalseBtn()
    {
        audioSrc.PlayOneShot(click[3]);
    }
    public void CupBtn()
    {
        audioSrc.PlayOneShot(click[4]);
    }
    public void IceBtn()
    {
        audioSrc.PlayOneShot(click[5]);
    }
    public void WaterBtn()
    {
        audioSrc.PlayOneShot(click[6]);
    }
    public void CoffeeMachineBtn()
    {
        audioSrc.PlayOneShot(click[7]);
    }
    public void SyrupBtn()
    {
        audioSrc.PlayOneShot(click[8]);
    }
    public void CreamBtn()
    {
        audioSrc.PlayOneShot(click[9]);
    }
    public void BreadOutBtn()
    {
        audioSrc.PlayOneShot(click[10]);
    }
    public void ToasterBtn()
    {
        audioSrc.PlayOneShot(click[11]);
    }
    public void JamBtn()
    {
        audioSrc.PlayOneShot(click[12]);
    }
    public void FruitBtn()
    {
        audioSrc.PlayOneShot(click[13]);
    }
    public void StepPopup()
    {
        audioSrc.PlayOneShot(click[14]);
    }
    public void StepUp()
    {
        audioSrc.PlayOneShot(click[15]);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        Invoke("FirstTalk", 0.5f);
    }

    public void FirstTalk()
    {
        audioSrc.PlayOneShot(firstSound);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
