using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Control
{
    [CreateAssetMenu(menuName = "Control/Command/Movement/Jump")]
    public class JumpCommand : BaseCommand
    {
        

        public override void Execute(InputAction action, GameObject player)
        {
            Rigidbody2D playerBody = player.GetComponent<Rigidbody2D>();
            PlayerMovement script = player.GetComponent<PlayerMovement>();
            bool jumped = action.triggered && script.isGround();

            if (jumped) 
            {
                playerBody.velocity = new Vector3(0,script.jumpSpeed(),0);
            }


        }
    }
}


