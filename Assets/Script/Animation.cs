using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private PlayerMovement player;
    [SerializeField] private Camera cam;

    private Animator anim;
    // Start is called before the first frame update
    private void Awake() {
        player = GetComponent<PlayerMovement>();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() 
    {
        if (player.isGround()) {
            Debug.Log("isGROUND!!!!!");
        } 
        anim.SetFloat("AirSpeedY", player.airSpeedY());
        anim.SetBool("Grounded", player.isGround());
        if (player.isMoving()) {
            anim.SetInteger("AnimState", 1);
        } else {
            anim.SetInteger("AnimState", 0);
        }
    }
}    