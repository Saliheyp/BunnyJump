using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MainMenuText : MonoBehaviour
{
    public TextMeshProUGUI maxScoreText;
    public TextMeshProUGUI carrotCoinText;

    void Start()
    {   

        int maxScore=PlayerPrefs.GetInt("maxScoreUpdate");
        int carrotCoin=PlayerPrefs.GetInt("carrotCoin");
        maxScoreText.text = "Max Score = "+maxScore.ToString();
        carrotCoinText.text ="= "+carrotCoin.ToString();
    }

}
