using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisckThrow : MonoBehaviour
{
    public Transform throwPoint;
    public GameObject disckPrefab;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime) 
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Throw();

                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Throw() 
    {
        Instantiate(disckPrefab, throwPoint.position, throwPoint.rotation);
    }

    public void catchDisc()
    {
        nextAttackTime = Time.time;
    }
}
