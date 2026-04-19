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

    private int MAX_TIME = 50;
    private int SCORE_INCREMENT = 10;
    private int currentTime;
    private int currentScore;
    private int highScore;

    //ADDED FOR AUDIO
    public AudioClip clickSound;
    public AudioClip scoreSound;
    public AudioClip gameOverSound;
    public AudioClip gameWinSound;

    public AudioClip playerCelebration;
    //public AudioClip explosionSound;
    public AudioClip collisionSound;


    //ASSIGNMENT 2
    public AudioClip checkpointSound;
    private int TIME_INCREMENT = 20;


    public GameObject completeLevelUI;


    //AUDIO SOURCE BG
    private AudioSource bgAudioSource;

    //SCORE REWARD FOR OBSTACLE
    private int OBSTACLE_SCORE_REWARD = 15;
    private int OBSTACLE_TIME_REWARD = 15;





    [Header("KEY SYSTEM")]
    public TMP_Text tmKeyMessage;      // "You need the key" message s
    public float keyMessageDuration = 2.5f;
    private bool keyMessageShowing = false;

    [Header("NEXT LEVEL")]
    public string levelTwoSceneName = "GameSceneTwo";


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

        //DISPLAY HIGH SCORE
        tmHighScore.text = "High Score: " + highScore;


        //TEST
        //string highScoreOwner = PlayerPrefs.GetString("HighScoreName", "empty");

        //tmHighScore.text = "High Score: " + highScore + "-" + highScoreOwner;

        StartCoroutine("LoseTime");


        //GAME COMPLETED
        completeLevelUI.SetActive(false); //makes it inactive from start


        //AUDIO DOESNT OVERLAP
        bgAudioSource = GameObject
            .FindGameObjectWithTag("MainCamera")
            .GetComponent<AudioSource>();


        if (!bgAudioSource.isPlaying) //make sure music is playing when level starts
        {
            bgAudioSource.Play();
        }



        // RESET KEY FOR NEW LEVEL
        PlayerPrefs.SetInt("KeyCollected", 0);


    }


    public void GoHome()
    {
        //added for AUDIO
        GameObject.FindGameObjectWithTag("MainCamera")
            .GetComponent<AudioSource>()
            .PlayOneShot(clickSound);
       
        SceneManager.LoadScene("HomeScene");
        //game over
        GameOver();  //YC: store currentScore if currentScore>highScore
    }

    //ASSIGNMENT 2
    public void RestartGame()
    {

        // STOP BACKGROUND MUSIC
        bgAudioSource.Stop();

        //added for AUDIO
        bgAudioSource.PlayOneShot(clickSound);


        SceneManager.LoadScene("GameScene");
        //game over
        GameOver();  //YC: store currentScore if currentScore>highScore
    }


    //LOADS NEXT LEVEL.
    //in order to make it work it takes the index number and adds 1. In order to do this the profile builds for scenes need to be in order
    //or else it will take the user to a wrong scene
    public void NextLevel()
    {
        bgAudioSource.Stop();

        bgAudioSource.PlayOneShot(clickSound);


        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        //check if the next scene index exists in the build settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            UnityEngine.Debug.Log("No more scene in build settings!");
        }
    }

   

    private void UpdateLabels()
    {
        tmScore.text = "Score: " + currentScore;
        tmTimeLeft.text = "Time Left: " + currentTime;
    }


    //LOSE TIME 
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            currentTime--;

            if (currentTime % 5 == 0)
            {
                GameObject.FindGameObjectWithTag("MainCamera")
                    .GetComponent<AudioSource>()
                    .PlayOneShot(scoreSound);

                currentScore += SCORE_INCREMENT;

            }




            //ASSIGNMENT 2
            if (PlayerPrefs.HasKey("CheckPointHit"))
            {
                if (PlayerPrefs.GetInt("CheckPointHit") == 1)
                {
                    GameObject.Find("CheckpointObject").GetComponent<PanelFader>().FadeOut();

                    currentTime += TIME_INCREMENT;

                    GameObject.FindGameObjectWithTag("MainCamera")
                        .GetComponent<AudioSource>()
                        .PlayOneShot(checkpointSound);

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

            // OBSTACLE HIT TIME REWARD
            if (PlayerPrefs.HasKey("TimeBonus"))
            {
                currentTime += PlayerPrefs.GetInt("TimeBonus");
                PlayerPrefs.DeleteKey("TimeBonus");
            }



            // OBSTACLE DESTROY SCORE REWARD
            if (PlayerPrefs.HasKey("ObstacleDestroyed"))
            {
                currentScore += OBSTACLE_SCORE_REWARD;
                PlayerPrefs.DeleteKey("ObstacleDestroyed");
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
        GameObject.Find("GameOverObject").GetComponent<PanelFader>().FadeIn();


        //UNCOMMENT IF ONLY WANNA SHOW SCORE AND NO NAME
        if (highScore < currentScore)
            PlayerPrefs.SetInt("HighScore", currentScore);


        // Save the player name that achieved it
        //string playerName = PlayerPrefs.GetString("UserName");
        //PlayerPrefs.SetString("HighScoreName", playerName);

        //PlayerPrefs.Save();



        // STOP BACKGROUND MUSIC
        bgAudioSource.Stop();

        bgAudioSource.PlayOneShot(gameOverSound);

        Debug.Log("Game Over");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLabels();
    }


    //ASSIGNMENT 2 LEVEL FUNCTIONS

    //UPDATED: uses key for next level
    public void CompleteLevel()
    {
        bool hasKey = PlayerPrefs.GetInt("KeyCollected", 0) == 1;

        if (hasKey)
        {
            completeLevelUI.SetActive(true);
            Debug.Log("LEVEL WON!");


            // STOP BACKGROUND MUSIC
            bgAudioSource.Stop();

            //PLAY WIN SOUND
            bgAudioSource.PlayOneShot(gameWinSound);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(playerCelebration);

        }

        else
        {
            ShowKeyMessage("You need the key!");
        }
    }


    //KEY MESSAGE COROUTINE
    private void ShowKeyMessage(string message)
    {
        if (keyMessageShowing)
            return;

        StartCoroutine(KeyMessageRoutine(message));
    }

    private IEnumerator KeyMessageRoutine(string message)
    {
        keyMessageShowing = true;
        tmKeyMessage.text = message;
        tmKeyMessage.gameObject.SetActive(true);

        yield return new WaitForSeconds(keyMessageDuration);

        tmKeyMessage.gameObject.SetActive(false);
        keyMessageShowing = false;
    }

}
