using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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

        [SerializeField] private AudioClip defaultSFX;

        private int skillPoint;

        public void AssignSkill_1(BaseSkill skill)
        {
            if (skill == null) 
            {
                return;
            }
            
            if (skill.isUnlocked()) 
            {
                skill_1 = skill;
                saveManager.SaveGame();
            }
            else
            {
                Debug.Log("Skill have to be unlocked first");
            }
        }

        public void AssignSkill_2(BaseSkill skill)
        {
            if (skill == null) 
            {
                return;
            }

            if (skill.isUnlocked())
            { 
                skill_2 = skill;
                saveManager.SaveGame();
            }
            else
            {
                Debug.Log("Skill have to be unlocked first");
            }
            
        }

        public void AddSkillPoint()
        {
            skillPoint ++;
        }

        public void UnlockSkill(BaseSkill skill)
        {
            if (skill == null) 
            {
                return;
            }

            if (skill.canUnlock() && skill.isUnlocked() == false)
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
            else
            {
                Debug.Log("You cannot unlock this skill/ already unlock this skill");
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

        public AudioClip Audio1()
        {
            if(skill_1 != null)
                return Skill_1().Audio();
            else  
                return defaultSFX;
        }

        public AudioClip Audio2()
        {
            if(skill_2 != null)
                return Skill_2().Audio();
            else  
                return defaultSFX;
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

        public void Execute_1(InputAction action, GameObject player) 
        {
            if (skill_1 != null)
                skill_1.Execute(action, player); 
        }

        public void Execute_2(InputAction action, GameObject player) 
        {
            if (skill_2 != null)
                skill_2.Execute(action, player);
        }
          

        public void LoadSave()
        {
            skillDictionary = new Dictionary<string, BaseSkill>();

            foreach (var skill in skills)
            {
                skillDictionary.Add(skill.Name(), skill);
            }

            // if (saveManager.save == null)
            //     saveManager.LoadGame();

            SaveData save = saveManager.save;

            skillPoint = save.skill_point;

            foreach (var skillName in save.unlockedSkill)
            {
                skillDictionary[skillName].Unlock();
            }

            if (skillDictionary.ContainsKey(save.skill_1)) 
                skill_1 = skillDictionary[save.skill_1];

            if (skillDictionary.ContainsKey(save.skill_2)) 
                skill_2 = skillDictionary[save.skill_2];
            
        }

        public BaseSkill GetSkill1()
        {
            return skill_1;
        }

        public BaseSkill GetSkill2()
        {
            return skill_2;
        }
    }
}
