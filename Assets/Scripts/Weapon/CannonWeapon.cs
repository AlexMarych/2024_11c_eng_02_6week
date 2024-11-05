using UnityEngine;

[RequireComponent(typeof(SpawnProjectileWithVelocity))]
public class CannonWeapon : MonoBehaviour
{
    private SpawnProjectileWithVelocity _spawnProjectileWithVelocity;
    private FullRotationCheck _fullRotationCheck;
    private CannonSFXController _cannonSFXController;

    void Start()
    {
        _cannonSFXController = GetComponent<CannonSFXController>();
        _spawnProjectileWithVelocity = GetComponent<SpawnProjectileWithVelocity>();
        _fullRotationCheck = GetComponentInParent<FullRotationCheck>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        }
    }

    void Shoot(Vector3 direction)
    {
        if (!_cannonSFXController || !_spawnProjectileWithVelocity) return;

        if (_fullRotationCheck.Rotated)
        {
            _fullRotationCheck.StartNewCheckFromDirection(direction);
            _spawnProjectileWithVelocity.Spawn(direction);
            _cannonSFXController.PlayFire();
        }
    }
}
