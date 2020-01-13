using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscMelee : MonoBehaviour
{
    public Animator animator;

    public Transform meleePoint;
    public float attackRange = 0.5f;
    public LayerMask destrucktableLayers;
    public int meleeDamage = 1;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public bool hasDisc;

    void Start()
    {
        hasDisc = true;
    }

    void Update()
    {
        if(Time.time >= nextAttackTime && hasDisc)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Melee();

                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Melee() 
    {
        animator.SetTrigger("Melee");

        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(meleePoint.position, attackRange, destrucktableLayers);

        foreach (Collider2D enemy in hitObjects)
        {
            enemy.GetComponent<Enemy>().TakeDamage(meleeDamage);
        }

        hasDisc = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (meleePoint == null)
            return;

        Gizmos.DrawWireSphere(meleePoint.position, attackRange);
    }
}
