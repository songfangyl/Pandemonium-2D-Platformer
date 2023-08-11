using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingMenu : MonoBehaviour
{

    // Slider to change volume
    // Slider volume is set : 0.0001 - 1.0000 to match the logarithmic function
    [SerializeField] Slider volumeSlider;

    [SerializeField] Slider musicVolumeSlider;

    [SerializeField] Slider SFXVolumeSlider;

    // mixer to handle input + output
    [SerializeField] AudioMixer mixer;


    // Key to access mixer group
    public const string MASTER_KEY = "MasterVolume";

    public const string MUSIC_KEY = "MusicVolume";

    public const string SFX_KEY = "SFXVolume";


    void Start()
    {
        Load();
    }

    // To keep track of Volume settings 
    // keeping in Playerprefs is enough, given it does not affect gameplay
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(MASTER_KEY, 1f);
        musicVolumeSlider.value = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        SFXVolumeSlider.value =  PlayerPrefs.GetFloat(SFX_KEY, 1f);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat(MASTER_KEY, volumeSlider.value);
        PlayerPrefs.SetFloat(MUSIC_KEY, musicVolumeSlider.value);
        PlayerPrefs.SetFloat(SFX_KEY, SFXVolumeSlider.value);
    }
    
    // methods to change volume logarithmicly
    public void ChangeVolume()
    {
        mixer.SetFloat(MASTER_KEY, Mathf.Log10(volumeSlider.value) * 20);
        Save();
    }

    public void ChangeMusicVolume()
    {
        mixer.SetFloat(MUSIC_KEY, Mathf.Log10(musicVolumeSlider.value) * 20);
        Save();
    }

    public void ChangeSFXVolume()
    {
        mixer.SetFloat(SFX_KEY, Mathf.Log10(SFXVolumeSlider.value) * 20);
        Save();
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
