using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    private PauseMenuManager m_Manager;

    private void Awake()
    {
        m_Manager = PauseMenu.GetComponent<PauseMenuManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !m_Manager.IsPaused())
        {
            m_Manager.Pause();
        }
        else
        {
            m_Manager.Resume();
        }
    }
}
