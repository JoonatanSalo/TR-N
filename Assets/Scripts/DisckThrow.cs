using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisckThrow : MonoBehaviour
{
    public GameObject disckPrefab;
    public Animator animator;
    public Transform meleePoint;
    public LayerMask destrucktableLayers;
    public Transform throwPoint;

    public float ThrowRate = 2f;
    float nextThrowTime = 0f;


    public bool hasDisc;
    public float attackRange = 0.5f;
    public int meleeDamage = 1;
    public float MeleeAttackRate = 2f;
    float nextAttackTime = 0f;

    void Start()
    {
        hasDisc = true;
    }

    void Update()
    {
        if (Time.time >= nextThrowTime) 
        {
            hasDisc = true;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Throw();

                nextThrowTime = Time.time + 1f / ThrowRate;
            }
        }

        if (Time.time >= nextAttackTime && hasDisc)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Melee();

                nextAttackTime = Time.time + 1f / MeleeAttackRate;
            }
        }
    }

    void Throw() 
    {
        Instantiate(disckPrefab, throwPoint.position, throwPoint.rotation);
        hasDisc = false;
    }

    void Melee()
    {
        animator.SetTrigger("Melee");

        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(meleePoint.position, attackRange, destrucktableLayers);

        foreach (Collider2D enemy in hitObjects)
        {
            enemy.GetComponent<Enemy>().TakeDamage(meleeDamage);
        }
    }

    public void catchDisc()
    {
        nextThrowTime = Time.time;
        hasDisc = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (meleePoint == null)
            return;

        Gizmos.DrawWireSphere(meleePoint.position, attackRange);
    }
}
