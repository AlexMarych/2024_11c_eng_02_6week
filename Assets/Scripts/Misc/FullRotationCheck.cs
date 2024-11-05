using UnityEngine;

public class FullRotationCheck : MonoBehaviour
{
    private float _angle;
    private float _lastAngle;
    private float _accumulatedAngle;
    private bool _isActive;
    [SerializeField] private float _minimumRequiredAngle;
    public bool Rotated;

    private float cachedRotationZ;
    private bool hasFired = false;


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

        if (!hasFired) return;
        Debug.Log(Mathf.Abs(cachedRotationZ - transform.rotation.z));
        if (Mathf.Abs(cachedRotationZ - transform.rotation.z) >= _minimumRequiredAngle)
        {
            Rotated = true;
            hasFired = false;
        }
    }

    public void StartNewCheckFromDirection(Vector3 direction)
    {
        _lastAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _accumulatedAngle = 0;
        _isActive = true;
        cachedRotationZ = transform.rotation.z;
        hasFired = true;
        Rotated = false;
    }
}
