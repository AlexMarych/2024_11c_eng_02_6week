using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSFX : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    private Dialogue crab;

    private void Awake()
    {
        crab = FindObjectOfType<Dialogue>();
    }

    void Update()
    {
        if(crab.IsSpeaking() && !_source.isPlaying) _source.Play();
        else if (!crab.IsSpeaking()) _source.Stop();
    }
}
