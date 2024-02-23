using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    bool isPaused;
    [SerializeField] GameObject PauseMenuUI;
    [SerializeField] ChangeCursorVisibility cursorScript;
    [SerializeField] EnlargeButtonTextWhenHoveringOver[] buttonSizeScripts;
    [SerializeField] ChangeTextColorOnButtonHover[] buttonColorScripts;

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
        foreach(var script in buttonSizeScripts)
        {
            script.ScaleButtonToNormalSize();
        }

        foreach (var script in buttonColorScripts)
        {
            script.ChangeToNormalColor();
        }

        cursorScript.Hide();
        PauseMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        cursorScript.Show();
        PauseMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

}
