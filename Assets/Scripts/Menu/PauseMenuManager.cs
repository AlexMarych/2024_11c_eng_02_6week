using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseView;
    [SerializeField] private GameObject _approvalView;
    private GameObject _cannon;
    private bool isPaused;

    private void Awake()
    {
        _cannon = GameObject.FindGameObjectWithTag("Weapon");
        _pauseView.SetActive(false);
        _approvalView.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !IsPaused())
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape)) Resume();
    }

    public void Pause()
    {
        _cannon.SetActive(false);
        _pauseView.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        _cannon.SetActive(true);
        _pauseView.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void MainMenu()
    {
        _pauseView.SetActive(false);
        _approvalView.SetActive(true);
    }

    public void BackToPause()
    {
        _approvalView.SetActive(false);
        _pauseView.SetActive(true);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("ManuScene");
        Time.timeScale = 1.0f;
    }

    public bool IsPaused()
    {
       return isPaused; 
    }
}
