using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Control 
{
    [CreateAssetMenu(menuName = "Control/Command/Attack/LightAttack")] 
    public class LightAttackCommand : BaseCommand 
    {
        [SerializeField] private LayerMask groundLayer;   
        public LayerMask enemyLayer;     
        bool attack = false;
        int executionNumber = 0;
        public float attackRange = .35f;
        GameObject gameObj;
        public override void Execute(InputAction action, GameObject player) 
        {
            if (gameObj == null) gameObj = player;
            if (player.GetComponent<PlayerMovement>().isGround() && action.WasPressedThisFrame()) {
                attack = true;
            }
  
            if(attack) {
                gameObj.GetComponent<Animator>().Play("Attack");
            }
        }

        public void ExecuteAttack()
        {
            if (attack)
            {

                executionNumber++;
                if (executionNumber == 1)
                {
                    gameObj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    Collider2D[] hitTargets = Physics2D.OverlapCircleAll(gameObj.transform.GetChild(0).position, attackRange, enemyLayer);
    
                    foreach (Collider2D hitTarget in hitTargets)
                    {
                        hitTarget.GetComponent<EnemyState>().hitDir = hitTarget.transform.position - gameObj.transform.position;
                        hitTarget.GetComponent<EnemyState>().isHit = true;
                    }
                }
            }
        }
        public void ResetAttack()
        {
            attack = false;
            executionNumber = 0;
        }

        // private bool isOnGround(GameObject gameObject)
        // {
        //     RaycastHit2D hit = Physics2D.BoxCast(gameObject.GetComponent<BoxCollider2D>().bounds.center, gameObject.GetComponent<CircleCollider2D>().radius, Vector2.down, 0.1f, groundLayer);
        //     return hit.collider != null;
        // }
    }
}