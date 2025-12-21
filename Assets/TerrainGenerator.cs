using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [Header("")]
    [SerializeField] private GameObject buildingHorPrefab;
    [SerializeField] private GameObject buildingVerPrefab;
    [SerializeField] private int numberOfBuildings = 10;
    [SerializeField] private float spawnRangeX = 100f;
    [SerializeField] private float spawnRangeZ = 100f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfBuildings; i++)
        {
            SpawnBuilding();
        }
    }
    // Update is called once per frame
    private void SpawnBuilding()
    {
        float spawnPosX = Random.Range(-spawnRangeX / 2, spawnRangeX / 2);
        float spawnPosZ = Random.Range(-spawnRangeZ / 2, spawnRangeZ / 2);
        Vector3 spawnPosition = new Vector3(spawnPosX, 15, spawnPosZ);

        GameObject buildingPrefab = Random.value > 0.5f ? buildingHorPrefab : buildingVerPrefab;
        Instantiate(buildingPrefab, spawnPosition, Quaternion.identity);
    }
}