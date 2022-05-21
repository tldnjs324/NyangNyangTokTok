using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Recipe : MonoBehaviour
{
    string ClickedRecipe;
    public string[] hotAmericano = { "물", "커피머신", "샷" };
    public string[] iceAmericano = { "얼음", "물", "커피머신", "샷" };
    public string[] hotLatte = { "우유", "커피머신", "샷" };
    public string[] iceLatte = { "얼음", "우유", "커피머신", "샷" };
    public string[] hotVanillaLatte = { "우유", "커피머신", "샷", "바닐라시럽" };
    public string[] iceVanillaLatte = { "얼음", "우유", "커피머신", "샷", "바닐라시럽" };
    public string[] hotCafeMocha = { "우유", "초코시럽", "커피머신", "샷", "휘핑", "초코시럽" };
    public string[] iceCafeMocha = { "얼음", "우유", "초코시럽", "커피머신", "샷", "휘핑", "초코시럽" };

    public List<string> _list = new List<string>();
    int i = 0;
    int wrongCnt = 0;
    int cnt = 0;
    public Text timeCounting;
    public int time = 20;

    public Image img;
    public GameObject cup;
    public Sprite[] sprites = new Sprite[7];
    public GameObject btnMachine;
    public Sprite sprite1; //커피 내리는중
    public Sprite sprite2; //원상태로

    public GameObject[] hintArrows = new GameObject[8];
    public GameObject popupCorrect;
    public GameObject popupWrong;
    public GameObject popupHelp;
    public GameObject popupBoss;
    public GameObject popupStart;

    public GameObject coffeeShot;
    public GameObject choco_img;

    private IEnumerator coroutine;
    public GameObject hint;

    public GameObject recipeSlider;
    public ParticleSystem particle; //컵용
    public ParticleSystem particleBasic; //항상
    public ParticleSystem particleHeart; //하트

    //효과음
    public AudioClip[] click;
    AudioSource audioSrc;
    //효과음 나오게 하기
    public void ClickSound(int x)
    {
        audioSrc.PlayOneShot(click[x]);
    }

    void Start()
    {
        ClickedRecipe = "";
        coroutine = HintActive();

        Invoke("StartPopup", 0.5f);

        audioSrc = GetComponent<AudioSource>();
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
        //popupRecipe.SetActive(false);
        popupStart.GetComponent<Animator>().SetTrigger("sclose");
    }
    void BtnReScale()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        clickObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1); //원래대로
    }
    void CupReScale()
    {
        RectTransform rectTran = cup.GetComponent<RectTransform>();
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 310);
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 310); //원래대로
    }
    void BtnImgChange()
    {
        btnMachine.GetComponent<Image>().sprite = sprite2; //샷 추출완료
        coffeeShot.SetActive(true); //샷 생성
    }
    void BtnShot()
    {
        coffeeShot.SetActive(false); 
    }

    public void RecipeClickedBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        ClickedRecipe = clickObject.GetComponentInChildren<Text>().text;
        _list.Add(ClickedRecipe);

        clickObject.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1); //클릭시 크기커지게
        Invoke("BtnReScale", 0.1f);

        if (SceneManager.GetActiveScene().name == "HotAmericano") //따뜻한아메리카노
        {
            cnt = 3;
            if (_list[i] == hotAmericano[i])
            {
                if (i != cnt - 1)
                {
                    
                }
                img.sprite = sprites[i]; //이미지 변경
                //0511효과음
                
                if(i == 0)//물
                {
                    audioSrc.PlayOneShot(click[6]);
                }
                if (i == 1)//커피머신
                {
                    audioSrc.PlayOneShot(click[7]);
                }
                if (i == 2)//샷
                {
                    audioSrc.PlayOneShot(click[10]);
                }
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.33f; //3개용
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                
                if (i != 2)
                {
                    if( i != 3)
                    {
                        particleBasic.Play();
                    }
                    RectTransform rectTran = cup.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 350); //컵 커지게
                    Invoke("CupReScale", 0.1f);
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //커피잔 머신위에
                    Invoke("BtnImgChange", 0.8f);
                }
                if (i == 3)
                {
                    Invoke("BtnShot", 0.3f);
                    Invoke("CorrectSound", 1f);//1초 뒤 정답 효과음
                    particle.Play(); //완성파티클
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                audioSrc.PlayOneShot(click[3]);//틀린 효과음
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
        if (SceneManager.GetActiveScene().name == "IceAmericano") //아이스아메리카노
        {
            cnt = 4;
            if (_list[i] == iceAmericano[i])
            {
                img.sprite = sprites[i]; //이미지 변경
                if (i == 0)//얼음
                {
                    audioSrc.PlayOneShot(click[5]);
                }
                if (i == 1)//물
                {
                    audioSrc.PlayOneShot(click[6]);
                }
                if (i == 2)//커피머신
                {
                    audioSrc.PlayOneShot(click[7]);
                }
                if (i == 3)//샷
                {
                    audioSrc.PlayOneShot(click[10]);
                }
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.25f; //4개용
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i != 3)
                {
                    if (i != 4)
                    {
                        particleBasic.Play();
                    }
                    RectTransform rectTran = cup.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 350); //컵 커지게
                    Invoke("CupReScale", 0.1f);
                }
                if (i == 3)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //커피잔 머신위에
                    Invoke("BtnImgChange", 0.8f);
                }
                if (i == 4)
                {
                    Invoke("BtnShot", 0.3f);
                    particle.Play(); //완성파티클
                    Invoke("CorrectSound", 1f);//1초 뒤 정답 효과음
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                audioSrc.PlayOneShot(click[3]);//오답 효과음
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
        if (SceneManager.GetActiveScene().name == "HotLatte") //따뜻한라떼
        {
            cnt = 3;
            if (_list[i] == hotLatte[i])
            {
                img.sprite = sprites[i]; //이미지 변경
                if (i == 0)//우유
                {
                    audioSrc.PlayOneShot(click[6]);
                }
                if (i == 1)//커피머신
                {
                    audioSrc.PlayOneShot(click[7]);
                }
                if (i == 2)//샷
                {
                    audioSrc.PlayOneShot(click[10]);
                }
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.33f; //3개용
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i != 2)
                {
                    if (i != 3)
                    {
                        particleBasic.Play();
                    }
                    RectTransform rectTran = cup.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 350); //컵 커지게
                    Invoke("CupReScale", 0.1f);
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //커피잔 머신위에
                    Invoke("BtnImgChange", 0.8f);
                }
                if (i == 3)
                {
                    Invoke("BtnShot", 0.3f);
                    Invoke("CorrectSound", 1f);//1초 뒤 정답 효과음
                    particle.Play(); //완성파티클
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                audioSrc.PlayOneShot(click[3]);//틀린 효과음
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
        if (SceneManager.GetActiveScene().name == "IceLatte") //아이스라떼
        {
            cnt = 4;
            if (_list[i] == iceLatte[i])
            {
                img.sprite = sprites[i]; //이미지 변경
                if (i == 0)//얼음
                {
                    audioSrc.PlayOneShot(click[5]);
                }
                if (i == 1)//우유
                {
                    audioSrc.PlayOneShot(click[6]);
                }
                if (i == 2)//커피머신
                {
                    audioSrc.PlayOneShot(click[7]);
                }
                if (i == 3)//샷
                {
                    audioSrc.PlayOneShot(click[10]);
                }
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.25f; //4개용
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i != 3)
                {
                    if (i != 4)
                    {
                        particleBasic.Play();
                    }
                    RectTransform rectTran = cup.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 350); //컵 커지게
                    Invoke("CupReScale", 0.1f);
                }
                if (i == 3)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //커피잔 머신위에
                    Invoke("BtnImgChange", 0.8f);
                }
                if (i == 4)
                {
                    Invoke("BtnShot", 0.3f);
                    particle.Play(); //완성파티클
                    Invoke("CorrectSound", 1f);//1초 뒤 정답 효과음
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                audioSrc.PlayOneShot(click[3]);//오답 효과음
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
        if (SceneManager.GetActiveScene().name == "HotVanillaLatte") //따뜻한바닐라라떼
        {
            cnt = 4;
            if (_list[i] == hotVanillaLatte[i])
            {
                img.sprite = sprites[i]; //이미지 변경
                if (i == 0)//우유
                {
                    audioSrc.PlayOneShot(click[6]);
                }
                if (i == 1)//커피머신
                {
                    audioSrc.PlayOneShot(click[7]);
                }
                if (i == 2)//샷
                {
                    audioSrc.PlayOneShot(click[10]);
                }
                if (i == 3)//바닐라 시럽
                {
                    audioSrc.PlayOneShot(click[8]);
                }
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.25f; //4개용
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i != 2)
                {
                    if (i != 4)
                    {
                        particleBasic.Play();
                    }
                    RectTransform rectTran = cup.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 350); //컵 커지게
                    Invoke("CupReScale", 0.1f);
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //커피잔 머신위에
                    Invoke("BtnImgChange", 0.8f);
                }
                if (i == 3)
                {
                    Invoke("BtnShot", 0.3f);
                }
                if( i == 4)
                {
                    particle.Play(); //완성파티클
                    Invoke("CorrectSound", 1f);//1초 뒤 정답 효과음
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                audioSrc.PlayOneShot(click[3]);//오답 효과음
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
        if (SceneManager.GetActiveScene().name == "IceVanillaLatte") //아이스바닐라라떼
        {
            cnt = 5;
            if (_list[i] == iceVanillaLatte[i])
            {
                img.sprite = sprites[i]; //이미지 변경
                if (i == 0)//얼음
                {
                    audioSrc.PlayOneShot(click[5]);
                }
                if (i == 1)//우유
                {
                    audioSrc.PlayOneShot(click[6]);
                }
                if (i == 2)//커피머신
                {
                    audioSrc.PlayOneShot(click[7]);
                }
                if (i == 3)//샷
                {
                    audioSrc.PlayOneShot(click[10]);
                }
                if (i == 4)//바닐라 시럽
                {
                    audioSrc.PlayOneShot(click[8]);
                }
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.2f; //5개용
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i != 3)
                {
                    if (i != 5)
                    {
                        particleBasic.Play();
                    }
                    RectTransform rectTran = cup.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 350); //컵 커지게
                    Invoke("CupReScale", 0.1f);
                }
                if (i == 3)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //커피잔 머신위에
                    Invoke("BtnImgChange", 0.8f);
                }
                if (i == 4)
                {
                    Invoke("BtnShot", 0.3f);
                }
                if (i == 5)
                {
                    particle.Play(); //완성파티클
                    Invoke("CorrectSound", 1f);//1초 뒤 정답 효과음
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                audioSrc.PlayOneShot(click[3]);//오답 효과음
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
        if (SceneManager.GetActiveScene().name == "IceCafeMocha") //아이스카페모카
        {
            cnt = 7;
            if (_list[i] == iceCafeMocha[i])
            {
                img.sprite = sprites[i]; //이미지 변경
                if (i == 0)//얼음
                {
                    audioSrc.PlayOneShot(click[5]);
                }
                if (i == 1)//우유
                {
                    audioSrc.PlayOneShot(click[6]);
                }
                if (i == 2)//초코시럽
                {
                    audioSrc.PlayOneShot(click[8]);
                }
                if (i == 3)//커피머신
                {
                    audioSrc.PlayOneShot(click[7]);
                }
                if (i == 4)//샷
                {
                    audioSrc.PlayOneShot(click[10]);
                }
                if (i == 5)//초코 시럽
                {
                    audioSrc.PlayOneShot(click[8]);
                }
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.1428f; //7개용
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i != 4 && i != 3)
                {
                    if (i != 7)
                    {
                        particleBasic.Play();
                    }
                    RectTransform rectTran = cup.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 350); //컵 커지게
                    Invoke("CupReScale", 0.1f);
                }
                if (i == 3)
                {
                    choco_img.SetActive(true); //초코시럽 생성
                }
                if (i == 4)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //커피잔 머신위에
                    Invoke("BtnImgChange", 0.8f);
                    choco_img.SetActive(false);
                }
                if (i == 5)
                {
                    Invoke("BtnShot", 0.3f);
                }
                if (i == 7)
                {
                    particle.Play(); //완성파티클
                    Invoke("CorrectSound", 1f);//1초 뒤 정답 효과음
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                audioSrc.PlayOneShot(click[3]);//오답 효과음
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
        if (SceneManager.GetActiveScene().name == "HotCafeMocha") //따뜻한카페모카
        {
            cnt = 6;
            if (_list[i] == hotCafeMocha[i])
            {
                img.sprite = sprites[i]; //이미지 변경
                if (i == 0)//우유
                {
                    audioSrc.PlayOneShot(click[6]);
                }
                if (i == 1)//초코시럽
                {
                    audioSrc.PlayOneShot(click[8]);
                }
                if (i == 2)//커피머신
                {
                    audioSrc.PlayOneShot(click[7]);
                }
                if (i == 3)//샷
                {
                    audioSrc.PlayOneShot(click[10]);
                }
                if (i == 4)//휘핑크림
                {
                    audioSrc.PlayOneShot(click[9]);
                }
                if (i == 5)//초코 시럽
                {
                    audioSrc.PlayOneShot(click[8]);
                }
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.166f; //6개용
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i != 2 && i != 3)
                {
                    if (i != 6)
                    {
                        particleBasic.Play();
                    }
                    RectTransform rectTran = cup.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 350); //컵 커지게
                    Invoke("CupReScale", 0.1f);
                }
                if (i == 2)
                {
                    choco_img.SetActive(true); //초코시럽 생성
                }
                if (i == 3)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //커피잔 머신위에
                    Invoke("BtnImgChange", 0.8f);
                    choco_img.SetActive(false);
                }
                if (i == 4)
                {
                    Invoke("BtnShot", 0.3f);
                }
                if (i == 6)
                {
                    particle.Play(); //완성파티클
                    Invoke("CorrectSound", 1f);//1초 뒤 정답 효과음
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                audioSrc.PlayOneShot(click[3]);//오답 효과음
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

    public void CorrectSound()
    {
        audioSrc.PlayOneShot(click[2]);//정답 효과음
    }


    public void Show_Recipe()
    {
        Invoke("PanelStart", 1f);
    }
    public void Help_Click()
    {
        Popup pop = popupHelp.GetComponent<Popup>();
        audioSrc.PlayOneShot(click[0]);
        pop.PopUp();
        hintArrows[0].SetActive(false);
    }
    public void Correct()
    {
        Popup pop = popupCorrect.GetComponent<Popup>();
        pop.PopUp();
    }
}
