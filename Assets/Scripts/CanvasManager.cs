using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class CanvasManager : MonoBehaviour
{

    public GameManager gameManager;


    public void restartGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UnityEngine.Debug.Log("RESTART GAME!");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }


    //START AND FINISH GAME FOR HOME SCENE:
    public void startGameButton()
    {
        //loads scene with index 1 when function is used
        //can also use with string but im lazy
        SceneManager.LoadScene(1);
    }

    public void exitGameButton()
    {
//tried to do application.quit but it wasn't working on engine so I found this solution online :(
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }



  //
    void Start()
    {


    }


    void Update()
    {
        
    }
}