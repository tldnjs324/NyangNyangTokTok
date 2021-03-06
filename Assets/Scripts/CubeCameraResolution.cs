using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCameraResolution : MonoBehaviour
{
    private void Awake()
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        float scaleheight = ((float)Screen.width / Screen.height) / ((float)18.5 / 9);
        float scalewidth = 1f / scaleheight;

        if (Screen.width != 2960 && Screen.height != 1440)
        {
            if (scaleheight < 1)
            {
                rect.height = scaleheight;
                rect.y = (1f - scaleheight) / 2f;
            }
            else
            {
                //rect.width = scalewidth;
                if(scaleheight > 1.15f)
                {
                    rect.x = 0.08f;
                }
                
            }
            camera.rect = rect;
        }

    }
}
