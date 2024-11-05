using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsAnimation : MonoBehaviour
{
    public float scrollSpeed = 2f; // Speed of movement

    private float objectWidth;     // Width of the object
    private Camera mainCamera;     // Main camera reference
    private Vector3 screenBounds;  // World point of screen edges

    void Start()
    {
        // Get the object width (assuming it has a SpriteRenderer or Renderer)
        objectWidth = GetComponent<SpriteRenderer>().bounds.size.x;

        // Reference to the main camera
        mainCamera = Camera.main;

        // Calculate the screen bounds in world units
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    void Update()
    {
        // Move the object to the left every frame
        transform.Translate(Vector3.left * (scrollSpeed * Time.deltaTime));

        // Check if the object has moved completely off the left side of the screen
        if (transform.position.x < -screenBounds.x - objectWidth / 2)
        {
            // Teleport the object to the right side, just off-screen
            Vector3 newPosition = new Vector3(screenBounds.x + objectWidth / 2, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
