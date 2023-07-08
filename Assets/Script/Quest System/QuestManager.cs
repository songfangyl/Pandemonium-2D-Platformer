using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level;
using UnityEngine.SceneManagement;
using DataAssets;

namespace QuestSystem
{
    
    public class QuestManager : ScriptableObject 
    {
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private EnemyStats enemyStats;

        // all methods are intended to be invoked by either the GUI for quest menu or when the quest is completed

        // to load quest after clicking at GUI
        public void LoadQuest(Quest quest) 
        {
            // need to implement difficulty scaling 
            enemyStats.IncreaseDifficulty();
            SceneManager.LoadScene(quest.Quest_id());
        }

        // to indicate if the quest is do-able at GUI
        public bool canDoQuest(Quest quest) 
        {
            return levelManager.lvl() >= quest.LevelNeeded();
        }
        
        public void CompleteQuest(Quest quest)
        {
            levelManager.GainXP(quest.Reward());
            quest.CompleteQuest();
        }
    }
}