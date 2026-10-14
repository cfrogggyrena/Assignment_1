using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using System;
using System.Threading;

public class LoadingManager : MonoBehaviour
{
    public Canvas loadingCanvas;
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

        loadingCanvas.enabled = false; //invisble
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName)); //call coroutine
    }

    //coroutine to load next scene
    IEnumerator LoadSceneAsync(string sceneName)
    {
        loadingCanvas.enabled = true;

        yield return null; // let Unity render the loading UI, or else it will pop-up and leave immediately lol

        AsyncOperation operation =
            SceneManager.LoadSceneAsync(sceneName);

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