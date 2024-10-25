using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    void Update()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, rotationZ);
    }
}
