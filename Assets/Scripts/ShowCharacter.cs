using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCharacter : MonoBehaviour
{
    void Start()
    {
       
        
    }
    
    void Update()
    {
        if (transform.position.y < 0.0f)
        {
            transform.Translate(0, 0.1f, 0);
        }
       
    }
}
