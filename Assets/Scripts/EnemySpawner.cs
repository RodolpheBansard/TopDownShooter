using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject particlePrefab;
    [SerializeField] Vector2 spawnerSize;    

    private int nWave;
    private int nEnemy=10;


    public void SpawnWave()
    {
        nEnemy = Random.Range(2, 5);
        for (int i = 0; i < nEnemy; i++) {
            float x = Random.Range(-spawnerSize.x,spawnerSize.x);
            float y = Random.Range(-spawnerSize.y, spawnerSize.y);
            StartCoroutine(SpawnEnemy(x,y));
            
        }
    }

    IEnumerator SpawnEnemy(float x, float y)
    {
        Instantiate(particlePrefab, new Vector2(x, y), Quaternion.identity);
        yield return new WaitForSeconds(1);
        Instantiate(enemyPrefab, new Vector2(x, y), Quaternion.identity);
    }
    
    public int GetNumberEnemy()
    {
        return nEnemy;
    }

}
