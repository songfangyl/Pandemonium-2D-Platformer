using UnityEngine;
 
namespace AI.FSM
{
    [CreateAssetMenu(menuName = "AI/FSM/Transition")]
    public sealed class Transition : ScriptableObject
    {
        public Decision  decision;
        public BaseState TrueState;
        public BaseState FalseState;
 
        public void Execute(BaseStateMachine stateMachine)
        {
            if(decision.Decide(stateMachine) && !(TrueState is RemainInState))
            {
                stateMachine.CurrentState.Exit(stateMachine);
                stateMachine.CurrentState = TrueState;
                stateMachine.CurrentState.Enter(stateMachine);
            }
            else if (!(FalseState is RemainInState))
            {
                stateMachine.CurrentState.Exit(stateMachine);
                stateMachine.CurrentState = FalseState;
                stateMachine.CurrentState.Enter(stateMachine);
            }
        }
    }
}
