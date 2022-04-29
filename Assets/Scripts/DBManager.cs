using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    public int level = 1;
    public int count = 0;
    public int heart = 0;
    

    public void SaveDate()
    {
        PlayerPrefs.SetInt("tmpLevel", level);
        PlayerPrefs.SetInt("tmpCount", count);
        PlayerPrefs.SetInt("tmpHeart", heart);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
