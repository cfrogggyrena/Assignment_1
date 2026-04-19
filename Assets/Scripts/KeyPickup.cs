using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public AudioClip keyPickupSound;
    public GameSceneManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerPrefs.SetInt("KeyCollected", 1);

        GameObject.FindGameObjectWithTag("MainCamera")
            .GetComponent<AudioSource>()
            .PlayOneShot(keyPickupSound);

        gameManager.SendMessage("ShowKeyMessage", "You got the key!");

        Destroy(gameObject);
    }
}
