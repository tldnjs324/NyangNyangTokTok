using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Login : MonoBehaviour
{
    [SerializeField] string email;
    [SerializeField] string password;
    //private int level;

    public InputField inputTextEmail;
    public InputField inputTextPassword;
    public Text loginResult;

    //팝업창
    public GameObject popup_board;
    public GameObject popup_board_join;
    //팝업 메시지
    public Text popup_message;
    public Text popup_message_join;
    //검은 화면
    public GameObject black_screen;
    //게임 시작 버튼
    public GameObject gamestart_btn;

    //AudioClip 소리
    public AudioClip click;
    public AudioClip popup;
    AudioSource audioSrc;

    //private bool ok = true;

    //private bool yes_or_no;

    public static FirebaseAuth auth;//유저정보를 다른 스크립트에서 가져오기 위해 변수를 public static으로 선언

    public static FirebaseUser user;

    //서윤낙서
     bool startBtnDown;
     bool loginBtnDown;
    

    // Start is called before the first frame update
    void Start()
    {
        // 초기화
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);

        //오디오 컴포넌트 가져오기
        audioSrc = GetComponent<AudioSource>();

        


    }


    public int count = 1; //서윤

    private void Update()
    {
        //서윤
        if (startBtnDown)
        {
            SceneManager.LoadScene("IceCafeMocha");
        }


    }
    //서윤
    public void gameStartPressed()
    {
        startBtnDown = true;
    }



    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.Email);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.Email);
            }
        }
    }


    //회원가입 버튼이 눌리면 실행할 함수.
    public void JoinBtnOnClick()
    {
        email = inputTextEmail.text;
        password = inputTextPassword.text;
        //level = 1;

        Debug.Log("email: " + email + ", password: " + password);
        popup_message_join.text = email + "님 \n 회원가입 성공~!\n로그인 후 게임을 이용해주세요";
        CreateUser();
        //1초 뒤에 팝업창 띄우기(CreateUser() 할 시간 벌기... 야매 맞음...)
        StartCoroutine(WaitForJoin());

    }

    //회원가입
    void CreateUser()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                popup_message_join.text = "로그인 형식이 잘못되었거나 \n 이미 가입한 이메일입니다";
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                popup_message_join.text = "로그인 형식이 잘못되었거나 \n 이미 가입한 이메일입니다";
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }


    

    //로그인 버튼이 눌리면 실행할 함수.
    public void LoginBtnOnClick()
    {
        email = inputTextEmail.text;
        password = inputTextPassword.text;

        Debug.Log("email: " + email + ", password: " + password);
        popup_message.text = "로그인 성공~! \n즐거운 게임 되세요냥";//23글자
        LoginUser();
        //1초 뒤에 팝업창 띄우기(LoginUser() 할 시간 벌기)
        StartCoroutine(WaitForSeconds());
        
    }

    //로그인
    void LoginUser()
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                popup_message.text = "비밀번호가 잘못되었거나 \n가입되지 않은 이메일입니다";
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                popup_message.text = "비밀번호가 잘못되었거나 \n가입되지 않은 이메일입니다";
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }

    IEnumerator WaitForSeconds()
    {
        //audioSrc.PlayOneShot(popup, 0.5f);
        yield return new WaitForSeconds(1.0f);
        popup_board.SetActive(true);
        black_screen.SetActive(true);
        if (popup_message.text.Length < 24)
        {
            gamestart_btn.SetActive(true);
        }

    }

    IEnumerator WaitForJoin()
    {
        audioSrc.PlayOneShot(popup, 0.5f);
        yield return new WaitForSeconds(1.0f);
        popup_board_join.SetActive(true);
        black_screen.SetActive(true);
    }

    public void ClosePopup()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        popup_board.SetActive(false);
        black_screen.SetActive(false);
    }

    public void ClosePopupJoin()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        popup_board_join.SetActive(false);
        black_screen.SetActive(false);
    }

    public void GameStart()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        SceneManager.LoadScene("Start");
    }

}


