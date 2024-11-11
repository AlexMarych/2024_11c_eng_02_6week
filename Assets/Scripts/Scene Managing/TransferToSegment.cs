using UnityEngine;

public class TransferToSegment : MonoBehaviour
{
    [SerializeField] private string _segmentName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gameObject = other.gameObject;
        if (!gameObject.CompareTag("Player")) 
        {
            return;
        }

        GameObject anchor = GameObject.Find(_segmentName + "CameraAnchor");
        if (anchor != null && Camera.main.TryGetComponent<CameraMovement>(out var movement))
        {
            movement.MoveToTransform = anchor.transform;
        }
        
        GameObject segmentManager = GameObject.FindGameObjectWithTag("SegmentManager");
        if (segmentManager == null)
        {
            return;
        }
        
        CurrentSegmentTracking currentSegmentTracking = segmentManager.GetComponent<CurrentSegmentTracking>();
        currentSegmentTracking.CurrentSegmentName = _segmentName;
            
        GameObject scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
        if (scoreManager == null)
        {
            return;
        }
        
        TrackScore trackScore = scoreManager.GetComponent<TrackScore>();
        if (trackScore.GoldCoinCount > trackScore.LastGoldCoinCount) 
        {
            SpawnerDisabler spawnerDisabler = segmentManager.GetComponent<SpawnerDisabler>();
            spawnerDisabler.DisableCurrentSegmentGoldCoinSpawner();
            trackScore.SaveGoldCoinCount();
        }
    }
}
