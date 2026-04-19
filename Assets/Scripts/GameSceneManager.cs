using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



public class GameSceneManager : MonoBehaviour
{
    public TMP_Text tmScore;
    public TMP_Text tmHighScore;
    public TMP_Text tmTimeLeft;
    public TMP_Text tmName;

    private int MAX_TIME = 45;
    private int SCORE_INCREMENT = 10;
    private int currentTime;
    private int currentScore;
    private int highScore;

    //ADDED FOR AUDIO
    public AudioClip clickSound;
    public AudioClip scoreSound;
    public AudioClip gameOverSound;
    public AudioClip gameWinSound;
    //public AudioClip explosionSound;
    public AudioClip collisionSound;


    //ASSIGNMENT 2
    public AudioClip checkpointSound;
    private int TIME_INCREMENT = 20;


    public GameObject completeLevelUI;



    public void GoHome()
    {
        //added for AUDIO
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);

       
        SceneManager.LoadScene("HomeScene");
        //game over
        GameOver();  //YC: store currentScore if currentScore>highScore
    }

    //ASSIGNMENT 2
    public void RestartGame()
    {
        //added for AUDIO
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);


        SceneManager.LoadScene("GameScene");
        //game over
        GameOver();  //YC: store currentScore if currentScore>highScore
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Game Begins");

        currentTime = MAX_TIME;

        if (PlayerPrefs.HasKey("HighScore"))
            highScore = PlayerPrefs.GetInt("HighScore");
        else
            highScore = 0;

        if (PlayerPrefs.HasKey("UserName"))
            tmName.text = PlayerPrefs.GetString("UserName");

        tmHighScore.text = "High Score: " + highScore;

        StartCoroutine("LoseTime");


        //GAME COMPLETED
        completeLevelUI.SetActive(false); //makes it inactive from start

    }

    private void UpdateLabels()
    {
        tmScore.text = "Score: " + currentScore;
        tmTimeLeft.text = "Time Left: " + currentTime;
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            currentTime--;

            if (currentTime % 5 == 0)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(scoreSound);

                currentScore += SCORE_INCREMENT;
            }


            //added for AUDIO

            //explision sound every 3 seconds
            //if (currentTime % 3 == 0)
            //{
            //    //added for AUDIO
            //    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(explosionSound);

            //}

            //ASSIGNMENT 2
            if (PlayerPrefs.HasKey("CheckPointHit"))
            {
                if (PlayerPrefs.GetInt("CheckPointHit") == 1)
                {
                    GameObject.Find("CheckPointCanvas").GetComponent<PanelFader>().FadeOut();

                    currentTime += TIME_INCREMENT;

                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(checkpointSound);

                    PlayerPrefs.SetInt("CheckPointHit", 0);
                }
            }


            //ADD ON PHYSICS IN CLASS
            if (PlayerPrefs.HasKey("Collided"))
            {
                if (PlayerPrefs.GetInt("Collided") == 1)
                {
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(collisionSound);

                    currentScore -= SCORE_INCREMENT;

                    PlayerPrefs.SetInt("Collided", 0);
                }
            }

            if (currentTime <= 0)
                break;
        }

        //game over
        GameOver();
    }

    //UPDATED FOR ASSIGNMENT 2
    private void GameOver()
    {
        GameObject.Find("GameOverCanvas").GetComponent<PanelFader>().FadeIn();

        if (highScore < currentScore)
            PlayerPrefs.SetInt("HighScore", currentScore);

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(gameOverSound);

        Debug.Log("Game Over");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLabels();
    }


    //ASSIGNMENT 2 LEVEL FUNCTIONS


    //shows canvas with game won
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true); //enable true, disable false
        UnityEngine.Debug.Log("LEVEL WON!");

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(gameWinSound);
    }

}
