using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private PlayerMovement player;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update() 
    {
        anim.SetFloat("AirSpeedY", player.airSpeedY());
        anim.SetBool("Grounded", player.isGround());
        if (player.isMoving()) {
            anim.SetInteger("AnimState", 1);
        } else {
            anim.SetInteger("AnimState", 0);
        }
    }
}    