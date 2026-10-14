using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel; //define panel obj
    public TMP_Text tutorialText; //define text 

    private int currentStep = 0; //define steps (will be 3 max)

    //define for sound 
    //public AudioClip clickSound;

    private string[] instructions =
    {
        "Welcome! You can use WASD to move and c to change cameras",
        "You can T-bag your enemies with left shift!",
        "Press K for punching and L for kicking"
    };

    void Start()
    {

        if (PlayerPrefs.GetInt("TutorialDone", 0) == 1) 
        {
            tutorialPanel.SetActive(false); //if tutorial is done the panel dissappears 
        }
        else
        {
            tutorialText.text = instructions[0]; 
        }
    }

    //function for the next instruction text
    public void NextInstruction()
    {


        currentStep++; //step text increases (goes to the next) 

        if (currentStep < instructions.Length)
        {
            tutorialText.text = instructions[currentStep]; //as long as the instruction text lenght is still not done, will display current step 
        }

        else 
        {
            //else it will take the tutorial as done and pass and panel disappears
            tutorialPanel.SetActive(false);

            PlayerPrefs.SetInt("TutorialDone", 1);
            PlayerPrefs.Save();
        }
    }

}