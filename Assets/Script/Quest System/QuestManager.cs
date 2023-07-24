using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level;
using UnityEngine.SceneManagement;
using DataAssets;
using SaveSystem;

namespace QuestSystem
{
    [CreateAssetMenu(menuName = "QuestSystem/QuestManager")]
    public class QuestManager : ScriptableObject 
    {
        [SerializeField] private LevelManager levelManager;

        [SerializeField] private EnemyStats enemyStats;

        [SerializeField] private List<Quest> questList;

        [SerializeField] private SaveManager saveManager;

        private Dictionary<string, Quest> questDictionary;

        private int EnemyXP;
        
        private int CollectedXP;

        // all methods are intended to be invoked by either the GUI for quest menu or when the quest is completed

        // to load quest after clicking at GUI
        public void LoadQuest(Quest quest) 
        {
            // need to implement difficulty scaling 
            enemyStats.IncreaseDifficulty();
            SceneManager.LoadScene(quest.Quest_id());
            EnemyXP = 0;
            CollectedXP = 0;
        }

        // to indicate if the quest is do-able at GUI
        public bool canDoQuest(Quest quest) 
        {
            return levelManager.lvl() >= quest.LevelNeeded();
        }
        
        public void CompleteQuest(Quest quest)
        {
            Debug.Log("" + levelManager.XP());
            if (!quest.isCompleted()) {
                levelManager.GainXP(quest.Reward() + EnemyXP + CollectedXP);
                quest.CompleteQuest();
                saveManager.SaveGame();
            }    
        }

        public List<string> CompletedQuest()
        {
            List<string> res = new List<string>();

            foreach (var quest in questList)
            {
                if (quest.isCompleted())
                    res.Add(quest.Quest_id());
            }

            return res;
        }

        public void KillEnemy(int XP)
        {
            EnemyXP += XP;
        }

        public void CollectItem(int XP)
        {
            CollectedXP += XP;
        }

        public void LoadSave() 
        {
            questDictionary = new Dictionary<string, Quest>();

            foreach (var quest in questList)
            {
                questDictionary.Add(quest.Quest_id(), quest);
            }

            // if (saveManager.save == null) 
            //     saveManager.LoadGame();

            SaveData save = saveManager.save;

            foreach (var questName in save.doneQuest)
            {
                questDictionary[questName].CompleteQuest();
            }
        }
    }
}