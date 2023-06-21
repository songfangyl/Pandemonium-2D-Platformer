using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Control
{
    [CreateAssetMenu(menuName = "Control/Command/Movement/Jump")]
    public class JumpCommand : BaseCommand
    {
        [Range(0, 20f)] [SerializeField] private float jumpVelocity = 10f;
        [Range(0, 10f)] [SerializeField] private float dropVelocity = 5f;

        public override void Execute(InputAction action, GameObject player)
        {
           Rigidbody2D playerBody = player.GetComponent<Rigidbody2D>();
           PlayerMovement script = player.GetComponent<PlayerMovement>();
           bool jumped = action.triggered;


        }
    }
}


