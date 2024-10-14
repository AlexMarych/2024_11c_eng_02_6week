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

    private bool _performJump;
    private bool _isGrounded;
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

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _performJump = true;
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
            _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }
}
