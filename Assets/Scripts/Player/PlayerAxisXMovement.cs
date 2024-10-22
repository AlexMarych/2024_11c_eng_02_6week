using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxisXMovement : MonoBehaviour
{
    //Move using Rigidbody2d
    private Rigidbody2D _rb;
    private GroundCheck _groundCheck;
    private SpriteRenderer _spriteRenderer;
    private float InputHorizontal;
    [SerializeField] public float MoveSpeed = 3f;
    Vector2 _currentVelocity;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _groundCheck = GetComponent<GroundCheck>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
 

    // Update is called once per frame
    void Update()
    {
        InputHorizontal = Input.GetAxisRaw("Horizontal");
        _currentVelocity = new Vector2(InputHorizontal * MoveSpeed, 0f);

        if (InputHorizontal > 0)
        {
            _spriteRenderer.flipX = false;
        }

        if (InputHorizontal < 0)
        {
            _spriteRenderer.flipX = true;
        }

    }
    private void FixedUpdate()
    {
        MoveAxisX();
    }

    private void MoveAxisX()
    {
        if (InputHorizontal != 0)
        {
            _rb.velocity = new Vector2(InputHorizontal * MoveSpeed, _rb.velocity.y); 
        }
        else if (!_groundCheck.isGrounded())
        {

        }
        else
        {
            _rb.velocity = new Vector2(0f, _rb.velocity.y);
        }
    }
}
