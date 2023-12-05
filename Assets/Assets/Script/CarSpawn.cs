using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] carPrefabs; 
    public Transform spawnPoint;
    public float spawnFrequency = 2.0f;
    private float lastSpawnFrequency = 0.0f;
    
    void Update()
    {
        if (Time.time - lastSpawnFrequency > spawnFrequency)
        {
            SpawnCar();
            lastSpawnFrequency = Time.time;
        }
    }

    void SpawnCar()
    {
        GameObject newCar = Instantiate(carPrefabs[Random.Range(0,carPrefabs.Length)], spawnPoint.position, Quaternion.identity);
    }
}

