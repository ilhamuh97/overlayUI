using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour {
    public GameObject levelCompleteMenu;
    Image myImageComponent;
    public GameObject gameOverMenu;
    public Sprite star1;
    public Sprite star2;
    public Sprite star3;
    public GameObject pauseButton;
    public GameObject playButton;
    public GameObject pauseMenuButton;
    public GameObject pausePlayButton;
    private string[] star3Texts = new string[] { "You did it!", "You rock it!", "Awesome!" };
    private string[] star2Texts = new string[] { "Not bad!", "Good!", "Good job!" };
    private string[] star1Texts = new string[] { "Could be better!", "Don't give up!", "Lucky!" };
    Text levelCompleteText;
    public Material blurMaterial;
    public float timeBlur = 0f;
    float timeLeft;
    public bool blurStand = false;


    public Text text;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (blurStand)
        {

            timeBlur += Time.deltaTime;
            float ratio = 3 / 2f;
            Color newColor = new Color(1 - timeBlur*ratio, 1 - timeBlur*ratio, 1 - timeBlur*ratio, 1);


            pauseMenuButton.GetComponent<Image>().material.SetColor("_Color", newColor);
            pauseMenuButton.GetComponent<Image>().material.SetFloat("_Size", timeBlur*10f);

            levelCompleteMenu.GetComponent<Image>().material.SetColor("_Color", newColor);
            levelCompleteMenu.GetComponent<Image>().material.SetFloat("_Size", timeBlur * 10f);

            gameOverMenu.GetComponent<Image>().material.SetColor("_Color", newColor);
            gameOverMenu.GetComponent<Image>().material.SetFloat("_Size", timeBlur * 10f);
            Debug.Log(timeBlur);
            if(timeBlur > 0.3f)
            {

                blurStand = false;

                timeBlur = 0;
            }
        }
    }

    public void setTimeLeft(float timeLeft)
    {
        this.timeLeft = timeLeft;
    }

    public void showCountDown(float timeLeft, bool win, bool lose)
    {
        text.text = "Time Left: " + Mathf.Round(timeLeft) + "s";
        if (win || lose )
        {
            text.text = "";
        }
    }

    public void ShowLevelCompletePanel(int wert)
    {
       
        Debug.Log("You Win!");
        levelCompleteText = levelCompleteMenu.transform.Find("LevelCompleteText").gameObject.GetComponent<Text>();
        myImageComponent = levelCompleteMenu.transform.Find("StarReceivementImage").gameObject.GetComponent<Image>();
        switch (wert)
        {
            case 1:
                levelCompleteText.text = star1Texts[Random.Range(0, 3)];
                myImageComponent.sprite = star1;
                break;
            case 2:
                levelCompleteText.text = star2Texts[Random.Range(0, 3)];
                myImageComponent.sprite = star2;
                break;
            case 3:
                levelCompleteText.text = star3Texts[Random.Range(0, 3)];
                myImageComponent.sprite = star3;
                break;
        }

        levelCompleteMenu.SetActive(true);
        pausePlayButton.SetActive(false);
        pauseMenuButton.SetActive(false);
        blurStand = true;

    }



    public void TogglePause()
    {
        pauseButton.SetActive(false);
        //PlayButton.SetActive(true);
        pauseMenuButton.SetActive(true);
        blurStand = true;

       
    }
    public void TogglePlay()
    {
        pauseButton.SetActive(true);
        //PlayButton.SetActive(false);
        pauseMenuButton.SetActive(false);

    }
    public void ShowGameOverPanel()
    {
        Debug.Log("You lose!");
        gameOverMenu.SetActive(true);
        pausePlayButton.SetActive(false);
        blurStand = true;
    }
    public void HideLevelCompletePanel()
    {
        levelCompleteMenu.SetActive(false);
        pausePlayButton.SetActive(true);

    }
    public void HideGameOverPanel()
    {
        gameOverMenu.SetActive(false);
        pausePlayButton.SetActive(true);
    }
}
