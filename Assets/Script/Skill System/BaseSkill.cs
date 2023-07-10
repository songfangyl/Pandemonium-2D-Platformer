using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkillSystem
{

    public abstract class BaseSkill : ScriptableObject 
    {

        private bool unlocked = false;

        [SerializeField] private BaseSkill prev;

        // invoked at Skill Manager when Skill 1 & 2 is called
        public abstract void Execute (GameObject player);

        public bool isUnlocked()
        {
            return unlocked;
        }

        public bool canUnlock()
        {
            return prev == null || prev.isUnlocked();
        }
        
        public void Unlock()
        {
            unlocked = true;
        }

    }
}
