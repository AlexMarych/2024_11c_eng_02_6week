using UnityEngine;

[RequireComponent (typeof(CurrentSegmentTracking))]
public class SpawnerDisabler : MonoBehaviour
{
    private CurrentSegmentTracking _currentSegmentTracking;

    void Start()
    {
        _currentSegmentTracking = GetComponent<CurrentSegmentTracking>();
    }

    public void DisableCurrentSegmentGoldCoinSpawner()
    {
        GameObject goldCoinSpawner = GameObject.Find(_currentSegmentTracking.CurrentSegmentName + "GoldCoinSpawner");
        if (goldCoinSpawner != null) 
        {
            PermanentCollectionTracking permanentCollectionTracking = goldCoinSpawner.GetComponent<PermanentCollectionTracking>();
            permanentCollectionTracking.IsPermanentlyCollected = true;
        }

    }
}
