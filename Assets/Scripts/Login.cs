using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    [SerializeField] string email;
    [SerializeField] string password;
    [SerializeField] int level;

    public InputField inputTextEmail;
    public InputField inputTextPassword;
    public Text loginResult;

    //�˾�â
    public GameObject popup_board;
    //�˾� �޽���
    public Text popup_message;
    //���� ȭ��
    public GameObject black_screen;
    //���� ���� ��ư
    public GameObject gamestart_btn;

    //AudioClip �Ҹ�
    public AudioClip click;
    public AudioClip popup;
    AudioSource audioSrc;


    //private bool yes_or_no;

    public static FirebaseAuth auth;//���������� �ٸ� ��ũ��Ʈ���� �������� ���� ������ public static���� ����

    public static FirebaseUser user;
    //public int level;

    // Start is called before the first frame update
    void Awake()
    {
        // �ʱ�ȭ
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);

        //����� ������Ʈ ��������
        audioSrc = GetComponent<AudioSource>();
    }

    private void Update()
    {

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


    //ȸ������ ��ư�� ������ ������ �Լ�.
    public void JoinBtnOnClick()
    {
        email = inputTextEmail.text;
        password = inputTextPassword.text;
        level = 1;

        Debug.Log("email: " + email + ", password: " + password);
        popup_message.text = email + "�� \n ȸ������ ����~!\n�α��� �� ������ �̿����ּ���";
        CreateUser();
        //1�� �ڿ� �˾�â ����(CreateUser() �� �ð� ����... �߸� ����...)
        StartCoroutine(WaitForSeconds());

    }

    //ȸ������
    void CreateUser()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                popup_message.text = "�α��� ������ �߸��Ǿ��ų� \n �̹� ������ �̸����Դϴ�";
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                popup_message.text = "�α��� ������ �߸��Ǿ��ų� \n �̹� ������ �̸����Դϴ�";
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }

    //�α��� ��ư�� ������ ������ �Լ�.
    public void LoginBtnOnClick()
    {
        email = inputTextEmail.text;
        password = inputTextPassword.text;

        Debug.Log("email: " + email + ", password: " + password);
        popup_message.text = "�α��� ����~! \n��ſ� ���� �Ǽ����";//23����
        LoginUser();
        //1�� �ڿ� �˾�â ����(LoginUser() �� �ð� ����)
        StartCoroutine(WaitForSeconds());
        
    }

    //�α���
    void LoginUser()
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                popup_message.text = "��й�ȣ�� �߸��Ǿ��ų� \n���Ե��� ���� �̸����Դϴ�";
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                popup_message.text = "��й�ȣ�� �߸��Ǿ��ų� \n���Ե��� ���� �̸����Դϴ�";
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }

    IEnumerator WaitForSeconds()
    {
        audioSrc.PlayOneShot(popup, 0.5f);
        yield return new WaitForSeconds(1.0f);
        popup_board.SetActive(true);
        black_screen.SetActive(true);
        if(popup_message.text.Length < 24)
        {
            gamestart_btn.SetActive(true);
        }
    }

    public void ClosePopup()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        popup_board.SetActive(false);
        black_screen.SetActive(false);
    }
    
    public void GameStart()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        SceneManager.LoadScene("Start");
    }

}

