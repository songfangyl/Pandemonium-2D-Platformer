using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Control
{
    [CreateAssetMenu(menuName = "Control/Command/Movement/Move")]
    public class MoveCommand : BaseCommand 
    {

        [Range(0,20f)] [SerializeField] private float velocity = 10f; 
        
        public override void Execute(InputAction action, GameObject player) 
        {
            Rigidbody2D playerBody = player.GetComponent<Rigidbody2D>();
            PlayerMovement script = player.GetComponent<PlayerMovement>();
            float direction = action.ReadValue<float>();
           
            // to update animation
            script.directionChange(direction);

            //movement
            playerBody.velocity = new Vector2(direction * velocity, playerBody.velocity.y);
        }
                
        
    
    }
}