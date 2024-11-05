using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 3f;   // Speed of the platform movement
    public float leftBoundary = -3f;  // Left boundary position (local)
    public float rightBoundary = 3f;  // Right boundary position (local)

    private bool movingRight = true; // Private variable to track the platform's moving direction

    void Update()
    {
        // Platform movement logic (same as before)
        if (movingRight)
        {
            transform.Translate(Vector2.right * (moveSpeed * Time.deltaTime));
            if (transform.localPosition.x >= rightBoundary)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * (moveSpeed * Time.deltaTime));
            if (transform.localPosition.x <= leftBoundary)
            {
                movingRight = true;
            }
        }
    }

    // Detect if player is on the platform and parent/unparent the player accordingly
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Parent the player to the platform
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Unparent the player from the platform when they leave
            collision.gameObject.transform.SetParent(null);
        }
    }
}