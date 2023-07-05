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


        // Difficulty scaling 
        private int health;
        private float speed;
        private int attack;

        public void IncreaseDifficulty() 
        {
            // has to implement after quest system
            health = baseHealth;
            speed = baseSpeed;
            attack = baseAttack;
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
    }
}