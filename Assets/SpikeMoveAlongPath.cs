using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMoveAlongPath : MonoBehaviour
{
    public GameObject path;
    public SpikePath pathScript;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.parent.gameObject == path)
        {
            Debug.Log("entered checkpoint");

            pathScript.timer = 0f;

            pathScript.indexOfNoteToMoveTo++;
            pathScript.lastNodePassedIndex++;

            if (pathScript.indexOfNoteToMoveTo > pathScript.pathNodes.Count - 1)
                pathScript.indexOfNoteToMoveTo = 0;
            if (pathScript.lastNodePassedIndex > pathScript.pathNodes.Count - 1)
                pathScript.lastNodePassedIndex = 0;
        }
    }
}
