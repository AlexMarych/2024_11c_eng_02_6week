using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GoToNextScene : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject player;
    public GameObject end;
    
    void Start()
    {
        end = GameObject.FindGameObjectWithTag("end");
        director = GetComponent<PlayableDirector>();
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!director) return; 
        if(other.CompareTag("Player"))
        {
            end.SetActive(true);
            other.gameObject.SetActive(false);
            player.SetActive(true);
            director.Play();
            StartCoroutine(NextScene());
        }
    }
}
