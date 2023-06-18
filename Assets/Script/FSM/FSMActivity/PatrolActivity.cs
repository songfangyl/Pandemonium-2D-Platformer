using UnityEngine;
 
namespace AI.FSM.Activities
{
    [CreateAssetMenu(menuName = "AI/FSM/Activity/PatrolActivity")]
    public class PatrolActivity : Activity
    {
        [SerializeField] float speed = 1; // how fast we should move around while patrolling?
 
        public override void Enter(BaseStateMachine stateMachine)
        {
            Debug.Log("PatrolActivityEnter");
            var PatrolPoints   = stateMachine.GetComponent<PatrolPoints>();
            var SpriteRenderer = stateMachine.GetComponent<SpriteRenderer>();
            var Animator       = stateMachine.GetComponent<Animator>();
            var Transform      = stateMachine.GetComponent<Transform>();  
            SpriteRenderer.flipX = (Transform.position.x  - PatrolPoints.GetTargetPoint().x > 0) ? true : false;
            Animator.SetBool("isWalk", true);
        }
 
        public override void Execute(BaseStateMachine stateMachine)
        {
            var PatrolPoints   = stateMachine.GetComponent<PatrolPoints>();
            var RigidBody      = stateMachine.GetComponent<Rigidbody2D>();
            Vector2 target         = PatrolPoints.GetTargetPoint();
            var transform    = stateMachine.GetComponent<Transform>();
            
            // Vector2 position = RigidBody.position + new Vector2(x * speed * Time.fixedDeltaTime, RigidBody.position.y);
            // RigidBody.MovePosition(position);
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
 
        public override void Exit(BaseStateMachine stateMachine)
        {
            var PatrolPoints = stateMachine.GetComponent<PatrolPoints>();
            PatrolPoints.SetNextTargetPoint();  
        }
    }
}