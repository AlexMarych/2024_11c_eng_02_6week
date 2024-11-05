using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFXController : MonoBehaviour
{
    public AudioSource Source_Run;
    public AudioSource Source_Jump;

    
    private PlayerController _movment_alt;
    
    //private PlayerJump _jump;
    
    //private PlayerAxisXMovement _run;

    private void Awake()
    {
        _movment_alt = GetComponent<PlayerController>();
        //_jump = GetComponent<PlayerJump>();
        //_run = GetComponent<PlayerAxisXMovement>();
    }

    public void PlayRun()
    {
        if (!Source_Run.isPlaying && !Source_Jump.isPlaying)
        {
            Source_Run.Play();
        }
    }

    public void PlayJump() 
    {
        if (!Source_Jump.isPlaying)
        {
            Source_Run.Stop();
            Source_Jump.Play();
        }
    }

    void Update()
    {
        if (_movment_alt.IsMoving() && _movment_alt.IsGrounded())
        {
            PlayRun();
        }
        else if (_movment_alt.IsJumping())
        {
            PlayJump();
        }
        else
        {
            Source_Run.Stop();
            Source_Jump.Stop();
        }
    }
}
