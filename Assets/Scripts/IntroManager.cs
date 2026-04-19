using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public AudioClip clickSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void GoToGame()
    {
        //for audio
        AudioManager.Instance.PlayOneShot(clickSound, false);

        SceneManager.LoadScene("GameScene");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
