using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Starting : MonoBehaviour
{
    public AudioClip btnAudio;
    AudioSource audioSrc;

    public void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        GameManager.ResetMenu();
    }

    public void StartBtn()
    {
        audioSrc.PlayOneShot(btnAudio,0.5f);
        SceneLoad.LoadScene("LevelMap");
    }
}

