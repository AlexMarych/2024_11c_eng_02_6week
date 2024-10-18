using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicMovement : MonoBehaviour
{
    //Move using Rigidbody2d
    private Rigidbody2D _rb;
    private float InputHorizontal;
    [SerializeField] public float MoveSpeed = 3f;
    Vector2 _currentVelocity;

    [SerializeField] private float _coyoteTime = 0.2f;
    private float _coyoteTimeCounter;

    [SerializeField] private float _jumpBufferTime = 0.2f;
    private float _jumpBufferCounter;

    private bool _isGrounded;
    [SerializeField] private float _rayLength = 1.1f;

    private bool _performJump;
    [SerializeField] private float _jumpForce;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
 

    // Update is called once per frame
    void Update()
    {
        InputHorizontal = Input.GetAxisRaw("Horizontal");
        _currentVelocity = new Vector2(InputHorizontal * MoveSpeed, 0f);

        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _rayLength);

        if (_isGrounded) _coyoteTimeCounter = _coyoteTime;
        else _coyoteTimeCounter -= Time.deltaTime;

        if (Input.GetButtonDown("Jump")) _jumpBufferCounter = _jumpBufferTime;
        else _jumpBufferCounter -= Time.deltaTime;

        if (_jumpBufferCounter > 0 && _coyoteTimeCounter > 0f)
        {
            _rb.velocity = new Vector2(_currentVelocity.x, _jumpForce);
            _performJump = true;
            _coyoteTimeCounter = 0f;

        }

    }
    private void FixedUpdate()
    {
        MoveAxisX();
        Jump();
    }

    private void MoveAxisX()
    {
        if (InputHorizontal != 0)
        {
            _rb.velocity = _currentVelocity;
        }
        else
        {
            _currentVelocity = Vector2.zero;
            _rb.velocity = _currentVelocity;
        }
    }

    private void Jump()
    {
        if (_performJump)
        {
            _performJump = false;
            _isGrounded = false;
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        _isGrounded = false;
    }

}
