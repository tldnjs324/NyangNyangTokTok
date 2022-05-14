using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Recipe2 : MonoBehaviour
{
    string ClickedRecipe;
    public string[] basicToast = { "식빵", "토스트기" };
    public string[] chocoToast = { "식빵", "토스트기", "초코시럽"};
    public string[] strawberryToast = { "식빵", "토스트기", "딸기잼", "딸기" };
    public string[] blueberryToast = { "식빵", "토스트기", "블루베리잼", "블루베리" };
    public string[] strawberryChocoToast = { "식빵", "토스트기", "초코시럽", "딸기" };
    public string[] nyangnyangToast = { "식빵", "토스트기", "초코시럽", "블루베리", "딸기" };

    public List<string> _list = new List<string>();
    int i = 0;
    int wrongCnt = 0;
    int cnt = 0;
    public Text timeCounting;
    public int time = 20;

    public Image img;
    public GameObject plate;
    public Sprite[] sprites = new Sprite[4];
    public GameObject btnMachine;
    public Sprite sprite; //다 구워짐
    public Sprite sprite1; //구워지는 중간상태
    public Sprite sprite2; //원상태로

    public GameObject[] hintArrows = new GameObject[6];
    public GameObject popupCorrect;
    public GameObject popupWrong;
    public GameObject popupHelp;
    public GameObject popupBoss;
    public GameObject popupStart;

    public GameObject recipeSlider;

    private IEnumerator coroutine;
    public GameObject hint;

    public ParticleSystem particle; //접시에 완성용
    public ParticleSystem particleBasic; //항상
    public ParticleSystem particleHeart; //하트

    int updateCnt = 1;

    void Start()
    {
        ClickedRecipe = "";
        coroutine = HintActive();

        Invoke("StartPopup", 0.1f);
    }
    void StartPopup()
    {
        Popup pop = popupStart.GetComponent<Popup>();
        pop.PopUp2();
    }

    private void Update()
    {
        if (i != 0 && i == cnt)
        {
            
            Invoke("Correct", 1.0f);
            recipeSlider.GetComponent<Image>().fillAmount = 1f;
        }

        //서윤
        
        if (nameBtnDown)
        {
            while (updateCnt > 0)
            {
                Invoke("ShowRecipe", 1f);
                updateCnt--;
            }  
        }


    }
    //서윤

    bool nameBtnDown;

    public void reciPressed()
    {
        nameBtnDown = true;
    }


    IEnumerator HintActive()
    {
        while (true)
        {
            hint.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.7f);

            hint.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.7f);
        }

    }

    void PanelStart()
    {
        InvokeRepeating("TimeCount", 0f, 1f);
        Invoke("TimeEnd", 20f);
    }
    void TimeCount()
    {
        --time;
        timeCounting.text = time.ToString();
    }
    void TimeEnd()
    {
        CancelInvoke("TimeCount");
        popupStart.GetComponent<Animator>().SetTrigger("sclose");
    }

    void BtnReScale()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        clickObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1); //원래대로
    }
    void PlateReScale()
    {
        RectTransform rectTran = plate.GetComponent<RectTransform>();
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1250);
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1250); //그릇 원래대로
    }
    void BtnImgChange()
    {
        btnMachine.GetComponent<Image>().sprite = sprite; //다구워짐
    }

    public void RecipeClickedBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        ClickedRecipe = clickObject.GetComponentInChildren<Text>().text;
        _list.Add(ClickedRecipe);
        //
        clickObject.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1); //클릭시 크기커지게
        Invoke("BtnReScale", 0.1f);


        if (SceneManager.GetActiveScene().name == "BasicToast") //기본토스트
        {
            cnt = 2;
            if (_list[i] == basicToast[i])
            {
                if (i > 0)
                {
                    if(i != cnt-1)
                    {
                        particleBasic.Play();
                    }
                    img.sprite = sprites[i - 1]; //이미지 변경
                    RectTransform rectTran = plate.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1350); //그릇 커지게
                    Invoke("PlateReScale", 0.1f);
                } 
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.5f; //2개용
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //구워지는 중
                    Invoke("BtnImgChange", 1.2f);
                    //식빵이 기계에 들어감(버튼 사진 변경)
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite2;
                    particle.Play(); //그릇에 완성파티클
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                if (wrongCnt == 1)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    hintArrows[0].SetActive(true); //도움말힌트강조
                    StartCoroutine(coroutine);
                }
                else if (wrongCnt == 3)
                {
                    Popup pop = popupBoss.GetComponent<Popup>();
                    pop.PopUp();
                    hintArrows[i + 1].SetActive(true); //재료를 알려줌
                }
            }
        }

        if (SceneManager.GetActiveScene().name == "ChocoToast") //초코토스트
        {
            cnt = 3;
            if (_list[i] == chocoToast[i])
            {
                if (i > 0)
                {
                    if (i != cnt - 1)
                    {
                        particleBasic.Play();
                    }
                    img.sprite = sprites[i - 1]; //이미지 변경
                    RectTransform rectTran = plate.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1350); //그릇 커지게
                    Invoke("PlateReScale", 0.1f);
                }
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.33f; //3개용
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //구워지는 중
                    Invoke("BtnImgChange", 1.5f);
                    //식빵이 기계에 들어감(버튼 사진 변경)
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite2;
                }
                if (i == 3)
                {
                    particle.Play(); //그릇에 완성파티클
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                if (wrongCnt == 1)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    hintArrows[0].SetActive(true); //도움말힌트강조
                    StartCoroutine(coroutine);
                }
                else if (wrongCnt == 3)
                {
                    Popup pop = popupBoss.GetComponent<Popup>();
                    pop.PopUp();
                    hintArrows[i + 1].SetActive(true); //재료를 알려줌
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "StrawberryToast") //딸기토스트
        {
            cnt = 4;
            if (_list[i] == strawberryToast[i])
            {
                if (i > 0)
                {
                    if (i != cnt - 1)
                    {
                        particleBasic.Play();
                    }
                    img.sprite = sprites[i - 1]; //이미지 변경
                    RectTransform rectTran = plate.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1350); //그릇 커지게
                    Invoke("PlateReScale", 0.1f);
                }
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.25f; //4개용
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //구워지는 중
                    Invoke("BtnImgChange", 1.5f);
                    //식빵이 기계에 들어감(버튼 사진 변경)
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite2;
                }
                if (i == 4)
                {
                    particle.Play(); //그릇에 완성파티클
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                if (wrongCnt == 1)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    hintArrows[0].SetActive(true); //도움말힌트강조
                    StartCoroutine(coroutine);
                }
                else if (wrongCnt == 3)
                {
                    Popup pop = popupBoss.GetComponent<Popup>();
                    pop.PopUp();
                    hintArrows[i + 1].SetActive(true); //재료를 알려줌
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "BlueberryToast") //블루베리토스트
        {
            cnt = 4;
            if (_list[i] == blueberryToast[i])
            {
                if (i > 0)
                {
                    if (i != cnt - 1)
                    {
                        particleBasic.Play();
                    }
                    img.sprite = sprites[i - 1]; //이미지 변경
                    RectTransform rectTran = plate.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1350); //그릇 커지게
                    Invoke("PlateReScale", 0.1f);
                }
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.25f; //4개용
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //구워지는 중
                    Invoke("BtnImgChange", 1.5f);
                    //식빵이 기계에 들어감(버튼 사진 변경)
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite2;
                }
                if (i == 4)
                {
                    particle.Play(); //그릇에 완성파티클
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                if (wrongCnt == 1)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    hintArrows[0].SetActive(true); //도움말힌트강조
                    StartCoroutine(coroutine);
                }
                else if (wrongCnt == 3)
                {
                    Popup pop = popupBoss.GetComponent<Popup>();
                    pop.PopUp();
                    hintArrows[i + 1].SetActive(true); //재료를 알려줌
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "StrawberryChocoToast") //딸기초코토스트
        {
            cnt = 4;
            if (_list[i] == strawberryChocoToast[i])
            {
                if (i > 0)
                {
                    if (i != cnt - 1)
                    {
                        particleBasic.Play();
                    }
                    img.sprite = sprites[i - 1]; //이미지 변경
                    RectTransform rectTran = plate.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1350); //그릇 커지게
                    Invoke("PlateReScale", 0.1f);
                }
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.25f; //4개용
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //구워지는 중
                    Invoke("BtnImgChange", 1.5f);
                    //식빵이 기계에 들어감(버튼 사진 변경)
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite2;
                }
                if (i == 4)
                {
                    particle.Play(); //그릇에 완성파티클
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                if (wrongCnt == 1)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    hintArrows[0].SetActive(true); //도움말힌트강조
                    StartCoroutine(coroutine);
                }
                else if (wrongCnt == 3)
                {
                    Popup pop = popupBoss.GetComponent<Popup>();
                    pop.PopUp();
                    hintArrows[i + 1].SetActive(true); //재료를 알려줌
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "NyangNyangToast") //냥냥토스트
        {
            cnt = 5;
            if (_list[i] == nyangnyangToast[i])
            {
                if (i > 0)
                {
                    if (i != cnt - 1)
                    {
                        particleBasic.Play();
                    }
                    img.sprite = sprites[i - 1]; //이미지 변경
                    RectTransform rectTran = plate.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1350); //그릇 커지게
                    Invoke("PlateReScale", 0.1f);
                }
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.2f; //5개용
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //구워지는 중
                    Invoke("BtnImgChange", 1.5f);
                    //식빵이 기계에 들어감(버튼 사진 변경)
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite2;
                }
                if (i == 5)
                {
                    particle.Play(); //그릇에 완성파티클
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                if (wrongCnt == 1)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    hintArrows[0].SetActive(true); //도움말힌트강조
                    StartCoroutine(coroutine);
                }
                else if (wrongCnt == 3)
                {
                    Popup pop = popupBoss.GetComponent<Popup>();
                    pop.PopUp();
                    hintArrows[i + 1].SetActive(true); //재료를 알려줌
                }
            }
        }
        //하트 올리는 코드
        GameManager.IncreaseHeart(wrongCnt);
    }
    IEnumerator AfterParticle()
    {
        yield return new WaitForSeconds(0.2f);
        img.sprite = sprites[i - 1]; //이미지 변경
    }

    public void Show_Recipe()
    {
        Invoke("PanelStart", 1f);
    }
    public void Help_Click()
    {
        Popup pop = popupHelp.GetComponent<Popup>();
        pop.PopUp();
        hintArrows[0].SetActive(false);
    }
    public void Correct()
    {
        Popup pop = popupCorrect.GetComponent<Popup>();
        pop.PopUp();
    }
}
