using UnityEngine;

public class GoalTrigger : MonoBehaviour
{

    public GameManager gameManager; //attach game manager on unity

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.CompleteLevel(); //calls the completelevel method from game manager
        }
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

