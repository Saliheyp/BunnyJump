using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    public GameObject BoatPrefab; 
    public Transform spawnPoint; 
    public float spawnFrequency = 2.0f;
    private float lastSpawnTime = 0.0f;

    void Update()
    {
        if (Time.time - lastSpawnTime > spawnFrequency)
        {
            SpawnBoat();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnBoat()
    {
        GameObject newBlock = Instantiate(BoatPrefab, spawnPoint.position, Quaternion.identity);
    }
}
