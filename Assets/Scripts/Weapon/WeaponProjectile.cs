using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    [Header("Rocket jump Settings")]
    public float explosionRadius = 5f;
    public float explosionForce = 50f;
    
    [Header("Misc")]
    [SerializeField] private float radius = 1;
    [SerializeField] private float force = 50;
    public LayerMask PlayerLayer;
    public GameObject Explosion;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collider2Ds = Physics2D.OverlapCircleAll(transform.position, radius, PlayerLayer);
        foreach (Collider2D collider in collider2Ds)
        {
            PlayerController player = collider.GetComponent<PlayerController>();
            
            if (player != null)
            {
                player.ApplyExplosionForce(transform.position, explosionRadius, explosionForce);
                
            }
        }

        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere((Vector2)transform.position, radius);
    }
}
