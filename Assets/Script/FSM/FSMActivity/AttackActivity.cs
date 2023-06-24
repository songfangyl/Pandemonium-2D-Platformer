using UnityEngine;
 
namespace AI.FSM.Activities
{
    [CreateAssetMenu(menuName = "AI/FSM/Activity/AttackActivity")]
    public class AttackActivity : Activity
    {
        public override void Enter(BaseStateMachine stateMachine)
        {
            stateMachine.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            stateMachine.GetComponent<Animator>().Play("Attack");
        }
 
        public override void Execute(BaseStateMachine stateMachine)
        {
        }

 
        public override void Exit(BaseStateMachine stateMachine)
        {
            stateMachine.GetComponent<Animator>().Play("Idle");
        }
    }
}
