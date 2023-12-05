using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDB : MonoBehaviour
{
   public int carrotCoin;
   public int maxScoreUpdate;


    private void Start()
    {
        LoadCoinAndScore();
    }

   public void CoinUpdate()
   {
    ++carrotCoin;
    PlayerPrefs.SetInt(nameof(carrotCoin), carrotCoin);
    PlayerPrefs.Save();
   }
   public void ScoreUpdate(int score)
   {
    if (maxScoreUpdate<score)
    {
        maxScoreUpdate = score;
    }
    PlayerPrefs.SetInt(nameof(maxScoreUpdate), maxScoreUpdate);
    PlayerPrefs.Save();
   }
   public void LoadCoinAndScore()
   {
    if (PlayerPrefs.HasKey("carrotCoin")||PlayerPrefs.HasKey("maxScoreUpdate"))
        {
            carrotCoin = PlayerPrefs.GetInt(nameof(carrotCoin),carrotCoin);
            maxScoreUpdate = PlayerPrefs.GetInt(nameof(maxScoreUpdate), maxScoreUpdate);
        }
        else
        {
            PlayerPrefs.GetFloat("carrotCoin",0);
            PlayerPrefs.GetFloat("maxScoreUpdate",0);

            carrotCoin = PlayerPrefs.GetInt("carrotCoin",carrotCoin);
            maxScoreUpdate = PlayerPrefs.GetInt("maxScoreUpdate",maxScoreUpdate);
        }
   }

}
