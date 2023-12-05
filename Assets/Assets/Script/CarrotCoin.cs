using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class CarrotCoin : MonoBehaviour
{
    [SerializeField]private CoinDB coinDB;

    [SerializeField]private Score score;
    

    void Start()
    {
        coinDB = GameObject.Find("GameManager").GetComponent<CoinDB>();
        score = GameObject.Find("GameManager").GetComponent<Score>();
        
    }


    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Bunny")
        {
            Destroy(gameObject);
            coinDB.CoinUpdate();
            score.UpdateCoin();
        }

    }

  
}
