using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnchor : MonoBehaviour
{

    private bool collided = false;
    private GameObject player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) 
        {
            return;
        }
        player = other.gameObject;
        collided = true;
    }

    private void Update()
    {
        if(collided && player)
            transform.position = player.transform.position;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        gameObject.SetActive(false);
        enabled = false;
    }
}
