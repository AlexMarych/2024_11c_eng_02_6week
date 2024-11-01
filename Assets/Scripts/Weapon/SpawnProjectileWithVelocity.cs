using UnityEngine;

public class SpawnProjectileWithVelocity : MonoBehaviour
{
    [SerializeField] private Transform _projectileOrigin;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject _particles;
    [SerializeField] private float _force;

    public void Spawn(Vector3 direction)
    {
        var normalizedDirection = ((Vector2)direction).normalized;
        Instantiate(_particles, 
            _projectileOrigin.position, 
            Quaternion.AngleAxis(Mathf.Atan2(normalizedDirection.y, normalizedDirection.x) * Mathf.Rad2Deg, Vector3.forward));

        var projectile = Instantiate(_projectile, _projectileOrigin.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = normalizedDirection * _force;
    }
}
