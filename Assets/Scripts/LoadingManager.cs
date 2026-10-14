using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using System;
using System.Threading;

public class LoadingManager : MonoBehaviour
{
    public Canvas loadingCanvas;
    //public TMP_Text percentText; //define text var to assign later

    //assign var for timer and total time
    //private float timer = 0f;
    //private float totalTime = 10f;


    private static LoadingManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);

        loadingCanvas.enabled = false;
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName)); //call coroutine
    }

    //coroutine to load next scene
    IEnumerator LoadSceneAsync(string sceneName)
    {
        loadingCanvas.enabled = true;

        AsyncOperation operation =
            SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            yield return null;
        }

        loadingCanvas.enabled = false; //hide canva
    }

    void Update()
    //{
    //    timer += Time.deltaTime;

    //    float percent = (timer / totalTime) * 100f; //calculate timer and transform into percentage

    //    percentText.text = Mathf.RoundToInt(percent) + "%"; //round up percentage from the float (i.e convert 10.4% to 10%) and format to also have percentage sign

    //    if (timer >= totalTime)
    //    {
    //        //if time more than or equal to assigned time valye (10s), load main menu scene
    //        SceneManager.LoadScene("MainMenu");
    //    }
    }
}