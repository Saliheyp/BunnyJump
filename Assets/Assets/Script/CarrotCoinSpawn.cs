using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCoinSpawn : MonoBehaviour
{
    [SerializeField] GameObject carrotCoin;
    public bool isTrig = false;
    bool executed = false;
    [SerializeField] Transform spawnPoint;
    
      public void CarrotCoinSpawner()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-20f, 20f), 0f,0f);
        Instantiate(carrotCoin,spawnPoint.position + spawnPosition , Quaternion.identity);
    }

    public void CarrotCoinDestroy()
    {
        GameObject[] carrots = GameObject.FindGameObjectsWithTag("Carrot");

        foreach (GameObject carrot in carrots)
        {
            Destroy(carrot);
        }

    }
}
