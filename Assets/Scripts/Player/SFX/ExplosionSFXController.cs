using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSFXController : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip Boom;

    public void PlayBoom()
    {
        Source.Play();
    }
}
