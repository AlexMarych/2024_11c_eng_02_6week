using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MousePositionGrabber))]
public class Shooting : MonoBehaviour
{
    private MousePositionGrabber _mousePositionGrabber;
    private ReloadOnStanding _loadOnStanding;
    private bool _canFire;
    private float _lastFire;
    [SerializeField] private Transform _projectileOrigin;
    [SerializeField] private GameObject Projectile;
    [SerializeField] private float FireCooldown;
    [SerializeField] private float Force;


    void Start()
    {
        _loadOnStanding = GetComponent<ReloadOnStanding>();
        _mousePositionGrabber = GetComponent<MousePositionGrabber>();
    }

    void Update()
    {
        if(_loadOnStanding.getLoaded()) this.GetComponent<SpriteRenderer>().color = Color.red;
        else this.GetComponent<SpriteRenderer>().color = Color.white;

        if (!_canFire)
        {
            _canFire = _lastFire + FireCooldown <= Time.time;
        }
        else if (Input.GetMouseButton(0) && _loadOnStanding.getLoaded())
        {
            _canFire = false;
            _loadOnStanding.setLoaded();
            _lastFire = Time.time;
            GameObject createdProjectile = Instantiate(Projectile, _projectileOrigin.position, Quaternion.identity);
            Vector3 direction = _mousePositionGrabber.Position - transform.position;
            createdProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y).normalized * Force;
        }
    }

    

}
