using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    private SceneLoadingAnimation animationScript;

    private void Start()
    {
        animationScript = GameObject.FindWithTag("SceneLoadingAnimation").GetComponent<SceneLoadingAnimation>();
    }

    public void Go()
    {
        animationScript.PLayShrinkAnimation();
        Invoke("Load", 1.5f); //animation lasts 1.5 seconds
    }

    public void Load()
    {
        Debug.Log("assigning target build index");
        
        Application.Quit();
    }
}
