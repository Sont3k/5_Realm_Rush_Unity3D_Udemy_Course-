using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan, targetEnemy;

    // Update is called once per frame
    void Update()
    {
        if(targetEnemy)
        {
            LookAtEnemy();
        }
    }

    public void LookAtEnemy()
    {
        objectToPan.LookAt(targetEnemy);
    }
}
