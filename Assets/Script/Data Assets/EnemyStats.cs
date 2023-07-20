using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataAssets
{
    // referenced by QuestSystem & EnemyState

    [CreateAssetMenu(menuName = "DataAssets/EnemyStats")]
    public class EnemyStats : ScriptableObject
    {

        // Base stats
        [SerializeField] private int baseHealth = 15;
        [SerializeField] private float baseSpeed = 5f;
        [SerializeField] private int baseAttack = 4;
        [SerializeField] private int baseXP = 30;


        // Difficulty scaling 
        private int health;
        private float speed;
        private int attack;
        private int XP;

        public void IncreaseDifficulty() 
        {
            // has to implement after quest system
            health = baseHealth;
            speed = baseSpeed;
            attack = baseAttack;
            XP = baseXP;
        }

        public int Health()
        {
            return health;
        }

        public float Speed()
        {
            return speed;
        }

        public int Attack()
        {
            return attack;
        }

        public int XPearned()
        {
            return XP;
        }
    }
}