using UnityEngine;

public class Collectable : MonoBehaviour
{
    public enum Type
    {
        Silver = 10,
        Gold = 50
    }
    [SerializeField] Type type;
    private GameObject _scoreManager;
    void Start()
    {
        _scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
    }

    //Increments the coin count tracked in the TrackScore script of our ScoreManager object in the scene
    public void Collect() 
    {
        if (_scoreManager != null)
            _scoreManager.GetComponent<TrackScore>().IncrementCoinCount(type);
        Destroy(gameObject);
    }
}
