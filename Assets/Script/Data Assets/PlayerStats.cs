using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level;
using System;

namespace DataAssets 
{
    [CreateAssetMenu(menuName = "DataAssets/PlayerStats")]
    public class PlayerStats : ScriptableObject 
    {
        // Reference to player's level
        [SerializeField] LevelManager levels;
        
        // Base stats 
        
        [SerializeField] private int baseHealth = 100;

        [SerializeField] private int baseAttack = 10;

        [SerializeField] private float baseSpeed = 7f;

        [SerializeField] private float baseJumpSpeed = 5f;


        // Stats after levelling && Equipment

        private int health;

        private int attack;

        private float speed;

        private float jumpSpeed;

        private void LevelScaling () 
        {
            int lvl = levels.lvl();
            
            health = (int)(baseHealth + 20 * lvl);
            attack = (int)(baseAttack + lvl);
            
        }

        private void EquipmentBuff()
        {
            // needs implemenation after creating inventory system
            speed = baseSpeed;
            jumpSpeed = baseJumpSpeed;

        }

        public void initialize() 
        {
            EquipmentBuff();
            LevelScaling();
                    
        }
        

        // Getter 

        public int Health() 
        {
            return health;
        }

        public int Attack()
        {
            return attack;
        }

        public float Speed() 
        {
            return speed;
        }

        public float JumpSpeed()
        {
            return jumpSpeed;
        }


       

    }

}
