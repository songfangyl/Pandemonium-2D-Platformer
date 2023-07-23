using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

namespace SkillSystem
{

    public abstract class BaseSkill : ScriptableObject 
    {

        [SerializeField] new private string name;

        [SerializeField] protected AudioClip skillAudio;
        
        private bool unlocked = false;

        [SerializeField] private BaseSkill prev;

        // invoked at Skill Manager when Skill 1 & 2 is called
        public abstract void Execute (InputAction action, GameObject player);

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

        public string Name()
        {
            return name;
        }

        public AudioClip Audio()
        {
            return skillAudio;
        }
    }
}
