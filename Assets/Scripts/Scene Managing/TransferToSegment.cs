using UnityEngine;

public class TransferToSegment : MonoBehaviour
{
    [SerializeField] private string _segmentName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gameObject = other.gameObject;
        if (gameObject.CompareTag("Player")) 
        {
            GameObject segmentManager = GameObject.FindGameObjectWithTag("SegmentManager");
            if (segmentManager != null) 
            {
                GameObject scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
                if (scoreManager != null) 
                {
                    TrackScore trackScore = scoreManager.GetComponent<TrackScore>();
                    if (trackScore.GoldCoinCount > trackScore.LastGoldCoinCount) 
                    {
                        SpawnerDisabler spawnerDisabler = segmentManager.GetComponent<SpawnerDisabler>();
                        spawnerDisabler.DisableCurrentSegmentGoldCoinSpawner();
                        trackScore.SaveGoldCoinCount();
                    }
                }
                CurrentSegmentTracking currentSegmentTracking = segmentManager.GetComponent<CurrentSegmentTracking>();
                currentSegmentTracking.CurrentSegmentName = _segmentName;
            }
        }
    }
}
