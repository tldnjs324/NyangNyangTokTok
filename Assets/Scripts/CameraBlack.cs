using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBlack : MonoBehaviour
{
    void OnPreCull() => GL.Clear(true, true, Color.black);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
