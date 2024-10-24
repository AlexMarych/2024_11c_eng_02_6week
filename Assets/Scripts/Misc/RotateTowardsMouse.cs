using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    void Update()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
