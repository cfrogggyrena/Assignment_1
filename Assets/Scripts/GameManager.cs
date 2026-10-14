using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    //define text for the UI to attach
    public TMP_Text timerText; 
    public GameObject levelCompleteText;

    public float timeRemaining = 60f; //game time (60s)

    private bool gameFinished = false; //set initial state of game to not finished

    void Start()
    {
        levelCompleteText.SetActive(false); //message remain invisible
    }

    void Update()
    {
        //Keeps updating through the game. While calling gameFinished, check on the timer and keep
        //on substracting from the 60s. Once it reaches zero, timer turns red
        if (gameFinished) return; 

        timeRemaining -= Time.deltaTime;

        timerText.text = Mathf.CeilToInt(timeRemaining).ToString(); //converts from number to string for the ui display

        if (timeRemaining < 0)
        {
            timerText.color = Color.red;
        }
    }

    //function for when the level is completed
    public void CompleteLevel()
    {

        levelCompleteText.SetActive(true); //makes message visible

        if (gameFinished) return; //check/calls on gameFinished state

        gameFinished = true; //game is finished

        //defines the text to display based on the score and time. Calculates score based on
        //how fast or slow player completed the level.
        int score = Mathf.Max(0, Mathf.CeilToInt(timeRemaining));

        //format for the ui display based on time
        int total =
            PlayerPrefs.GetInt("TotalScore", 0) + score; //display total score

        PlayerPrefs.SetInt("TotalScore", total);

        int best =
            PlayerPrefs.GetInt("BestRun", 0); //display best run

        //if the current score is greater than previous ones, it automatically becomes the best score. Yipeee
        if (score > best)
        {
            PlayerPrefs.SetInt("BestRun", score); 
        }

        //gets amount of times played and puts it into playerprefs
        PlayerPrefs.SetInt(
            "GamesPlayed",
            PlayerPrefs.GetInt("GamesPlayed", 0) + 1); 

        PlayerPrefs.Save(); //save playerprefs

        StartCoroutine(ReturnHome()); //call coroutine to go home
    }

    IEnumerator ReturnHome()
    {
        yield return new WaitForSeconds(5); //wait for 5s (duh)
        SceneManager.LoadScene("HomeScene"); //loads homescene
    }
}
