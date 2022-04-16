using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    public Text levelText;
    public GameObject[] count;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = GameManager.currentLevel.ToString();
        for(int i = 0; i<4; i++)
        {
            if(GameManager.currentCount == i)
            {
                count[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
