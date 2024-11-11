using System;
using UnityEngine;
using UnityEngine.UI;

public class FullRotationCheck : MonoBehaviour
{
    private float _angle;
    private float _lastAngle;
    private float _accumulatedAngle;
    private bool _isActive;
    [SerializeField] private float _minimumRequiredAngle;
    public bool Rotated;

    [SerializeField] private Slider Slider;
    [SerializeField] private Image Image;

    private void Start()
    {
        if (Slider)
        {
            Slider.value = 0f;
        }
    }

    void Update()
    {
        if (_isActive)
        {
            Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            _angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            float angleDelta = _lastAngle - _angle;
            if (angleDelta >= -30f && angleDelta <= 30f)
                _accumulatedAngle += _lastAngle - _angle;
            _lastAngle = _angle;
            if (_accumulatedAngle >= _minimumRequiredAngle || _accumulatedAngle <= -_minimumRequiredAngle)
            {
                Rotated = true;
                _isActive = false;
            }
        }

        if (Slider)
        {
            Slider.value = 1f - Math.Abs(_accumulatedAngle / _minimumRequiredAngle);
        }
    }

    public void StartNewCheckFromDirection(Vector3 direction)
    {
        _lastAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _accumulatedAngle = 0;
        _isActive = true;
        Rotated = false;
        
        if (Image)
        {
            Image.fillOrigin = GetFillOriginFromAngle(_lastAngle);
        }
    }
    
    private int GetFillOriginFromAngle(float angle)
    {
        return angle switch
        {
            >= 45 and <= 135 => 2,
            < -135 or > 135 => 3,
            >= -135 and < -45 => 0,
            _ => 1
        };
    }
}
