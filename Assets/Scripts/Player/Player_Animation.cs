using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private float InputHorizontal;
    private PlayerController _check;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _check = GetComponent<PlayerController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        InputHorizontal = Input.GetAxisRaw("Horizontal");
        Flip();
        RunAnimation();
        JumpAnimation();
        GroundedAnimation();
    }

    void Flip()
    {
        if (InputHorizontal > 0) _spriteRenderer.flipX = false;
        else if(InputHorizontal < 0) _spriteRenderer.flipX = true;
    }

    void RunAnimation()
    {
            _animator.SetFloat("XInputAbs", Math.Abs(InputHorizontal));
    }

    void JumpAnimation()
    { 
            _animator.SetFloat("YVelocityAbs", _rb.velocity.y);
    }

    void GroundedAnimation()
    {
        _animator.SetBool("IsGrounded", _check.IsGrounded());
    }
}
