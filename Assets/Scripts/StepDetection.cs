using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class StepDetection : MonoBehaviour
{
    [SerializeField] GameObject particles;
	[SerializeField] float deactivatedTime = 2;

	private GameObject platformObject;

	private void Start() {
		platformObject = transform.childCount == 0 ? null : transform.GetChild(0).gameObject;
	}

    private IEnumerator Break()
    {
        // Shake:
        const float seconds = 0.5f;
        const int iterations = 4;
        for (var i = 0; i < iterations; i++)
        {
			var platformTransform = platformObject.transform;

            var previousPosition = platformTransform.position;
            platformTransform.position += (Vector3)Random.insideUnitCircle * ((i + 1) * 0.01f); 

            yield return new WaitForSeconds(seconds / iterations / 2f);
            
            platformTransform.position += Vector3.left; 
            platformTransform.position = previousPosition; 

            yield return new WaitForSeconds(seconds / iterations / 2f);
        }
        
        yield return new WaitForSeconds(0.15f);

        Instantiate(particles, transform.position, Quaternion.identity);

		platformObject.SetActive(false);
        yield return new WaitForSeconds(deactivatedTime);

		platformObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
		if (platformObject is not null && platformObject.activeSelf) StartCoroutine(Break());
    }
}
