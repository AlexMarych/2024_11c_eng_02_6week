using UnityEngine;

public class FullRotationCheck : MonoBehaviour
{
    private float _angle;
    private float _lastAngle;
    private float _accumulatedAngle;
    private bool _isActive;
    [SerializeField] private float _minimumRequiredAngle;
    public bool Rotated;


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
    }

    public void StartNewCheckFromDirection(Vector3 direction)
    {
        _lastAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _accumulatedAngle = 0;
        _isActive = true;
        Rotated = false;
    }
}
