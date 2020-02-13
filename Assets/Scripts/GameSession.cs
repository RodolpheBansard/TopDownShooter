using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    private int enemyRemaining = 10;
    private EnemySpawner enemySpawner;

    private void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();

        enemySpawner.SpawnWave();
        enemyRemaining = enemySpawner.GetNumberEnemy();
    }

    private void Update()
    {        
        if (enemyRemaining <= 0)
        {
            
            enemySpawner.SpawnWave();
            enemyRemaining = enemySpawner.GetNumberEnemy();
        }        
    }

    public void EnemyKilled()
    {
        
        enemyRemaining--;
    }
}
