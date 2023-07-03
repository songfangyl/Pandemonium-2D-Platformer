using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Level
{
    
    [CreateAssetMenu(menuName = "LevelSystem/LevelManager")]
    public class LevelManager : ScriptableObject 
    {
        // Scene GUI
        GameObject GUI;


        // stats for the level system
        private int total_exp;

        private int curr_lvl;

        private int MAX_LVL = 15; // Constant for Max Lvl

        private int expToNextLevel () 
        {
            return (int)(Math.Pow(curr_lvl, 2) * 4.89 + 100 - total_exp);
        } 

        private bool nextLevel()
        {
            return expToNextLevel() >= 0;
        }


        public void GainXP (int xp) 
        {
            total_exp += xp;
            if (nextLevel())
                LevelUp();
        }
        
        // invoke level up event by player -> change player stats 
        void LevelUp() 
        {
            curr_lvl++;
            IncreasePlayerStats();
            UpdateGUI();
        }

        void IncreasePlayerStats()
        {

        }

        // Initialization 
        // need to modify to read save file after implemnting save/load
        void Awake() 
        {
            total_exp = 0;
            curr_lvl = 0;
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

}