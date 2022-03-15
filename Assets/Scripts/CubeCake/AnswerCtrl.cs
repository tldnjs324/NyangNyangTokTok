using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCtrl : MonoBehaviour
{
    public Text question;
    
    //public Camera CameraR;
    //public Camera CameraF;
    //public Camera CameraA;
    //public Camera CameraL;
    
    private int random;

    //카메라 리스트(오앞위뒤)
    public List<Camera> CameraList = new List<Camera>();

    //카메라 위치 리스트
    public List<Rect> RectList = new List<Rect>() {
        new Rect(0.5f, 0.5f, 0.25f, 0.5f), new Rect(0.5f, 0, 0.25f, 0.5f), new Rect(0.75f, 0, 0.25f, 0.5f), new Rect(0.75f, 0.5f, 0.25f, 0.5f)};

    // Start is called before the first frame update
    void Start()
    {
        //CameraList.Add(CameraR);
        //CameraList.Add(CameraF);
        //CameraList.Add(CameraA);
        //CameraList.Add(CameraL);


        for (int i = 0; i<4; i++)
        {
            int rand = Random.Range(0, RectList.Count);
            CameraList[i].rect = RectList[rand];
            RectList.RemoveAt(rand);
        }
        random = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Randrfal()
    {
        if(random == 0)
        {

        }
    }
}
