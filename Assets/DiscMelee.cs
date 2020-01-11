using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscMelee : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            Melee();
        }
    }

    void Melee() 
    {
        animator.SetTrigger("Melee");
    }
}
