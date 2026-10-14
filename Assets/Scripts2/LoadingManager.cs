using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingManager : MonoBehaviour
{
    public TMP_Text percentText; //define text var to assign later

    //assign var for timer and total time
    private float timer = 0f;
    private float totalTime = 40f;

    void Update()
    {
        timer += Time.deltaTime;

        float percent = (timer / totalTime) * 100f; //calculate timer and transform into percentage

        percentText.text = Mathf.RoundToInt(percent) + "%"; //round up percentage from the float (i.e convert 10.4% to 10%) and format to also have percentage sign

        if (timer >= totalTime)
        {
            //if time more than or equal to assigned time valye (10s), load main menu scene
            SceneManager.LoadScene("MainMenu");
        }
    }
}