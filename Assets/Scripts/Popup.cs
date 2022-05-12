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
    public void PopUp2() //레시피용(타이머포함)
    {
        popup.SetActive(true);
        animator.SetTrigger("pop2");
    }


}
