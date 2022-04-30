using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkAnim : MonoBehaviour
{
    private IEnumerator coroutine;
    public GameObject hint;
    //int cnt = 1;
    
    private void Start()
    {
        //coroutine = HintActive();
        //StartCoroutine(coroutine);
    }
    private void Awake()
    {
        coroutine = HintActive();
        StartCoroutine(coroutine);
    }


    
    IEnumerator HintActive()
    {
        while (true)
        {
            GetComponent<Image>().color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.7f);

            GetComponent<Image>().color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.7f);
        }
        
    }

}
