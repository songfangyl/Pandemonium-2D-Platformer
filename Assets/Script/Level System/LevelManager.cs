using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DataAssets;
using SkillSystem;
using SaveSystem;

namespace Level
{
    
    [CreateAssetMenu(menuName = "LevelSystem/LevelManager")]
    public class LevelManager : ScriptableObject 
    {
        // Reference to playerStats
        [SerializeField] PlayerStats playerStats;

        // Reference to Skill system
        [SerializeField] SkillManager skillManager;
        
        [SerializeField] SaveManager saveManager;

        // stats for the level system
        private int total_exp;

        private int curr_lvl;

        private int MAX_LVL = 5; // Constant for Max Lvl

        public int currentLevelExp()
        {
            return total_exp - (int)(400 * curr_lvl + 100);
        }

        public int currentLevelMaxExp()
        {
            return (int)(400 * curr_lvl + 100);
        }
        public int expToNextLevel () 
        {
            return (int)((400 * curr_lvl + 100) - total_exp);
        } 

        private bool nextLevel()
        {
            return expToNextLevel() <= 0;
        }


        // invoked only after quest complete (need modification)
        public void GainXP (int xp) 
        {
            total_exp += xp;
            while (nextLevel() && curr_lvl < MAX_LVL)
                LevelUp();
            saveManager.SaveGame();
        }
        
        // invoke level up event by player -> change player stats 
        void LevelUp() 
        {
            curr_lvl++;
            skillManager.AddSkillPoint();
        }

        // Initialization 
        // need to modify to read save file after implemnting save/load
        void Awake() 
        {
            if (saveManager.save == null) 
                saveManager.LoadGame();

            SaveData save = saveManager.save;
            
            total_exp = save.total_exp;
            curr_lvl = save.curr_lvl;
            if (curr_lvl == 0) {
                curr_lvl = 1;
            }
        }


        // Getter
        public int lvl() 
        {
            if (curr_lvl == 0) curr_lvl += 1;
            return curr_lvl;
        }

        public int XP()
        {
            return total_exp;
        } 
 
        public int Lvl_XP()
        {
            return total_exp + expToNextLevel();
        }
    }

}