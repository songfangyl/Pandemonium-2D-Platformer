using UnityEngine;
 
public class EnemyState : MonoBehaviour
{
    public LayerMask enemyLayer;
 
    public int HP = 3;
    public int maxHP = 3;
    int executionNumber = 0;
 
    public bool isHit = false, isDead = false;
    public float hitTimer = 0, deadTimer = 0, attackRange = .35f;
    public Vector2 hitDir = Vector2.zero;
    
 
    public void ExecuteAttack()
    {
        executionNumber++;
        if (executionNumber == 1)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Collider2D[] hitTargets = Physics2D.OverlapCircleAll(transform.GetChild(0).position, attackRange, enemyLayer);
 
            if(hitTargets.Length > 0 && hitTargets[0] != null)
            {
                GameManager.instance.subtractHP(1);
            }
         }
    }
 
    public void ResetAttack()
    {
        executionNumber = 0;
    }

    public void flipSprite(float xDir)
    {
        if ((xDir > 0 && transform.localScale.x != -1) ||
            (xDir < 0 && transform.localScale.x != 1))
        {
            Vector3 transformScale = transform.localScale;
            transformScale.x *= -1;
            transform.localScale = transformScale;
        }
    }
}
