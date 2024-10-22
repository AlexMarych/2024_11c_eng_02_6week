using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float radius = 1;
    [SerializeField] private float force = 1;
    public LayerMask playerLayer;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void HandleDestruction()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, radius, playerLayer);

        foreach (Collider2D collider in collider2Ds)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.AddForce((collider.transform.position - transform.position).normalized * force * 10);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        HandleDestruction();
        Destroy(gameObject);
    }
}
