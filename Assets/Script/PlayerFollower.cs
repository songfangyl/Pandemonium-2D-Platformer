
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    private GameObject player;

    private bool touchPlayer = false;

    private float timer = 0f;
    
    [SerializeField] private int moveSpeed;
    private void Start() {
        player = GameObject.FindWithTag("Player");
    }

    private void Update() {
        if (touchPlayer) {
            if (timer > .5f) 
            {
                timer = 0f;
                touchPlayer = false;
            }
            else 
            {
                timer += Time.deltaTime;
            }
        } 
        else
        {  
            ChasePlayer();
        }
    }
    private void ChasePlayer()
    {
        this.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            touchPlayer = true;
        }
    }
}
