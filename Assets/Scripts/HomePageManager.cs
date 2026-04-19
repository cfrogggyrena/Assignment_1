using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HomePageManager : MonoBehaviour
{

    public TMP_InputField inputName;
    public GameObject AboutPanel;

    //for audio
    public AudioClip clickSound;

    public void GoToGame()
    {
        //for audio
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        PlayerPrefs.SetString("UserName", inputName.text); //Bring username from homescene to game start (without going into settings)
        SceneManager.LoadScene("GameScene");
    }

    public void GoToInto()
    {
        //for audio
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        PlayerPrefs.SetString("UserName", inputName.text);
        SceneManager.LoadScene("IntroScene");
    }

    public void GoToSetting()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        SceneManager.LoadScene("SettingScene");
    }

    public void EnableAboutPanel()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        AboutPanel.gameObject.SetActive(true);
    }

    public void DisableAboutPanel()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        AboutPanel.gameObject.SetActive(false);
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
