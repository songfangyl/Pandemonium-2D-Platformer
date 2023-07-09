using UnityEngine;
using DataAssets;
 
public class EnemyState : MonoBehaviour
{
    // Data asset for enemy
    [SerializeField] private EnemyStats enemyStats;

    private void LoadStats()
    {
        enemyStats.IncreaseDifficulty();

        maxHP = enemyStats.Health();
        HP = maxHP;
        attack = enemyStats.Attack();

    }

    void Awake() 
    {
        LoadStats();
    }
    
    // Enemy stats
    private int HP;

    private int maxHP;

    private int attack;
  
    // Information for executing attack
    public LayerMask enemyLayer;
 
    int executionNumber = 0;
 
    public bool isHit = false, isDead = false;

    public float hitTimer = 0, deadTimer = 0, attackRange = 1f;

    public Vector2 hitDir = Vector2.zero;
    


    // Invoke at animation script, to allign with attack animation 

    public void ExecuteAttack()
    {
        executionNumber++;
        if (executionNumber == 1)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            
            Collider2D[] hitTargets = Physics2D.OverlapCircleAll(transform.GetChild(0).position, attackRange, enemyLayer);

            if (hitTargets.Length > 0 && hitTargets[0] != null)
            {
                foreach (Collider2D hitTarget in hitTargets)
                {
                    hitTarget.GetComponent<PlayerLife>().subtractHP(attack);
                }
            }
         }
    }
 
    public void ResetAttack()
    {
        executionNumber = 0;
    }


    // to update animation
    public void flipSprite(float xDir)
    {
        if ((xDir > 0 && transform.localScale.x > 0 ) ||
            (xDir < 0 && transform.localScale.x < 0))
        {
            Vector3 transformScale = transform.localScale;
            transformScale.x *= -1;
            transform.localScale = transformScale;
        }
    }

    public void takeDamage(int damage)
    {
        HP -= damage;
    }

    public int getMaxHP() 
    {
        return maxHP;
    }

    public int getHP()
    {
        return HP;
    }
}
