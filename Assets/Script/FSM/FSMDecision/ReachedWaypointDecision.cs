using UnityEngine;
 
namespace AI.FSM.Decisions
{
    [CreateAssetMenu(menuName = "AI/FSM/Decisions/ReachedWaypointDecision")]
    public class ReachedWaypointDecision : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var res = stateMachine.GetComponent<PatrolPoints>().HasReachedPoint();
            return res;
        }
    }
}