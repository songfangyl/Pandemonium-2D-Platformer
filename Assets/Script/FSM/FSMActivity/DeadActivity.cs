using UnityEngine;
using Level;

namespace AI.FSM.Activities
{
    [CreateAssetMenu(menuName = "AI/FSM/Activity/DeadActivity")]
    public class DeadActivity : Activity
    {
        // public AudioClip deadClip;
 
        EnemyState enemyState;

        private GameObject player;
 
        public override void Enter(BaseStateMachine stateMachine)
        {
            // Gaining EXP
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerLevel>().KillEnemy();

            //Animation for death
            enemyState = stateMachine.GetComponent<EnemyState>();
            stateMachine.GetComponent<Animator>().Play("Death");
            stateMachine.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
 
            // stateMachine.GetComponent<AudioSource>().PlayOneShot(deadClip);
        }
 
        public override void Execute(BaseStateMachine stateMachine)
        {
            enemyState.deadTimer += 1.5f * Time.deltaTime;
            if(enemyState.deadTimer >= 1.0f)
            {
                Destroy(stateMachine.GetComponentInParent<Transform>().gameObject);
            }
            else
            {
                stateMachine.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f, Mathf.Lerp(1, 0, enemyState.deadTimer));
            }
        }
 
        public override void Exit(BaseStateMachine stateMachine)
        {
        }
    }
}
