using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level;
using UnityEngine.UI;

// Interaction between PlayerBody & LevelManager
public class PlayerLevel : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;

    [SerializeField] private Slider ExpSlider;

    [SerializeField] private Text LevelText;

    // Stats for GUI
     private int lvl;

     private int XP;

     private int lvl_XP;

     void Awake() 
    {
        LoadStats();
        ExpSlider.maxValue = levelManager.expToNextLevel();
        ExpSlider.value = 0;
        LevelText.text = "LVL " + lvl;
    }

    private void LoadStats()
    {
        lvl = levelManager.lvl();
        XP = levelManager.XP();
        lvl_XP = levelManager.Lvl_XP();
        ExpSlider.maxValue = levelManager.expToNextLevel();
        ExpSlider.value = 0;
    }

    // need to implement amount of XP earned
    public void KillEnemy()
    {
        int XP_earned = 30;

        levelManager.GainXP(XP_earned);

        XP += XP_earned;

        ExpSlider.value += XP_earned;

        if (XP >= lvl_XP)
            LoadStats();
            ReloadStats();

    }

    private void ReloadStats()
    {
        GetComponent<PlayerMovement>().LoadStats();
        GetComponent<PlayerLife>().LoadStats();
        // need to do invoke load stats for attack 
    }

    public void CollectItem()
    {
        int XP_earned = 2;

        levelManager.GainXP(XP_earned);

        XP += XP_earned;

        ExpSlider.value += XP_earned;

        if (XP >= lvl_XP)
            LoadStats();


    }

}
