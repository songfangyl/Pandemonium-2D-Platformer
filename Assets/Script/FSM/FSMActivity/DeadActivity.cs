using UnityEngine;
using Level;
using QuestSystem;

namespace AI.FSM.Activities
{
    [CreateAssetMenu(menuName = "AI/FSM/Activity/DeadActivity")]
    public class DeadActivity : Activity
    {
        // public AudioClip deadClip;
 
        EnemyState enemyState;

        [SerializeField] QuestManager questManager;
 
        public override void Enter(BaseStateMachine stateMachine)
        {

            //Animation for death
            enemyState = stateMachine.GetComponent<EnemyState>();
            stateMachine.GetComponent<Animator>().Play("Death");
            stateMachine.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            // Gaining EXP
            questManager.KillEnemy(enemyState.XPearned());
            
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
