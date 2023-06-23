using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Control 
{

    [CreateAssetMenu(menuName = "Control/Command/Movement/Sprint")]
    public class SprintCommand : BaseCommand 
    {
        public override void Execute(InputAction action, GameObject player) 
        {
            PlayerMovement script = player.GetComponent<PlayerMovement>();
            bool sprint = action.ReadValue<float>() != 0;

            if (sprint) 
                script.sprint();
            else
                script.walk();

        }
    }
}