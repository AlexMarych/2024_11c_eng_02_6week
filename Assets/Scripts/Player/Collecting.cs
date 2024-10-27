using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gameObject = other.gameObject;
        if (gameObject.CompareTag("Collectable"))
            gameObject.GetComponent<Collectable>().Collect();
    }
}
