using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public GameObject popup;
    public Animator animator;
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    public void PopUp() //일반팝업용
    {
        popup.SetActive(true);
        animator.SetTrigger("pop");
    }
    public void PopUp2() //만들기 스타트용
    {
        popup.SetActive(true);
        animator.SetTrigger("spop");
    }
    public void PopUp3() //외우기 스타트
    {
        popup.SetActive(true);
        animator.SetTrigger("mpop");
    }
    public void PopUp4() //메뉴고르기 도움말
    {
        popup.SetActive(true);
        animator.SetTrigger("opop");
    }
    public void PopUp5() //큐브 도움말
    {
        popup.SetActive(true);
        animator.SetTrigger("chpop");
    }

}
