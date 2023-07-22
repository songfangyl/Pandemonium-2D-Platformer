using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudio : MonoBehaviour
{
    
    private AudioSource actionSource;

    private AudioSource movementSource;

    void Awake()
    {
        AudioSource[] sources = GetComponents<AudioSource>();

        actionSource = sources[0];
        movementSource = sources[1];
    }

    
    // Movement AudioClip
    [SerializeField] private AudioClip moveAudio;

    [SerializeField] private AudioClip jumpAudio;

    [SerializeField] private AudioClip landAudio;

    [SerializeField] private AudioClip sprintAudio;

    [SerializeField] private AudioClip crouchAudio;


    // Action AudioClip;

    [SerializeField] private AudioClip attackAudio;

    [SerializeField] private AudioClip blockAudio;

    [SerializeField] private AudioClip hitAudio;

    [SerializeField] private AudioClip skillAudio1;

    [SerializeField] private AudioClip skillAudio2;

    [SerializeField] private AudioClip collectAudio;

    public void Attack()
    {
        actionSource.clip = attackAudio;
        actionSource.Play();
    }

    public void Block()
    {
        
    }

    public void Hit()
    {
        actionSource.PlayOneShot(hitAudio);
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
        movementSource.clip = moveAudio;
        movementSource.Play();
    }

    public void Sprint()
    {
        
    }

    public void Crouch()
    {
        // movementSource.clip = crouchAudio;
        // movementSource.Play(); 
        movementSource.PlayOneShot(crouchAudio);
    }

    public void Jump()
    {
        // movementSource.clip = jumpAudio;
        // movementSource.Play();
        movementSource.PlayOneShot(jumpAudio);
    }

    public void Land()
    {
        movementSource.PlayOneShot(landAudio);
    }
}
