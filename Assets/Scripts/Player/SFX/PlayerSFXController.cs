using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFXController : MonoBehaviour
{
    [SerializeField] private AudioSource _sourceRun;
    [SerializeField] private AudioSource _sourceJump;

    private PlayerController _movment_alt;

    private void Awake()
    {
        _movment_alt = GetComponent<PlayerController>();
    }

    public void PlayRun()
    {
        if (!_sourceRun.isPlaying && !_sourceJump.isPlaying)
        {
            _sourceRun.Play();
        }
    }

    public void PlayJump()
    {
        if (!_sourceJump.isPlaying)
        {
            _sourceJump.Play();
        }
        
    }

    void Update()
    {
        if (_movment_alt.IsMoving() && _movment_alt.IsGroundedDelay())
        {
            PlayRun();
        }
        else if (_movment_alt.IsJumping())
        {
            PlayJump();
        }
        else
        {
            _sourceRun.Stop();
        }
    }
}
