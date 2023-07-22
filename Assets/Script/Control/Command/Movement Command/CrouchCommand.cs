using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Control 
{

    [CreateAssetMenu(menuName = "Control/Command/Movement/Crouch")]
    public class CrouchCommand : BaseCommand 
    {
        public override void Execute(InputAction action, GameObject player) 
        {
            PlayerMovement script = player.GetComponent<PlayerMovement>();
            bool active = action.ReadValue<float>() != 0;
            bool played = false;

            script.crouch(active);

            if (active && !played && action.WasPressedThisFrame())
            {
                player.GetComponent<PlayerAudio>().Crouch();
                played = true;
            }
            else if (!active)
                played = false;
        }
    }
}