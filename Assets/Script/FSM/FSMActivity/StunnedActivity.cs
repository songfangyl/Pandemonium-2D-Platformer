using UnityEngine;
 
namespace AI.FSM.Activities
{
    [CreateAssetMenu(menuName = "AI/FSM/Activity/StunnedActivity")]
    public class StunnedActivity : Activity
    {
        // public AudioClip hitClip;
        public float hitInvincibilityTime = 1,
                     hitAnimationSpeed = 1;
 
        EnemyState enemyState;
 
        public override void Enter(BaseStateMachine stateMachine)
        {
            enemyState = stateMachine.GetComponent<EnemyState>();
 
            // stateMachine.GetComponent<AudioSource>().PlayOneShot(hitClip);
            stateMachine.GetComponent<Animator>().SetTrigger("Hurt");
            stateMachine.GetComponent<Rigidbody2D>().AddForce(new Vector2(enemyState.hitDir.x * 2.5f, 3f), ForceMode2D.Impulse);
        }
 
        public override void Execute(BaseStateMachine stateMachine)
        {
            if(enemyState.isHit)
            {
                enemyState.hitTimer += Time.deltaTime;
                if (enemyState.hitTimer >= hitInvincibilityTime)
                {
                    enemyState.HP--;
                    enemyState.hitTimer = 0;
                    enemyState.isHit = false;
                    if (enemyState.HP == 0)
                    {
                        enemyState.isDead = true;
                    }
                }
            }
        }
 
 
        public override void Exit(BaseStateMachine stateMachine)
        {
        }
    }
}
