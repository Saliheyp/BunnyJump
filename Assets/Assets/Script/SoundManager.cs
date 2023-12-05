using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public Slider slider;
    public TextMeshProUGUI musicVolumeAmount;
    public TextMeshProUGUI soundVolumeAmount;
    public AudioSource musicAudioSource;
    [SerializeField] private AudioClip jump;
    private void Start()
    {
        LoadAudio();
    }

    public void Jump()
    {
        audioSource.PlayOneShot(jump);
    }
    public void SetAudioMusic(float value)
    {
        musicAudioSource.volume = value;
        musicVolumeAmount.text = Convert.ToString((int)(value*100));
        SaveAudio();
    }
    public void SetAudioSound(float value)
    {
        audioSource.volume = value;
        soundVolumeAmount.text = Convert.ToString((int)(value*100));
    }
    private void SaveAudio()
    {
        PlayerPrefs.SetFloat("audioVolume",musicAudioSource.volume);
        
    }
    private void LoadAudio()
    {
        if (PlayerPrefs.HasKey("audioVolume"))
        {
            musicAudioSource.volume = PlayerPrefs.GetFloat("audioVolume",musicAudioSource.volume);
            slider.value = PlayerPrefs.GetFloat("audioVolume",musicAudioSource.volume);
        }
        else
        {
            PlayerPrefs.GetFloat("audioVolume",0.5f);
            musicAudioSource.volume = PlayerPrefs.GetFloat("audioVolume",musicAudioSource.volume);
            slider.value = PlayerPrefs.GetFloat("audioVolume",musicAudioSource.volume);
        }
    }

}
