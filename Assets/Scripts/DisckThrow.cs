using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisckThrow : MonoBehaviour
{
    public Transform throwPoint;
    public GameObject disckPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Throw();
        }
    }

    void Throw() 
    {
        Instantiate(disckPrefab, throwPoint.position, throwPoint.rotation);
    }
}
