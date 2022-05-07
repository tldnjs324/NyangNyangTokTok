using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundCtrl : MonoBehaviour
{

    public AudioClip[] click;
    AudioSource audioSrc;

    public void ClickSounc(int x)
    {
        audioSrc.PlayOneShot(click[x]);
    }
    public void Click_1()
    {
        audioSrc.PlayOneShot(click[1]);
    }
    public void Click_2()
    {
        audioSrc.PlayOneShot(click[2]);
    }
    public void Click_3()
    {
        audioSrc.PlayOneShot(click[3]);
    }
    public void Click_4()
    {
        audioSrc.PlayOneShot(click[4]);
    }
    public void Click_5()
    {
        audioSrc.PlayOneShot(click[5]);
    }
    public void Click_6()
    {
        audioSrc.PlayOneShot(click[6]);
    }
    public void Click_7()
    {
        audioSrc.PlayOneShot(click[7]);
    }
    public void Click_8()
    {
        audioSrc.PlayOneShot(click[8]);
    }
    public void Click_9()
    {
        audioSrc.PlayOneShot(click[9]);
    }
    public void Click_10()
    {
        audioSrc.PlayOneShot(click[10]);
    }
    public void Click_11()
    {
        audioSrc.PlayOneShot(click[11]);
    }
    public void Click_12()
    {
        audioSrc.PlayOneShot(click[12]);
    }
    public void Click_13()
    {
        audioSrc.PlayOneShot(click[13]);
    }
    public void Click_14()
    {
        audioSrc.PlayOneShot(click[14]);
    }
    public void Click_15()
    {
        audioSrc.PlayOneShot(click[15]);
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
