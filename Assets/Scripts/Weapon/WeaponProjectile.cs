using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    [SerializeField] private float radius = 1;
    [SerializeField] private float force = 1;
    public LayerMask PlayerLayer;
    public GameObject Explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collider2Ds = Physics2D.OverlapCircleAll(transform.position, radius, PlayerLayer);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.TryGetComponent<Rigidbody2D>(out var rb))
            {
                rb.AddForce(10f * force * (collider.transform.position - transform.position).normalized, ForceMode2D.Impulse);
            }
        }

        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
