using UnityEngine;

public class Collectable : MonoBehaviour
{
    public enum Type
    {
        Silver = 10,
        Gold = 50
    }
    [SerializeField] private Type type;

    //Increments the coin count tracked in the TrackScore script of our ScoreManager object in the scene
    public void Collect() 
    {
        GameObject scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
        if (scoreManager != null)
            scoreManager.GetComponent<TrackScore>().IncrementCoinCount(type);
        Destroy(gameObject);
    }
}
