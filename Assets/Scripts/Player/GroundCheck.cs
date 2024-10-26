using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public Vector2 BoxSize;
    public float YOffset;
    public LayerMask GroundLayer;
    public bool Grounded { get; private set; }


    private void FixedUpdate()
    {
        Grounded = Physics2D.BoxCast(transform.position - transform.up * YOffset, BoxSize, 0, Vector2.down, 0, GroundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * YOffset, BoxSize);
    }

    public bool IsGrounded()
    { 
        return Grounded; 
    }
}
