using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudio : MonoBehaviour
{
    
    [SerializeField] AudioSource actionSource;

    [SerializeField] AudioSource movementSource;

    
    // Movement AudioClip
    private AudioClip moveAudio;

    private AudioClip jumpAudio;

    private AudioClip sprintAudio;

    private AudioClip crouchAudio;


    // Action AudioClip;

    private AudioClip attackAudio;

    private AudioClip blockAudio;

    private AudioClip skillAudio1;

    private AudioClip skillAudio2;

    private AudioClip collectAudio;

    public void Attack()
    {

    }

    public void Block()
    {
        
    }

    public void Skill1()
    {
        
    }

    public void Skill2()
    {
        
    }

    public void Collect()
    {
        
    }

    public void Move()
    {
        
    }

    public void Sprint()
    {
        
    }

    public void Crouch()
    {
        
    }

    public void Jump()
    {
        
    }
}
