using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    
    public move bunny;
    public CoinDB coinDB;
    public int carrotCoin = 0;
    public GameObject coinPanel;
    public TextMeshProUGUI coinText ;
    public TextMeshProUGUI scoreText;
    
    public float score=0;
    private int maxScore = 0;

    public void Start()
    {
        scoreText.text = "Score = 0";
    }

    void Update()
    {
        UpdateScore();
    }
    public void UpdateCoin()
    {
        carrotCoin ++;
        coinText.text="= "+carrotCoin.ToString();
        coinPanel.SetActive(true);
        StartCoroutine(HideCoinPanelAfterDelay(1.5f));
    
    }
    private IEnumerator HideCoinPanelAfterDelay(float delay)
    {
    yield return new WaitForSeconds(delay);
    coinPanel.SetActive(false);
    }

    public void UpdateScore()
    {
        score = bunny.transform.position.y+9;
        if (score>maxScore)
        {
            maxScore=(int)score;
            scoreText.text = "Score ="+maxScore;
            coinDB.ScoreUpdate(maxScore);

        }
    }

}
