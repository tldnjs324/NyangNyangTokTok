using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{

    public bool IsSave;//저장된 데이터가 있는지 확인하기 위한 불값



    public void LoadData()
    {
        IsSave = PlayerPrefs.HasKey("tmpLevel");

        //세이브 데이터가 없다면 모든 데이터 값을 초기화
        if (!IsSave)
        {
            Debug.Log("저장된 데이터 없음");
            GameManager.currentLevel = 1;
            GameManager.currentCount = 0;
            GameManager.currentHeart = 0;
            MapManager.firstT = 0;
            MapManager.secondT = 0;
            Debug.Log("레벨: " + GameManager.currentLevel);
            Debug.Log("카운트: " + GameManager.currentCount);
            Debug.Log("하트: " + GameManager.currentHeart);
            Debug.Log("튜토리얼1: " + MapManager.firstT);
            Debug.Log("튜토리얼2: " + MapManager.secondT);
            //level = 3;
            //count = 0;
            //heart = 0;
        }
        else
        {
            Debug.Log("저장된 데이터 있음");
            GameManager.currentLevel = PlayerPrefs.GetInt("tmpLevel");
            GameManager.currentCount = PlayerPrefs.GetInt("tmpCount");
            GameManager.currentHeart = PlayerPrefs.GetInt("tmpHeart");
            MapManager.firstT = PlayerPrefs.GetInt("tmpFirstT");
            MapManager.secondT = PlayerPrefs.GetInt("tmpSecondT");
            Debug.Log("레벨: " + GameManager.currentLevel);
            Debug.Log("카운트: " + GameManager.currentCount);
            Debug.Log("하트: " + GameManager.currentHeart);
            Debug.Log("튜토리얼1: " + MapManager.firstT);
            Debug.Log("튜토리얼2: " + MapManager.secondT);
        }
        //GameManager.currentLevel = int.Parse(PlayerPrefs.GetInt("tmpLevel", 3).ToString());
        
    }

    //데이터 삭제
    void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }

    //데이터 저장
    public void SaveData()
    {
        PlayerPrefs.SetInt("tmpLevel", GameManager.currentLevel);
        PlayerPrefs.SetInt("tmpCount", GameManager.currentCount);
        PlayerPrefs.SetInt("tmpHeart", GameManager.currentHeart);
        PlayerPrefs.SetInt("tmpFirstT", MapManager.firstT);
        PlayerPrefs.SetInt("tmpSecondT", MapManager.secondT);
        PlayerPrefs.Save();//PlayerPrefs를 저장
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
