using UnityEngine;
 
namespace AI.FSM.Decisions
{
    [CreateAssetMenu(menuName = "AI/FSM/Decisions/KilledDecision")]
    public class KilledDecision : Decision
    {
        public bool isDead = true;
 
        public override bool Decide(BaseStateMachine stateMachine)
        {
            return stateMachine.GetComponent<EnemyState>().isDead == isDead ? true : false;
        }
    }
}