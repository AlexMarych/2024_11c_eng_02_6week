using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public Transform MoveToTransform;
    void Start()
    {
		MoveToTransform = transform;
    }

    void Update()
    {
		transform.position = Vector3.Lerp(
			transform.position, 
			new Vector3(MoveToTransform.position.x, MoveToTransform.position.y, transform.position.z),
			0.025f
		);
    }
}
