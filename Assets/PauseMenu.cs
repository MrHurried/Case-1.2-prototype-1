using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    bool isPaused;
    [SerializeField] GameObject PauseMenuUI;

    Keyboard kb;

    private void Start()
    {
        kb = Keyboard.current;
    }

    private void Update()
    {
        if(kb.escapeKey.wasPressedThisFrame)
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

}
