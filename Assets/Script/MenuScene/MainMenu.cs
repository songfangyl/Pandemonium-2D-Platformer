using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Control;
using SaveSystem;
using Level;
using SkillSystem;
using QuestSystem;

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

}
