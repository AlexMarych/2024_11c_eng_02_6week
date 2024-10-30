using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class StepDetection : MonoBehaviour
{
    [SerializeField] GameObject particles;
    private IEnumerator Break()
    {
        // Shake:
        const float seconds = 0.5f;
        const int iterations = 4;
        for (var i = 0; i < iterations; i++)
        {
            transform.parent.transform.position -= Vector3.up * (0.002f * (i + 1));
            
            var previousPosition = transform.parent.transform.position;
            transform.parent.position += (Vector3)Random.insideUnitCircle * ((i + 1) * 0.006f); 
            yield return new WaitForSeconds(seconds / iterations / 2f);
            
            transform.parent.transform.position += Vector3.left; 
            transform.parent.position = previousPosition; 
            yield return new WaitForSeconds(seconds / iterations / 2f);
        }
        
        yield return new WaitForSeconds(0.15f);

        Instantiate(particles, transform.parent.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(Break());
    }
}
