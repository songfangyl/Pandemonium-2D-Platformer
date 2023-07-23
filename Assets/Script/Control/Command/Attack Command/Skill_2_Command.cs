using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using SkillSystem;

namespace Control 
{
    [CreateAssetMenu(menuName = "Control/Command/Attack/Skill_2")] 
    public class Skill_2_Command : BaseCommand 
    {

        [SerializeField] private SkillManager skillManager;

        public override void Execute(InputAction action, GameObject player) 
        {
                skillManager.Execute_2(action, player);           
        }
    }
}