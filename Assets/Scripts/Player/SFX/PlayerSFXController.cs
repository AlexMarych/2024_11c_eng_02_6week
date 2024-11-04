using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFXController : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip Jump;
    public AudioClip Run;

    private PlayerJump _jump;
    private PlayerAxisXMovement _run;

    private void Awake()
    {
        _jump = GetComponent<PlayerJump>();
        _run = GetComponent<PlayerAxisXMovement>();
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

    void Update()
    {
        if (_run.IsMoving())
        {
            PlayRun();
        }
        else if (_jump.IsJumping())
        {
            PlayJump();
        }
    }
}
