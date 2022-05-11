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

    public void PopUp()
    {
        popup.SetActive(true);
        animator.SetTrigger("pop");
    }

    
}
