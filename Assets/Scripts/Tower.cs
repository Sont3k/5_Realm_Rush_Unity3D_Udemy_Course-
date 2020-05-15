using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan, targetEnemy;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;

    void Update()
    {
        if(targetEnemy)
        {
            LookAtEnemy();
            FireAtEnemy();
        }
        else
        {
            Shoot(false); //TODO producing null error
        }
    }

    public void LookAtEnemy()
    {
        objectToPan.LookAt(targetEnemy);
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.position, transform.position);
        
        if(distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
