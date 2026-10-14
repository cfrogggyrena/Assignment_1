using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SettingsManager : MonoBehaviour
{
    //values to attach on unity for both scroll bars
    public Scrollbar soundFX;
    public Scrollbar bgMusic;
    public GameObject resetCompleted; //text for reset button 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //sets both values at start from playerprefs
        soundFX.value = PlayerPrefs.GetFloat("SFX", 1f); 
        bgMusic.value = PlayerPrefs.GetFloat("BGM", 1f);

        resetCompleted.SetActive(false); //hidden since loading
    }

    //method to save sfx in player prefs
    public void SaveSFX(float value)
    {
        PlayerPrefs.SetFloat("SFX", value);
    }

    //method to save bgm in player prefs
    public void SaveBGM(float value)
    {
        PlayerPrefs.SetFloat("BGM", value);
    }

    //reset stats of scrollbar (reset prefabs)
    public void ResetStats()
    {
        PlayerPrefs.DeleteKey("TotalScore");
        PlayerPrefs.DeleteKey("BestRun");
        PlayerPrefs.DeleteKey("GamesPlayed");

        resetCompleted.SetActive(true);
        StartCoroutine(ResetTextErase()); //call coroutine to go home
    }

    IEnumerator ResetTextErase()
    {
        yield return new WaitForSeconds(2); //wait for 5s (duh)
        resetCompleted.SetActive(false);

    }

    // go back to home scene
    public void Back()
    {
        SceneManager.LoadScene("HomeScene");
    }

    // Update is called once per frame
    void Update()
    {

    }
}