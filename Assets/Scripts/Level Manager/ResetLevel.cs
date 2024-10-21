using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{
    private bool InputReset;
    private GameObject _player;
    private GameObject[] _spawners;
    [SerializeField] string CurrentScreenName;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _spawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ResetScreen();
    }

    void ResetScreen()
    {
        Destroy(_player);
        Debug.Log("Destroyed player");
        GameObject activeSpawner = null;
        for (int i = 0; i < _spawners.Length; i++) {
            GameObject iterSpawner = _spawners[i];
            if (iterSpawner.name == CurrentScreenName + "Spawner")
            {
                Debug.Log("Found spawner");
                activeSpawner = iterSpawner;
            }
        }
        if (activeSpawner != null) {
            Spawner spawnScript = (Spawner) activeSpawner.GetComponent(typeof(Spawner));
            _player = spawnScript.Trigger();
        }
    }
}
