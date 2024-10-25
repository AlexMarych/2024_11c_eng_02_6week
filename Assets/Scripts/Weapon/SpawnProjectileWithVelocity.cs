using UnityEngine;

public class SpawnProjectileWithVelocity : MonoBehaviour
{
    [SerializeField] private Transform _projectileOrigin;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private float Force;

    public void Spawn(Vector3 direction)
    {
        GameObject projectile = Instantiate(_projectile, _projectileOrigin.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = (Vector2) direction.normalized * Force;
    }
}
