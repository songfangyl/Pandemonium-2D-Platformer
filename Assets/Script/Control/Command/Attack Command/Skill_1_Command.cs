using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using SkillSystem;

namespace Control 
{
    [CreateAssetMenu(menuName = "Control/Command/Attack/Skill_1")] 
    public class Skill_1_Command : BaseCommand 
    {
        [SerializeField] private SkillManager skillManager;

        public override void Execute(InputAction action, GameObject player) 
        {
            skillManager.Execute_1(action, player);
        }
    }
}