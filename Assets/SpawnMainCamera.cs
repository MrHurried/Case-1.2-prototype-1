using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMainCamera : MonoBehaviour
{
    [SerializeField] GameObject cameraPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (Camera.main == null)
        {
            Instantiate(cameraPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
