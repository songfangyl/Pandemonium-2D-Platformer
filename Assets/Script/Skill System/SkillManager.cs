using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level;

namespace SkillSystem
{

    [CreateAssetMenu(menuName = "SkillSystem/SkillManager")]
    public class SkillManager : ScriptableObject 
    {

        private BaseSkill skill_1;

        private BaseSkill skill_2;

        private int skillPoint = 0;

        public void AssignSkill_1(BaseSkill skill)
        {
            skill_1 = skill;
        }

        public void AssignSkill_2(BaseSkill skill)
        {
            skill_2 = skill;
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
             }
             else 
             {
                // Implement a prompt 
                Debug.Log("Not enough skill point");
             }
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
          
    }
}
