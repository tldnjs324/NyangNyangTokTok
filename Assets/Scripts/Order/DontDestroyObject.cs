using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
       
        var obj = FindObjectsOfType<DontDestroyObject>();
        if (obj.Length == 1) {
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex > 8)
        {
            Destroy(gameObject);
        }
    }
}
