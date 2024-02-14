using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("reload", 2f);
    }

    private void reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
