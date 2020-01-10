using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 2;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }


    void Update()
    {
        
    }

    void TakeDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die() {
        Debug.Log("Died");
    }
}
