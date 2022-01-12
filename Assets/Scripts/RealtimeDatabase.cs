using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Unity.Editor;
using Firebase.Database;
using Firebase;

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
