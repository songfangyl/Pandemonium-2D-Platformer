using UnityEngine;
 
namespace AI.FSM
{
    public abstract class Activity : ScriptableObject
    {
        public abstract void Enter(BaseStateMachine stateMachine);
 
        public abstract void Execute(BaseStateMachine stateMachine);
 
        public abstract void Exit(BaseStateMachine stateMachine);
    }
}