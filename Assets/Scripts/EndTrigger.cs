using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameSceneManager gameManager;

    void OnTriggerEnter()
    {
        gameManager.CompleteLevel();

    }
}
