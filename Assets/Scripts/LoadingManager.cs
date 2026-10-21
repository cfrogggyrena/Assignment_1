using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using System;
using System.Threading;

public class LoadingManager : MonoBehaviour
{
    //var for canvas loading
    public Canvas loadingCanvas;

    //private var for the instance
    private static LoadingManager instance;

    //startup flag
    private bool startupComplete = false;


    private void Start()
    {
        //only run once when HomeScene is loaded
        if (!startupComplete)
        {
            startupComplete = true;

            loadingCanvas.enabled = true;

            StartCoroutine(HideStartupLoading());
        }
    }


    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);

        loadingCanvas.enabled = false; //invisble
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName)); //call coroutine
    }

    //coroutine to show loading panel for 10s
    private IEnumerator HideStartupLoading()
    {
        yield return null; // Let Unity render one frame

        yield return new WaitForSeconds(10f);

        loadingCanvas.enabled = false;
    }

    //coroutine to load next scene
    IEnumerator LoadSceneAsync(string sceneName)
    {
        loadingCanvas.enabled = true;

        yield return new WaitForSeconds(1f); // let Unity render the loading UI, or else it will pop-up and leave immediately lol

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            yield return null;
        }

        loadingCanvas.enabled = false;
    }

    void Update()
    {

    }
}