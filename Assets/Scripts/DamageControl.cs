using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour
{
    public int currentHealth = 3;

    private bool destroyed = false;

    public void Damage(int damageAmount)
    {
        if (destroyed) return;

        currentHealth -= damageAmount;

        // +15 seconds PER HIT
        PlayerPrefs.SetInt("TimeBonus", 15);

        if (currentHealth <= 0)
        {
            destroyed = true;

            // +15 score ON DESTROY
            PlayerPrefs.SetInt("ObstacleDestroyed", 1);

            gameObject.SetActive(false);
        }
    }
}