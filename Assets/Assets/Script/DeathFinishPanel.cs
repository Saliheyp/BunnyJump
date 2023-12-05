using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathFinishPanel : MonoBehaviour
{
    public GameObject deathPanel;
    public GameObject bigWay;
    public GameObject bigWay1;
    public GameObject bigWay2;
    public bool gamePaused = false;
    public Timer time;
    public GameObject finishPanel;
    public GameObject startPanel;
    public GameObject hintPanel;
    public GameObject settingsPanel;
    public void Start()
    {
        bigWay1.transform.position = new Vector3 (0f,bigWay.transform.position.y + 18f,0f );
    }
     public void ShowDeathPanel()
    {
        deathPanel.SetActive(true);
    }
   public void RestartGame()
    {
            Time.timeScale=1f;
            gamePaused = false;
        settingsPanel.SetActive(false);
        SceneManager.LoadScene("level1");
    }
    public void ShowFinishPanel()
    {
        finishPanel.SetActive(true);
    }
    public void PlayGame()
    {
        startPanel.SetActive(false);
        hintPanel.SetActive(false);
    }
    public void HintPanel()
    {
        hintPanel.SetActive(true);
    }
    public void SettingPanelActive()
    {
        if (!gamePaused)
        {
            Time.timeScale=0f;
            gamePaused = true;
        }
        settingsPanel.SetActive(true);
    }
    public void SettingPanelInactive()
    {
        if (gamePaused)
        {
            Time.timeScale=1f;
            gamePaused = false;
        }
        settingsPanel.SetActive(false);
    }
    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
