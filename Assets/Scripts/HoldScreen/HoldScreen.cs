using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setupScreen()
    {
        //가로 화면 비율
        float targetWidthAspect = 37.0f;
        //세로 화면 비율
        float targetHeightAspect = 18.0f;

        Camera mainCamera = Camera.main;
        mainCamera.aspect = targetWidthAspect / targetHeightAspect;

        float heightRatio = (float)Screen.width / targetWidthAspect;
        float widthRatio = (float)Screen.height / targetWidthAspect;

        float heightadd = ((widthRatio / (heightRatio / 100)) - 100) / 200;
        float widthadd = ((heightRatio / (widthRatio / 100)) - 100) / 200;

        if (heightRatio > widthRatio)
        {
            widthadd = 0.0f;
        }
        else
        {
            heightadd = 0.0f;
        }

        mainCamera.rect = new Rect(
            mainCamera.rect.x + Mathf.Abs(widthadd),
            mainCamera.rect.y + Mathf.Abs(heightadd),
            mainCamera.rect.width + (widthadd * 2),
            mainCamera.rect.height + (heightadd * 2));
    }
}
