using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;
using Firebase;
using Firebase.Auth;

public class MoveLevel : MonoBehaviour
{
    DatabaseReference databaseReference;

    public static int wrongCount = 0;

    public void MovingLevel()
    {
        if(wrongCount == 0)//한번도 틀리지 않았을 때
        {
            GameManager.currentCount += 1;//카운트 올리고
            if (GameManager.currentCount == 3)//카운트가 3 채워졌을 때 레벨 올려야 함
            {
                if(GameManager.currentLevel < 5)//레벨 5가 아닐 때
                {
                    GameManager.currentLevel += 1;//현재 레벨을 올리고!
                    LevelUp(GameManager.currentLevel);//데베에 레벨 업데이트!
                    CountUp(0);//데베에 카운트 0으로 업데이트! 3개가 차면 레벨업 후 다시 0이 되기 때문
                    
                    //팝업 띄우기
                    
                }else if (GameManager.currentLevel == 5){//레벨5인데 또 3개 카운트 채운 경우
                    //사장님 나타나서 고맙다는 인사와 함께 계속해달라는 메시지 전하기
                }
            }
            else//카운트가 1이나 2로 채워졌을 때
            {
                CountUp(GameManager.currentCount);//데베에 카운트 업데이트
                //팝업 띄우기
            }
        }
        else//한번이라도 틀리면 발자국, 레벨업 없음. 사장님이랑 인사하고 출근하기ㄱㄱ
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    //전달하기 끝나고 레벨업하는 부분에서 데베에 카운트 올릴 코드
    public void CountUp(int count)
    {
        var DBTask = databaseReference.Child("users").Child("count").SetValueAsync(count);
        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //count is now updated
        }
    }

    //전달하기 끝나고 레벨업하는 부분에서 데베에 레벨 올릴 코드
    public void LevelUp(int level)
    {
        var DBTask = databaseReference.Child("users").Child("level").SetValueAsync(level);
        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //level is now updated
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
