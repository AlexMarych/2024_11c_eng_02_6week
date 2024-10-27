using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int _value;
    private GameObject _scoreManager;
    void Start()
    {
        _scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
    }

    public void Collect() 
    {
        if (_scoreManager != null)
            _scoreManager.GetComponent<TrackScore>().AddScore(_value);
        Destroy(gameObject);
    }
}
