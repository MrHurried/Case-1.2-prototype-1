using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPath : MonoBehaviour
{
    List<Transform> points;
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

        lr.positionCount = points.Count;

        for (int i = 0; i < points.Count; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
    }
}
