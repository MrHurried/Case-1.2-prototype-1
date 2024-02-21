using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CuberAttack : MonoBehaviour
{
    [SerializeField] private bool isMoving;
    [SerializeField] private bool shouldMoveTowardsB = true;
    private Vector3 posB;
    private Vector3 posA;

    private Vector3[] bPositions = new Vector3[4];

    [SerializeField] AnimationCurve curveTo;
    [SerializeField] AnimationCurve curveBack;

    [SerializeField] float timer = 0f;
    [SerializeField] float speed;

    private Vector3 rayUpOrigin;
    private Vector3 rayDownOrigin;
    private Vector3 rayLeftOrigin;
    private Vector3 rayRightOrigin;

    private Renderer rend;

    private float distanceToTravelUpwards;
    private float distanceToTravelDownwards;
    private float distanceToTravelRightwards;
    private float distanceToTravelLeftwards;

    private float distanceToTravel;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        posA = transform.position;

        rayUpOrigin = transform.position + new Vector3(0f, rend.bounds.size.y / 1.8f, 0f);
        rayDownOrigin = transform.position - new Vector3(0f, rend.bounds.size.y / 1.8f, 0f);
        rayRightOrigin = transform.position + new Vector3(rend.bounds.size.x / 1.8f, 0f, 0f);
        rayLeftOrigin = transform.position - new Vector3(rend.bounds.size.x / 1.8f, 0f, 0f);

        AssignBPositions();

        distanceToTravelUpwards = Vector3.Distance(bPositions[0], posA);
        distanceToTravelDownwards = Vector3.Distance(bPositions[1], posA);
        distanceToTravelLeftwards = Vector3.Distance(bPositions[2], posA);
        distanceToTravelRightwards = Vector3.Distance(bPositions[3], posA);
    }

    void DrawDebugRays()
    {
        Ray ray = new Ray(rayUpOrigin, Vector3.up * 9999f);
        Physics.Raycast(ray, out RaycastHit hitInfoUp, 9999f);
        Debug.DrawRay(ray.origin, ray.direction * 9999f, Color.white);

        ray = new Ray(rayDownOrigin, Vector3.up * -9999f);
        Physics.Raycast(ray, out RaycastHit hitInfoDown, 9999f);
        Debug.DrawRay(ray.origin, ray.direction * 9999f, Color.white);

        ray = new Ray(rayLeftOrigin, Vector3.right * -9999f);
        Physics.Raycast(ray, out RaycastHit hitInfoLeft);
        Debug.DrawRay(ray.origin, ray.direction * 9999f, Color.white);

        ray = new Ray(rayRightOrigin, Vector3.right * 9999f);
        Physics.Raycast(ray, out RaycastHit hitInfoRight, 9999f);
        Debug.DrawRay(ray.origin, ray.direction * 9999f);
    }

    private void AssignBPositions()
    {

        Ray ray = new Ray(rayUpOrigin, Vector3.up * 9999f);
        Physics.Raycast(ray, out RaycastHit hitInfoUp, 9999f);
        Debug.DrawRay(ray.origin, ray.direction * 9999f, Color.white);

        ray = new Ray(rayDownOrigin, Vector3.up * -9999f);
        Physics.Raycast(ray, out RaycastHit hitInfoDown, 9999f);
        Debug.DrawRay(ray.origin, ray.direction * 9999f, Color.white);

        ray = new Ray(rayLeftOrigin, Vector3.right * -9999f);
        Physics.Raycast(ray, out RaycastHit hitInfoLeft);
        Debug.DrawRay(ray.origin, ray.direction * 9999f, Color.white);

        ray = new Ray(rayRightOrigin, Vector3.right * 9999f);
        Physics.Raycast(ray, out RaycastHit hitInfoRight, 9999f);
        Debug.DrawRay(ray.origin, ray.direction * 9999f);

        Vector3 upBPos = hitInfoUp.point - new Vector3(0f, rend.bounds.size.y / 1.8f, 0f);
        Vector3 downBPos = hitInfoDown.point + new Vector3(0f, rend.bounds.size.y / 1.8f, 0f);
        Vector3 leftBPos = hitInfoLeft.point + new Vector3(rend.bounds.size.x / 1.8f, 0f, 0f);
        Vector3 rightBPos = hitInfoRight.point - new Vector3(rend.bounds.size.x / 1.8f, 0f, 0f);

        bPositions[0] = upBPos;
        bPositions[1] = downBPos;
        bPositions[2] = leftBPos;
        bPositions[3] = rightBPos;
    }

    // Update is called once per frame
    void Update()
    {

        DrawDebugRays();

        if (!isMoving)
            CheckIfPlayerIsInVision();

        else
        {
            Move();
        }
    }

    private void CheckIfPlayerIsInVision()
    {

        Ray ray = new Ray(rayUpOrigin, Vector3.up * 9999f);
        Physics.Raycast(ray, out RaycastHit hitInfoUp, 9999f);
        //Debug.DrawRay(ray.origin, ray.direction * 9999f, Color.green);


        ray = new Ray(rayDownOrigin, Vector3.up * -9999f);
        Physics.Raycast(ray, out RaycastHit hitInfoDown, 9999f);
        //Debug.DrawRay(ray.origin, ray.direction * 9999f, Color.green);

        ray = new Ray(rayLeftOrigin, Vector3.right * -9999f);
        Physics.Raycast(ray, out RaycastHit hitInfoLeft);
        //Debug.DrawRay(ray.origin, ray.direction * 9999f, Color.green);

        ray = new Ray(rayRightOrigin, Vector3.right * 9999f);
        Physics.Raycast(ray, out RaycastHit hitInfoRight, 9999f);
        //Debug.DrawRay(ray.origin, ray.direction * 9999f, Color.green);


        //Physics.Raycast(transform.position, transform.forward * -1, out RaycastHit hitInfoDown, 9999f, LayerMask.GetMask("Moveable"));

        if (hitInfoUp.collider != null && hitInfoUp.collider.gameObject.CompareTag("Player"))
        {
            distanceToTravel = distanceToTravelUpwards;
            posB = bPositions[0];
            isMoving = true;
            Debug.Log("cuber started moving up");
        }
        if (hitInfoDown.collider != null && hitInfoDown.collider.gameObject.CompareTag("Player"))
        {
            distanceToTravel = distanceToTravelDownwards;
            posB = bPositions[1];
            isMoving = true;
            Debug.Log("cuber started moving down");
        }
        if (hitInfoLeft.collider != null && hitInfoLeft.collider.gameObject.CompareTag("Player"))
        {
            distanceToTravel = distanceToTravelLeftwards;
            posB = bPositions[2];
            isMoving = true;
            Debug.Log("cuber started moving left");
        }
        if (hitInfoRight.collider != null && hitInfoRight.collider.gameObject.CompareTag("Player"))
        {
            distanceToTravel = distanceToTravelRightwards;
            posB = bPositions[3];
            isMoving = true;
            Debug.Log("cuber started moving right");
        }

    }

    private void Move()
    {
        timer += Time.deltaTime;
        if (shouldMoveTowardsB)
        {
            transform.position = Vector3.MoveTowards(transform.position, posB, curveTo.Evaluate(timer) * speed * Time.deltaTime);

            float distanceBetweenCubeAndPointB = Vector3.Distance(transform.position, posB);

            if (distanceBetweenCubeAndPointB < .01f)
            {
                transform.position = posB;
                shouldMoveTowardsB = false;
                timer = 0f;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, posA, curveBack.Evaluate(timer) * speed * Time.deltaTime);

            float distanceBetweenCubeAndPointA = Vector3.Distance(transform.position, posA);

            if (distanceBetweenCubeAndPointA < .01f)
            {
                transform.position = posA;
                isMoving = false;
                shouldMoveTowardsB = true;
                timer = 0f;
            }
        }
        
    }
}