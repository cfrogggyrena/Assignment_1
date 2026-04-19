using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameSceneManager gameManager;


    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) //only player triggers ending scene or messages
            return;

        gameManager.CompleteLevel();
    }

}
