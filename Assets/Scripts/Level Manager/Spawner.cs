using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject entity;

    public GameObject Trigger()
    {
        return Instantiate(entity, transform);
    }
}
