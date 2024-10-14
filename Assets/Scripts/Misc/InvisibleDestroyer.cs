using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleDestroyer : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
