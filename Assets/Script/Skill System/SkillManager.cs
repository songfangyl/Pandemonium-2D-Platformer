using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level;
using SaveSystem;

namespace SkillSystem
{

    [CreateAssetMenu(menuName = "SkillSystem/SkillManager")]
    public class SkillManager : ScriptableObject 
    {

        [SerializeField] private SaveManager saveManager;

        [SerializeField] private List<BaseSkill> skills;

        private Dictionary<string, BaseSkill> skillDictionary;
        
        private BaseSkill skill_1;

        private BaseSkill skill_2;

        private int skillPoint = 0;

        public void AssignSkill_1(BaseSkill skill)
        {
            skill_1 = skill;
            saveManager.SaveGame();
        }

        public void AssignSkill_2(BaseSkill skill)
        {
            skill_2 = skill;
            saveManager.SaveGame();
        }

        public void AddSkillPoint()
        {
            skillPoint ++;
        }

        public void UnlockSkill(BaseSkill skill)
        {
             if (skillPoint > 0) 
             {
                skillPoint --;
                skill.Unlock();
                saveManager.SaveGame();
             }
             else 
             {
                // Implement a prompt 
                Debug.Log("Not enough skill point");
             }
        }

        public BaseSkill Skill_1()
        {
            return skill_1;
        }

        public BaseSkill Skill_2()
        {
            return skill_2;
        }

        public int SkillPoint()
        {
            return skillPoint;
        }

        public List<string> UnlockedSkill()
        {
            List<string> res = new List<string>();

            foreach (var skill in skills)
            {
                if(skill.isUnlocked())
                    res.Add(skill.Name());
            }

            return res;
        }

        public void Execute_1(GameObject player) 
        {
            if (skill_1 != null)
                skill_1.Execute(player); 
        }

        public void Execute_2(GameObject player) 
        {
            if (skill_2 != null)
                skill_2.Execute(player);
        }
          

        void Awake()
        {
            skillDictionary = new Dictionary<string, BaseSkill>();

            foreach (var skill in skills)
            {
                skillDictionary.Add(skill.Name(), skill);
            }

            if (saveManager.save == null)
                saveManager.LoadGame();

            SaveData save = saveManager.save;

            foreach (var skillName in save.unlockedSkill)
            {
                skillDictionary[skillName].Unlock();
            }
        }
    }
}
