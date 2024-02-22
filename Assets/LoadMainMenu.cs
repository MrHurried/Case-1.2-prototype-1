using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    [SerializeField] int MainMenuIndex;

    public void Go()
    {
        SceneManager.LoadScene(MainMenuIndex);
    }
}
