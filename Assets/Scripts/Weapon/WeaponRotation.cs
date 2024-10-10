using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MousePositionGrabber))]
public class WeaponRotation : MonoBehaviour
{
    private MousePositionGrabber _mousePositionGrabber;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _mousePositionGrabber = GetComponent<MousePositionGrabber>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 rotation = _mousePositionGrabber.Position - transform.position;
        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        _spriteRenderer.flipY = transform.localRotation.eulerAngles.z > 90 && transform.localRotation.eulerAngles.z < 270;
    }
}
