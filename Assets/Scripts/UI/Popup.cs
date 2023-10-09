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
    public void PopUp6() //전달하기 count
    {
        popup.SetActive(true);
        animator.SetTrigger("ppop");
    }
    public void PopUp7() //전달하기 level
    {
        popup.SetActive(true);
        animator.SetTrigger("lpop");
    }

}
