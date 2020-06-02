using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(.1f, 120f)][SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemiesParent;
    [SerializeField] Text spawnedEnemies;
    int score;

    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        SetScoreText();
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true)
        {
            var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = enemiesParent;
            score++;
            SetScoreText();

            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void SetScoreText()
    {
        spawnedEnemies.text = "Score: " + score.ToString();
    }
}
