using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSFXController : MonoBehaviour
{
    public AudioSource CannonFire;

    public void PlayFire()
    {
        CannonFire.Play();
    }
}
