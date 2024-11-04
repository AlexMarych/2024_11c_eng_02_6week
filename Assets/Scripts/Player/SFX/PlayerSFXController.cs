using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFXController : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip Jump;
    public AudioClip Run;

    private Rigidbody _rb;
    private GroundCheck _check;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _check = GetComponent<GroundCheck>();
    }

    public void PlayRun()
    {
        Source.clip = Run;
        Source.Play();
    }

    public void PlayJump() 
    {    
        Source.clip = Jump;
        Source.Play();
    }

    public void Stop()
    {
        Source.Stop();
    }
}
