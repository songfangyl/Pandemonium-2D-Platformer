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
        
        [SerializeField] private float baseHealth = 100f;
        [SerializeField] private float baseAttack = 10f;
        [SerializeField] private float baseSpeed = 7f;
        [SerializeField] private float baseJumpSpeed = 5f;


        // Stats after levelling && Equipment

        private float health;
        private float attack;
        private float speed;
        private float jumpSpeed;

        private void LevelScaling () 
        {
            int lvl = levels.lvl();
            
            health = lvl * baseHealth + 50 * (float)Math.Pow(lvl - 1, 0.68);
            attack = lvl * baseAttack + 5 * (float)Math.Pow(lvl - 1, 0.49);
            
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

        public float Speed() 
        {
            return speed;
        }

        public float Health() 
        {
            return health;
        }

        public float JumpSpeed()
        {
            return jumpSpeed;
        }


       

    }

}
