using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Parameters of each tower
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;

    // State of each tower
    Transform targetEnemy;

    void Update()
    {
        SetTargetEnemy();

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

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();

        if(sceneEnemies.Length == 0) return;
        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage enemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, enemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        float distanceToA = Vector3.Distance(transformA.position, transform.position);
        float distanceToB = Vector3.Distance(transformB.position, transform.position);

        return distanceToA < distanceToB ? transformA : transformB;
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
