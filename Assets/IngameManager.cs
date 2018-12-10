using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameManager : MonoBehaviour
{
    public IngameUI inGameUIScripts;

    public int wert;

    private bool win;
    private bool lose;

    public bool paused;
    float timeLeft = 10.0f;

    public Material blur;


    // Use this for initialization
    void Start()
    {
        win = false;
        lose = false;
        Resume();
        inGameUIScripts.HideLevelCompletePanel();
        inGameUIScripts.HideGameOverPanel();

    }

    // Update is called once per frame
    void Update()
    {

        if (!inGameUIScripts.blurStand & paused)
        {

            Time.timeScale = 0;
        }

        timeLeft -= Time.deltaTime;

        inGameUIScripts.setTimeLeft(timeLeft);
        inGameUIScripts.showCountDown(timeLeft, win, lose);
        


       
        //if not win and not lose
        if (!win & !lose)
        {


            lose |= timeLeft < 0;
            if (lose)
            {
                Lose();

            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                Win();

            }
        }

    }

    void Win()
    {
        inGameUIScripts.ShowLevelCompletePanel(wert);
        win = true;
    }
    void Lose()
    {
        inGameUIScripts.ShowGameOverPanel();
        lose = true;
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        //
        timeLeft += 0.3f;
        paused = true;
        inGameUIScripts.TogglePause();
        Debug.Log("before: " + inGameUIScripts.blurStand + "##########################");
       
     

    }
    public void Resume()
    {
        inGameUIScripts.TogglePlay();
        paused = false;
        Time.timeScale = 1f;
    }


    /*
    GameData gameData;
    //GoalBlock goalBlock; //uncomment when here IS a goalBlock
    Scene thisScene;

    // Use this for initialization
    void Start () {

        thisScene = SceneManager.GetActiveScene();

    }

    // Update is called once per frame
    void Update () {

        //if (goalBlock.isGoalAchieved) //uncomment when here IS a goalBlock
        {
            List<LevelData> levels = gameData.levels; //why public field and not a getter?
            foreach (LevelData level in levels)
            {
                if (level.sceneID == thisScene.name)
                {
                    level.completed = true; //better rename it to isCompleted 
                }
            }
            SceneManager.LoadScene("LevelComplete"); //or otherwise 
        }

    }
    */
}