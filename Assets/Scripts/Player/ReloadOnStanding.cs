using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReloadOnStanding : MonoBehaviour
{
    
    [SerializeField] private float _loadTime = 1f;
    private float _loadCounter;
    private bool _isGrounded;
    private bool _isLoaded;

    private Shooting shooting;

    [SerializeField] private float _rayLength = 1.1f;

    void Invoke()
    {
        shooting = GameObject.FindGameObjectWithTag("weapon").GetComponent<Shooting>();
    }

    void Update()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _rayLength);

        if (_isGrounded && !shooting.IsLoaded()) {
            if (_loadCounter > 0)
            {
                _loadCounter = -Time.deltaTime;
            }
            else
            {
                shooting.SetLoaded();
                _loadCounter = _loadTime;
            }
        }
    }

}
