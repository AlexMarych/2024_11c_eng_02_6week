using UnityEngine;

public class ResetTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gameObject = other.gameObject;
        if (gameObject.CompareTag("Player"))
        {
            GameObject segmentManager = GameObject.FindGameObjectWithTag("SegmentManager");
            if (segmentManager != null) 
            {
                ResetSegment resetSegment = segmentManager.GetComponent<ResetSegment>();
                resetSegment.Reset();
            }
        }
    }
}
