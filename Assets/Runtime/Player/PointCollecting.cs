using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class PointCollecting : MonoBehaviour
{
    private int collectedPoints = 0;
    [SerializeField] private PointText pointTextScript;
    private LoadNextScene nextSceneLoader;
    private int pointsInCurrentRoom = 0;

    private void Awake()
    {
        pointTextScript = GameObject.FindWithTag("PointText").GetComponent<PointText>();
    }

    private void Start()
    {
        GameObject[] points = GameObject.FindGameObjectsWithTag("Point");
        pointsInCurrentRoom = points.Length;
        nextSceneLoader = GameObject.FindWithTag("SceneMngr").GetComponent<LoadNextScene>();
        pointTextScript.Refresh(0, pointsInCurrentRoom);
    }

    public void CollectPoints(int pointamount = 0)
    {
        collectedPoints += pointamount;
        pointTextScript.Refresh(collectedPoints, pointsInCurrentRoom);
        if (collectedPoints >= pointsInCurrentRoom)
        {
            nextSceneLoader.Go();
        }
    }

}