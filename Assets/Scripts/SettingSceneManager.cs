using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class SettingSceneManager : MonoBehaviour
{
    public TMP_InputField inputName;
    public TMP_Text tmConfirm;

    //audio
    public AudioClip clickSound;
    public void GoHome()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        PlayerPrefs.SetString("UserName", inputName.text);
        SceneManager.LoadScene("HomeScene");
    }

    public void ResetHighScore() 
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        PlayerPrefs.SetInt("HighScore", 0);

        tmConfirm.text = "Reset was sucessful";
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.HasKey("UserName"))
            inputName.text = PlayerPrefs.GetString("UserName");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
