using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    // UI vars
    public TMP_Text timerText;
    public GameObject levelCompleteText;

    // timer var
    public float timeRemaining = 60f;

    //game states
    private bool gameFinished = false;
    private bool timerRunning = false;

    void Start()
    {
        levelCompleteText.SetActive(false);

        // display before gameplay starts
        timerText.text = "READY";
    }

    void Update()
    {
        //stop processing if game is finished
        if (gameFinished)
            return;

        // FOR MIDTERM:
        //doesnt start counting until animation for cameras is done lol (i almost forgot about this)
        if (!timerRunning)
            return;

        //countdown
        timeRemaining -= Time.deltaTime;

        timerText.text =
            Mathf.CeilToInt(timeRemaining).ToString();

        //turn red when timer reaches 0
        if (timeRemaining < 0)
        {
            timerText.color = Color.red;
        }
    }

    //called from CameraController after intro sequence
    public void StartTimer()
    {
        timerRunning = true;

        //show current time immediately
        timerText.text =
            Mathf.CeilToInt(timeRemaining).ToString();
    }

    //funtion for when level is completed
    public void CompleteLevel()
    {
        levelCompleteText.SetActive(true);

        if (gameFinished)
            return;

        gameFinished = true;

        //calculate score
        int score =
            Mathf.Max(0, Mathf.CeilToInt(timeRemaining));

        //total Score
        int total =
            PlayerPrefs.GetInt("TotalScore", 0) + score;

        PlayerPrefs.SetInt("TotalScore", total);

        //best Run
        int best =
            PlayerPrefs.GetInt("BestRun", 0);

        if (score > best)
        {
            PlayerPrefs.SetInt("BestRun", score);
        }

        //games played in total
        PlayerPrefs.SetInt(
            "GamesPlayed",
            PlayerPrefs.GetInt("GamesPlayed", 0) + 1
        );

        PlayerPrefs.Save(); //saves everything on player prefs
         
        StartCoroutine(ReturnHome());
    }

    //function to go back home (After game is done)
    IEnumerator ReturnHome()
    {
        yield return new WaitForSeconds(5);

        FindAnyObjectByType<LoadingManager>().LoadScene("HomeScene");
    }
    
}