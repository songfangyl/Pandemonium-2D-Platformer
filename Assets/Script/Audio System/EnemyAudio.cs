using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyAudio : MonoBehaviour
{
    private AudioSource actionSource;

    private AudioSource movementSource;

    void Awake()
    {
        AudioSource[] sources = GetComponents<AudioSource>();

        actionSource = sources[0];
        movementSource = sources[1];
    }

    [SerializeField] private AudioClip moveAudio;
    [SerializeField] private AudioClip attackAudio;
    [SerializeField] private AudioClip hitAudio;
    [SerializeField] private AudioClip detectAudio;

    public void Move()
    {
        movementSource.clip = moveAudio;
        movementSource.Play();
    }

    public void Attack()
    {
        actionSource.clip = attackAudio;
        actionSource.Play();
    }

    public void Hit()
    {
        actionSource.PlayOneShot(hitAudio);
    }

    public void Detect()
    {
        actionSource.PlayOneShot(detectAudio);
    }
}
