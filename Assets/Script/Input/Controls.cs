using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls 
{

    public class BaseCommand : ScriptableObject 
    {

        public virtual void Execute(InputAction action, GameObject gameObject = null) {}

        public virtual void FixedExecute(InputAction action, GameObject gameObject = null) {}
        
    }

    namespace Movement {
        public class Jump : BaseCommand 
        {
            [Range(0,20f)] [SerializeField] private float jumpVelocity = 16f;
            [Range(0,20f)] [SerializeField] private float fallVelocity = 0.85f;

            public override void Execute(InputAction action, GameObject gameObject = null)
            {
                
            }

            public override void FixedExecute(InputAction action, GameObject gameObject = null)
            {
               
            }

            private bool onGround (GameObject gameObject) 
            {
                return true;
            }
        }

         public class MoveLeft : BaseCommand 
        {

            public override void Execute(InputAction action, GameObject gameObject = null)
            {
                    
            }

            public override void FixedExecute(InputAction action, GameObject gameObject = null)
            {
                    
            }
        }

        public class MoveRight : BaseCommand 
        {

            public override void Execute(InputAction action, GameObject gameObject = null)
            {
                    
            }

            public override void FixedExecute(InputAction action, GameObject gameObject = null)
            {
                    
            }
        }
        
    }
    

}