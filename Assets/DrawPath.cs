using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPath : MonoBehaviour
{
    List<Transform> points = new List<Transform>();
    LineRenderer lr;
    void Start()
    {
        lr = GetComponent<LineRenderer>();

        DrawLines();
    }

    private void DrawLines()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            points.Add(transform.GetChild(i).transform);
        }

        lr.positionCount = points.Count + 1;

        for (int i = 0; i < points.Count; i++)
        {
            lr.SetPosition(i, points[i].position);
        }

        lr.SetPosition(points.Count, points[0].position);
    }
}
