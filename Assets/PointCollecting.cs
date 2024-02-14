using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class PointCollecting : MonoBehaviour
{
    private int collectedPoints = 0;
    private PointText pointTextScript;
    private LoadNextScene nextSceneLoader;
    private int pointsInCurrentRoom;

    private void Start()
    {
        GameObject[] points = GameObject.FindGameObjectsWithTag("Point");
        pointsInCurrentRoom = points.Length;
        pointTextScript = GameObject.FindWithTag("PointText").GetComponent<PointText>();
        nextSceneLoader = GameObject.FindWithTag("SceneMngr").GetComponent<LoadNextScene>();
        pointTextScript.Refresh(0, pointsInCurrentRoom);
    }

    public void CollectPoints(int pointamount)
    {
        collectedPoints += pointamount;
        pointTextScript.Refresh(collectedPoints, pointsInCurrentRoom);
        if(collectedPoints >= pointsInCurrentRoom) nextSceneLoader.Go();
    }
}
