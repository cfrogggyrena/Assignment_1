using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TMP_Text totalScoreText;
    public TMP_Text bestRunText;
    public TMP_Text gamesPlayedText;

    public void goToGame()
    {

        FindAnyObjectByType<LoadingManager>().LoadScene("GameScene");

    }

    public void goToSettings()
    {

        FindAnyObjectByType<LoadingManager>().LoadScene("SettingScene");

    }





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalScoreText.text = "Total Score: " +
            PlayerPrefs.GetInt("TotalScore", 0);

        bestRunText.text = "Best Run: " +
            PlayerPrefs.GetInt("BestRun", 0);

        gamesPlayedText.text = "Games Played: " +
            PlayerPrefs.GetInt("GamesPlayed", 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
