using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainView;
    [SerializeField] private GameObject _settingsView;
    [SerializeField] private GameObject _newGameView;
    
    private GameObject gofromView;
    private GameObject gotoView;

    private void Awake()
    {
        _mainView.SetActive(true);
        _settingsView.SetActive(false);
        _newGameView.SetActive(false);
    }

    public void NewGame()
    {
        _mainView.SetActive(false);
        _newGameView.SetActive(true);
    }

    //public void Back(string from, string to)
    //{
    //    gofromView = GameObject.Find(from);
    //    gotoView = GameObject.Find(to);
    //    gofromView.SetActive(false);
    //    gotoView.SetActive(true);
    //}

    public void GoBackFromNew()
    {
        _newGameView.SetActive(false);
        _mainView.SetActive(true);

    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void LoadNewGame(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

}
