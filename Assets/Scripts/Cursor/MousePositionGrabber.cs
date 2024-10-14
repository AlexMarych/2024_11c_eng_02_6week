using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionGrabber : MonoBehaviour
{
    private Camera _camera;
    public Vector3 Position;
    void Start()
    {
        _camera = Camera.main;
    }


    void Update()
    {
        Position = _camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
