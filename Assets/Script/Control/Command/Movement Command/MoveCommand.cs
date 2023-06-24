using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Control
{
    [CreateAssetMenu(menuName = "Control/Command/Movement/Move")]
    public class MoveCommand : BaseCommand 
    {

        public override void Execute(InputAction action, GameObject player) 
        {
            //component retrieve from player object
            Rigidbody2D playerBody = player.GetComponent<Rigidbody2D>();
            PlayerMovement script = player.GetComponent<PlayerMovement>();

            float direction = action.ReadValue<float>();

            // to update animation
            script.directionChange(direction);

            //movement
            playerBody.velocity = new Vector2(direction * script.move(), playerBody.velocity.y);
        }
                
        
    
    }
}