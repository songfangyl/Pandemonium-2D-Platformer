using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float directionY;
    [SerializeField] float climbSpeed = 6f;
    private bool isClimbing;
    private bool isTouchingLadder;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        directionY = Input.GetAxis("Vertical");

        if (isTouchingLadder && Mathf.Abs(directionY) > 0f) {
            isClimbing = true;
        }
    }
    private void FixedUpdate() {
        if (isClimbing) {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, directionY * climbSpeed);
        } else {
            rb.gravityScale = 3f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ladder")) {
            isTouchingLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Ladder")) {
            isTouchingLadder = false;
            isClimbing = false;
        }
    }
}
