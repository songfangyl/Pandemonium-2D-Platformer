using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    
   
    

    [SerializeField] private Camera cam;

    
    private enum MovementState {idle, running, jumping, falling};
    


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        normalBound = coll.bounds;
    }
    
    // Update is called once per frame
    private void Update()
    {
        //horizontalMove();
        //jump();
        //sprint();
        animationUpdate();
        //crouch();
    }


    // player's velocity
    [Range(0, 20f)] [SerializeField] private float moveSpeed = 7f;
    [Range(1, 2f)] [SerializeField] private float sprintMultplier = 1.5f;

    public float speed()    {   return moveSpeed;   }

    //sprinting 
    public void sprint()    {   moveSpeed *= sprintMultplier;     }
    public void walk()      {   moveSpeed /= sprintMultplier;     }

    // player jumping 
    [Range(0, 20f)] [SerializeField] private float jumpVelocity = 10f;
    [Range(0, 10f)] [SerializeField] private float dropVelocity = 5f;
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
        
        if (mousePos.x >= rb.position.x) {
            sp.flipX = false;
        } else {
            sp.flipX = true;
        }
    }
    
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
