using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkAnim : MonoBehaviour
{
    public GameObject hint;


    private void Start()
    {
        StartCoroutine(HintActive());
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
