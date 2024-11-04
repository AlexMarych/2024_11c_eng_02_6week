using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rb;
    private GroundCheck _groundCheck;


    [SerializeField] private float _jumpTime;
    [SerializeField] private float _jumpMuliplire = 1;

    bool isJumping;
    float jumpCounter;

    bool isGrounded;

    private PlayerSFXController _playerSFXController;

    [SerializeField] private float _coyoteTime = 0.2f;
    float coyoteCounter;

    [SerializeField] private float _fallMultiplier;
    Vector2 gravityVector;

    [SerializeField] private float _jumpForce;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _groundCheck = GetComponent<GroundCheck>();
        gravityVector = new Vector2(0, -Physics2D.gravity.y);
        _playerSFXController = GetComponent<PlayerSFXController>();
    }


    void Update()
    {

        if (_groundCheck.Grounded)
        {
            isGrounded = true;
            coyoteCounter = 0f;
        }
        else
        {
            coyoteCounter += Time.deltaTime;
            if (coyoteCounter > _coyoteTime)
            {
                isGrounded = false;
            }
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            isJumping = true;
            jumpCounter = 0;
            _playerSFXController.PlayJump();
        }

        if (_rb.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if (jumpCounter > _jumpTime) isJumping = false;

            float t = jumpCounter / _jumpTime;
            float currentJumpMultiplire = _jumpMuliplire;

            if (t > 0.5f) currentJumpMultiplire = _jumpMuliplire * (1 - t);


            _rb.velocity += gravityVector * currentJumpMultiplire * Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump")) isJumping = false;

        if (_rb.velocity.y < 0)
        {
            _rb.velocity -= gravityVector * _fallMultiplier * Time.deltaTime;
        }
    }

    public bool IsJumping()
    {
        return isJumping;
    }

}
