using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level;
using QuestSystem;
using SkillSystem;

namespace SaveSystem
{

    [System.Serializable]
    public class SaveData
    {

        // Level Manager
        public int total_exp;

        public int curr_lvl;

        // Skill Manager

        public string skill_1;

        public string skill_2;

        public int skill_point;

        public List<string> unlockedSkill;

        // Quest Manager

        public List<string> doneQuest;

        // Equipement manager
    }
}
