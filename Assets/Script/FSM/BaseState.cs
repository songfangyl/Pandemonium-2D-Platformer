using UnityEngine;
 
namespace AI.FSM
{
    public class BaseState : ScriptableObject
    {
        public virtual void Enter(BaseStateMachine machine) { }
 
        public virtual void Execute(BaseStateMachine machine) { }
     
        public virtual void Exit(BaseStateMachine machine) { }
    }
}

