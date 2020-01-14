using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 2;
    int currentHealth;

    public float maxDamageRate = 2f;
    float nextDamageTime = 0f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) {

        if (Time.time >= nextDamageTime) 
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
                nextDamageTime = Time.time + 1f / maxDamageRate;
            }
        }
    }

    void Die() {
        Destroy(gameObject);
    }
}
