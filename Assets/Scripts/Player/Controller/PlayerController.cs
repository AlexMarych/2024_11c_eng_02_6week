using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D col;
    private FrameInput frameInput;

    [Range(0.01f, 0.99f)]
    public float HorizontalDeadZoneThreshold = 0.1f; //Minimum input required before recognized;
    [Range(0f, 0.5f)]
    public float GrounderDistance = 0.05f; //Distance for grounded check raycast;
    public LayerMask PlayerLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        
    }

    private void Update()
    {

        GatherInput();
    }

    private void GatherInput()
    {
        frameInput = new FrameInput()
        {
            JumpDown = Input.GetButtonDown("Jump"),
            JumpHeld = Input.GetButton("Jump"),
            Move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))
        };

        frameInput.Move.x = Mathf.Abs(frameInput.Move.x) < HorizontalDeadZoneThreshold ? 0 : Mathf.Sign(frameInput.Move.x);
    }

    private void FixedUpdate()
    {
        GroundCheck();

        // HandleJump();
        // HandleDirection();
        // HandleGravity();
        //
        // ApplyMovement();
    }

    #region GroundCheck

    private float frameNotGrounded = float.MinValue;
    private bool grounded;

    private void GroundCheck()
    {
        Physics2D.queriesStartInColliders = false;

        bool groundHit = Physics2D.CapsuleCast(col.bounds.center, col.size, col.direction, 0, Vector2.down, GrounderDistance, PlayerLayer);    
    }
    
    #endregion


    private struct FrameInput
    {
        public bool JumpDown;
        public bool JumpHeld;
        public Vector2 Move;
    }
}
