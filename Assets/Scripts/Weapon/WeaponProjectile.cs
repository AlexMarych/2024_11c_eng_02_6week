using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    [SerializeField] private float radius = 1;
    [SerializeField] private float force = 50;
    public LayerMask PlayerLayer;
    public GameObject Explosion;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collider2Ds = Physics2D.OverlapCircleAll(transform.position, radius, PlayerLayer);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.TryGetComponent<PlayerController>(out var pc))
            {
                //rb.AddForce(10f * force * (collider.transform.position - transform.position).normalized, ForceMode2D.Impulse);   
                Vector2 direction = new Vector2(pc.transform.position.x - transform.position.x, pc.transform.position.y - transform.position.y);
                
                pc.SetFrameVelocity(direction.normalized * force);
                
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
