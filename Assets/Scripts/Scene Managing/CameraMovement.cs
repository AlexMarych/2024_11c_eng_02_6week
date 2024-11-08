using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public Vector2 MoveToPosition;
    void Start()
    {
		MoveToPosition = transform.position;
    }

    void Update()
    {
		transform.position = Vector3.Lerp(
			transform.position, 
			new Vector3(MoveToPosition.x, MoveToPosition.y, transform.position.z),
			0.025f
		);
    }
}
