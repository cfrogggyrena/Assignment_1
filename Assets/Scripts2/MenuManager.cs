using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    //for audio
    public AudioClip clickSound;
    public AudioSource audioSource;



    public void onClick()
    {
        //for audio
        audioSource.PlayOneShot(clickSound);
        

        //uses scene manager to go to game with 0.5s delay to allow audio to play. It wasnt working before :(
        StartCoroutine(LoadSceneDelay());
        
    }

    private IEnumerator LoadSceneDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GameScene");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
