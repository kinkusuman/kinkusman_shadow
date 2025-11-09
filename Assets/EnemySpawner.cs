using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int numberOfEnemies = 10;
    [SerializeField] private float spawnRangeX = 100f;
    [SerializeField] private float spawnRangeZ = 100f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfEnemies; i ++)
        {
            SpawnEnemy();
        }
    }

    // Update is called once per frame
    private void SpawnEnemy()
    {
        float spawnPosX = Random.Range(-spawnRangeX / 2, spawnRangeX / 2);
        float spawnPosZ = Random.Range(-spawnRangeZ / 2, spawnRangeZ / 2);
        Vector3 spawnPosition = new Vector3(spawnPosX, 0, spawnPosZ);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
