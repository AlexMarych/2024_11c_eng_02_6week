using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadOnStanding : MonoBehaviour
{
    private GroundCheck _groundCheck;

    [SerializeField] private float reloadTime = 2f;
    private float reloadCounter;

    public bool Loaded { get; set; }

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
        if (_groundCheck.Grounded && !Loaded)
        {
            if (reloadCounter < reloadTime)
            {
                reloadCounter += Time.deltaTime;
            }
            else
            {
                Loaded = true;

            }
        }
        else reloadCounter = 0f;
    }
}
