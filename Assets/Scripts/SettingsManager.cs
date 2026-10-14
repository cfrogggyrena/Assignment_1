using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    //values to attach on unity for both scroll bars
    public Scrollbar soundFX;
    public Scrollbar bgMusic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //sets both values at start from playerprefs
        soundFX.value = PlayerPrefs.GetFloat("SFX", 1); 
        bgMusic.value = PlayerPrefs.GetFloat("BGM", 1);
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


    // Update is called once per frame
    void Update()
    {

    }
}