using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image GUIDisc;

    public int PlayerMaxHealth = 2;
    int PlayerCurrentHealth;

    public float maxDamageRate = 2f;
    float nextDamageTime = 0f;

    void Start()
    {
        PlayerCurrentHealth = PlayerMaxHealth;
        GUIDisc.GetComponent<guiDisc>().ChangeGUIDiscSprite();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {

        if (Time.time >= nextDamageTime)
        {
            PlayerCurrentHealth -= damage;
            GUIDisc.GetComponent<guiDisc>().ChangeGUIDiscSprite();

            if (PlayerCurrentHealth <= 0)
            {
                Die();
                nextDamageTime = Time.time + 1f / maxDamageRate;
            }
        }
    }
    void Die()
    {
        GUIDisc.GetComponent<guiDisc>().ChangeGUIDiscSprite();
        Destroy(gameObject);
    }
}
