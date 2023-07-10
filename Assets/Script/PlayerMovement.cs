using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DataAssets;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator anim;

    private SpriteRenderer sp;

    private BoxCollider2D coll;

    private Bounds normalBound;

    private Bounds crouchBound;

    private Vector2 mousePos;

    private float directionX = 0f;

    private Transform trans;

    // To load character values
    [SerializeField] private PlayerStats playerStats;


    [SerializeField] private Camera cam;

    
    


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        trans = GetComponent<Transform>();
        normalBound = coll.bounds;

        LoadStats();
    }
    
    // Update is called once per frame
    private void Update()
    {
        animationUpdate();
    }

    

    // player's moving
    private float moveSpeed;

    private float walkSpeed;

    private float sprintSpeed;
    
    public void LoadStats() 
    {
        playerStats.initialize();

        walkSpeed = playerStats.Speed();
        sprintSpeed = walkSpeed * 1.8f;
        moveSpeed = walkSpeed;
        jumpVelocity = playerStats.JumpSpeed();
    }

    public float move()    {   return moveSpeed;   }

    public void sprint()    {   moveSpeed = sprintSpeed;     }

    public void walk()      {   moveSpeed = walkSpeed;     }



    // player jumping 
   
    private float jumpVelocity;

    [SerializeField] private LayerMask jumpableGround;

    public float airSpeedY()    {  return rb.velocity.y; }

    public float jumpSpeed()    {  return jumpVelocity; }

    public bool isGround() {   return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);  }


    //  crouching
    [SerializeField] private Vector2 standingSize;

    [SerializeField] private Vector2 crouchingSize;

    public void crouch(bool active) 
    {
        if (active) 
            coll.size = crouchingSize;
        else
            coll.size = standingSize;
        
    }





    // keeping for animation
    public bool isMoving()  {   return directionX != 0; }

    public void directionChange(float dir) {    directionX = dir;  }
    
    private void animationUpdate() 
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        if (mousePos.x >= rb.position.x) 
        {
            Vector3 transformScale = transform.localScale;
            transformScale.x = 1;
            transform.localScale = transformScale;

        } else 
        {
            Vector3 transformScale = transform.localScale;
            transformScale.x = -1;
            transform.localScale = transformScale;
        }

    }
    
    // public float getAttackTime() {
    //     return m_timeSinceAttack;
    // }

    // public void resetAttackTime() {
    //     m_timeSinceAttack = 0;
    // }
    // fang yi stupid   



    // need to remove
    // private void horizontalMove() {
    //     directionX = Input.GetAxisRaw("Horizontal");
    //     rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
    // }

    // private void sprint() {
    //     if  (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) {
    //         moveSpeed *= 2f;
    //     }
    //     if  (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)) {
    //         moveSpeed /= 2f;
    //     }
    // }

    // private void jump() {
    //     if (Input.GetButtonDown("Jump") && isGround())
    //     {
    //         rb.velocity = new Vector3(0, jumpForce, 0);
    //     }
    // }

    
}
