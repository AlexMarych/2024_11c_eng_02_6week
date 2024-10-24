using UnityEngine;

public class FlipSpriteOnRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    void Update()
    {
        _spriteRenderer.flipY = transform.localRotation.eulerAngles.z > 90 && transform.localRotation.eulerAngles.z < 270;
    }
}
