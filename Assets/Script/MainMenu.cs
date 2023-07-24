using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Control;
using SaveSystem;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SaveManager saveManager;
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Load()
    {
        saveManager.LoadGame();
    }

}
