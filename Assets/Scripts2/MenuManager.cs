using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void goToGame()
    {
    
        SceneManager.LoadScene("GameScene");

    }

    public void goToSettings()
    {

        SceneManager.LoadScene("SettingScene");

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
