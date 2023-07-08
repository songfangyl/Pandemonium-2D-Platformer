using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    [CreateAssetMenu(menuName = "QuestSystem/Quest")]
    public class Quest : ScriptableObject
    {
        [SerializeField] private int required_level;

        [SerializeField] private Quest[] required_quest;

        [SerializeField] private string quest_name;

        [SerializeField] private string description;

        [SerializeField] private int reward_XP;

        private bool quest_completed = false;

        public string Quest_id()
        {
            return quest_name;
        }

        public void CompleteQuest() 
        {
            quest_completed = true;
        }

        public bool isCompleted()
        {
            return quest_completed;
        }

        public int Reward()
        {
            return reward_XP;
        }

        public string Description()
        {
            return description;
        }

        public int LevelNeeded()
        {
            return required_level;
        }
    }
}