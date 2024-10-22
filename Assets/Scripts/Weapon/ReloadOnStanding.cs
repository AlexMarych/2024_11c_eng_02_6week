using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadOnStanding : MonoBehaviour
{
    private GroundCheck _groundCheck;

    [SerializeField] private float reloadTime = 2f;
    private float reloadCounter;

    bool _isLoaded;

    void Start()
    {
        _groundCheck = GameObject.FindGameObjectWithTag("Player").GetComponent<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (_groundCheck.isGrounded() && !_isLoaded)
        {
            if (reloadCounter < reloadTime)
            {
                reloadCounter += Time.deltaTime;
            }
            else
            {
                _isLoaded = true;
                
            }
        }
        else reloadCounter = 0f; 
    }

    public bool getLoaded()
    {
        return _isLoaded;
    }

    public void setLoaded()
    {
        _isLoaded = false;
    }
}
