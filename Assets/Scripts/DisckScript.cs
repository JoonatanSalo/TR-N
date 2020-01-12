using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisckScript : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.TakeDamage(damage);
        }
    }

    void Update()
    {
        
    }
}
