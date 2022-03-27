using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkAnim : MonoBehaviour
{
    //float time;
    public GameObject hint;

    private void Start()
    {
        StartCoroutine(HintActive());
    }

    IEnumerator HintActive()
    {
        while (true)
        {
            //hint.SetActive(false);
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.7f);
            //hint.SetActive(true);
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.7f);
        }
        
    }

    /*
    void Update()
    {
        if (time < 0.5f)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - time);
            //hint.SetActive(false);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, time);
            //hint.SetActive(true);
            if (time > 1f)
            {
                time = 0;
            }
        }
        time+= Time.deltaTime;
    }
    */
}
