using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Move using Rigidbody2d
    Rigidbody2D _rb;
    public float InputHorizontal;
    public float MoveSpeed = 3f;
    Vector2 _currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputHorizontal = Input.GetAxisRaw("Horizontal");
        _currentVelocity = new Vector2(InputHorizontal * MoveSpeed, 0f);
    }
    private void FixedUpdate()
    {
        MoveAxisX();        
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
}
