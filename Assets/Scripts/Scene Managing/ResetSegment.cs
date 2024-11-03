using UnityEngine;

[RequireComponent (typeof(CurrentSegmentTracking))]
public class ResetSegment : MonoBehaviour
{
    private CurrentSegmentTracking _currentSegmentTracking;

    void Start()
    {
        _currentSegmentTracking = GetComponent<CurrentSegmentTracking>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Reset();
    }

    private void Reset()
    {
        ResetPlayer();
        ResetGoldCoin();
    }

    private void ResetPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            Destroy(player);
        GameObject playerSpawner = GameObject.Find(_currentSegmentTracking.CurrentSegmentName + "PlayerSpawner");
        if (playerSpawner != null) 
        {
            Spawner spawner = playerSpawner.GetComponent<Spawner>();
            spawner.Spawn();
        }
    }

    private void ResetGoldCoin()
    {
        GameObject goldCoinSpawner = GameObject.Find(_currentSegmentTracking.CurrentSegmentName + "GoldCoinSpawner");
        if (goldCoinSpawner != null) 
        {
            Transform spawnerTransform = goldCoinSpawner.transform;
            if (spawnerTransform.childCount > 0)
            {
                GameObject goldCoin = spawnerTransform.GetChild(0).gameObject;
                if (goldCoin != null)
                    Destroy(goldCoin);
            }
            PermanentCollectionTracking permanentCollectionTracking = goldCoinSpawner.GetComponent<PermanentCollectionTracking>();
            if (!permanentCollectionTracking.IsPermanentlyCollected)
            {
                Spawner spawner = goldCoinSpawner.GetComponent<Spawner>();
                spawner.Spawn();
            }
        }
        GameObject scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
        if (scoreManager != null) 
        {
            TrackScore trackScore = scoreManager.GetComponent<TrackScore>();
            trackScore.LoadLastGoldCoinCount();
        }
    }
}
