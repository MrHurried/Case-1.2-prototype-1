using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] Transform posA;
    [SerializeField] Transform posB;
    [SerializeField] bool movingTowardsA = true;
    [SerializeField] float durationFromAToB;
    [SerializeField] float timer = 0f;
    [SerializeField] AnimationCurve curve;
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(movingTowardsA)
        {
            transform.position = Vector3.Lerp( posB.position, posA.position,curve.Evaluate(timer/durationFromAToB));
        }
        if (movingTowardsA == false)
        {
            transform.position = Vector3.Lerp( posA.position, posB.position, curve.Evaluate(timer / durationFromAToB));
        }
        if(posA.position == transform.position)
        {
            movingTowardsA = false;
            timer = 0f;
        }
        if(posB.position == transform.position)
        {
            movingTowardsA=true;
            timer = 0f;
        }
    }
}
