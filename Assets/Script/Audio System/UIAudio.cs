using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UIAudio : MonoBehaviour
{
    AudioSource UISource;

    [SerializeField] AudioClip clickSound;

    [SerializeField] AudioClip hoverSound;

    [SerializeField] AudioClip backSound;

    public void Click()
    {
        UISource.PlayOneShot(clickSound);
    }

    public void Hover()
    {
        UISource.PlayOneShot(hoverSound);
    }

    public void Back()
    {
        UISource.PlayOneShot(backSound);
    }

    void Start()
    {
        UISource = GetComponent<AudioSource>();
    }
}
