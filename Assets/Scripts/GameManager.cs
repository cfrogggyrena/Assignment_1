using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;


    private void Start()
    {
        completeLevelUI.SetActive(false); //makes it inactive from start
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true); //enable true, disable false
        UnityEngine.Debug.Log("LEVEL WON!");
    }


    //dont have a game over yet...maybe in the future lol

    //public void EndGame()
    //{
    //    if(gameHasEnded == false)
    //    {
    //        gameHasEnded = true;
    //        UnityEngine.Debug.Log("GAME OVER");
    //        Invoke("Restart", restartDelay);
    //    }
    //}

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
