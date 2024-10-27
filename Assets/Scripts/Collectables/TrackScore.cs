using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackScore : MonoBehaviour
{
    public int Score;

    public void AddScore(int value)
    {
        Score += value;
    }
}
