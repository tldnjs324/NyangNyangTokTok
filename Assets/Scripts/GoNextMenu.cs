using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNextMenu : MonoBehaviour
{

    public int now = 0;//현재 만들고 있는 메뉴가 몇번째 메뉴인지
    public static List<int> num = new List<int>() { 0, 1, 2, 3, 4 };
    //각 씬에서 다음 메뉴 씬으로 넘어가는 함수
    public void MoveNextMenuScene()
    {
        Debug.Log("현재 만들고 있는 메뉴는 " + num[0] + "번째 메뉴");
        if (SpecifyNumber.MakingMenu[num[0]] > 19)//만들 메뉴가 고유번호를 받지 못했다면
        {
            SceneManager.LoadScene("PickUpScene");//전달하기 화면으로 이동
        }
        else//고유번호를 받았다면
        {
            for (int i = 0; i < 20; i++)//i는 메뉴의 고유번호
            {
                if (SpecifyNumber.MakingMenu[num[0]] == i)//now+1번째 메뉴가 고유번호 i 메뉴를 받았다면
                {
                    if (i > 13)//14부터 큐브 메뉴 고유번호이다.
                    {
                        int[] randomList = { i, i + 6 };//큐브는 씬이 2개이기 때문에 랜덤으로 돌리기 위한 리스트
                        int rand = Random.Range(0, 2);
                        SceneManager.LoadScene(randomList[rand]+9);//씬 번호는 고유번호 + 9 로 설정해뒀다.

                    }
                    else
                    {
                        SceneManager.LoadScene(i + 9);

                    }
                    
                }
            }
            Debug.Log(num[0]);
            num.RemoveAt(0);
            Debug.Log(num[0]);
            //Debug.Log(now);
            //now++;//씬을 이동했으면 현재 만들고 있는 메뉴 번호를 +해준다
            //Debug.Log(now);
        }
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
