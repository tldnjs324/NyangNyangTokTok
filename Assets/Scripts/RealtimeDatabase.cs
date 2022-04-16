using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Unity.Editor;
using Firebase.Database;
using Firebase;
using Firebase.Auth;

public class RealtimeDatabase : MonoBehaviour
{
    FirebaseApp firebaseApp;
    DatabaseReference databaseReference;

    // Start is called before the first frame update
    void Awake()
    {
        firebaseApp = FirebaseDatabase.DefaultInstance.App;
        firebaseApp.SetEditorDatabaseUrl("https://nyangnyang-2b3a0-default-rtdb.firebaseio.com/");
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;


        //FirebaseApp.DefaultInstance.SetEditorFileName("NyangNyang.p12");

        FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");
    }


    public void InitDatabase()
    {
        if (Login.user != null)
        {
            WriteNewUser(Login.user.UserId, Login.user.Email);
        }
    }
    
    private void WriteNewUser(string uid, string email)
    {
        User user = new User(email);
        string json = JsonUtility.ToJson(user);
        databaseReference.Child("users").Child(uid).SetRawJsonValueAsync(json);

        
    }



    public void LoadLevel()
    {
        //얘네는 추가하는 코드
        //string key = databaseReference.Child("level").Push().Key;
        //databaseReference.Child("users").Child(userId).Child("level").SetValueAsync(level);

        //DB 가져오는 
        var DBTask1 = databaseReference.Child("users").Child(Login.user.UserId).OrderByChild("level").GetValueAsync();
        var DBTask2 = databaseReference.Child("users").Child(Login.user.UserId).OrderByChild("count").GetValueAsync();
        databaseReference.GetValueAsync().ContinueWith(task => {

            if (task.IsCompleted)
            { // 성공적으로 데이터를 가져왔으면
                DataSnapshot snapshot1 = DBTask1.Result;
                DataSnapshot snapshot2 = DBTask2.Result;
                // 데이터를 출력하고자 할때는 Snapshot 객체 사용함

                foreach (DataSnapshot childSnapshot in snapshot1.Children)
                {
                    //레벨이랑 카운트 snapshot으로 데베에서 가져옴
                    int level = int.Parse(childSnapshot.Child("level").Value.ToString());
                    Debug.Log("레벨 가져옴");
                    GameManager.currentLevel = level;//가져온 레벨 게임메니저 현재 레벨에 저장
                    Debug.Log("레벨 변경");
                }
                foreach (DataSnapshot childSnapshot in snapshot2.Children)
                {
                    //레벨이랑 카운트 snapshot으로 데베에서 가져옴
                    int count = int.Parse(childSnapshot.Child("count").Value.ToString());
                    Debug.Log("카운트 가져옴");
                    GameManager.currentCount = count;//가져온 카운트 게임메니저 현재 카운트에 저장
                    Debug.Log("카운트 변경");
                }
            }
        });
    }

    /*
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
    }*/

    public class User
    {
        //public string name;
        public string email;
        public int level;
        public int count;

        public User()
        {
        }

        public User(string email)
        {
            //this.name = name;
            this.email = email;
            this.level = 1;
            this.count = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
