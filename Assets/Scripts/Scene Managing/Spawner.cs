using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _object;

    public GameObject Spawn()
    {
        return Instantiate(_object, transform);
    }
}
