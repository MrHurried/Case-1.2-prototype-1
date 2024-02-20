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
    private Vector3 posB;
    private Vector3 posA;

    private Vector3[] bPositions = new Vector3[4];

    [SerializeField] AnimationCurve curve;

    [SerializeField] float timer = 0f;
    [SerializeField] float durationToAndBack;

    private Vector3 rayUpOrigin;
    private Vector3 rayDownOrigin;
    private Vector3 rayLeftOrigin;
    private Vector3 rayRightOrigin;

    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        posA = transform.position;

        AssignBPositions();

        rayUpOrigin = transform.position + new Vector3(0f, 3f, 0f);
        rayDownOrigin = transform.position - new Vector3(0f, 3f, 0f);
        rayRightOrigin = transform.position + new Vector3(3f, 0f, 0f);    
        rayLeftOrigin = transform.position - new Vector3(3f, 0f, 0f);
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

        Vector3 upBPos = hitInfoUp.point;//- new Vector3(0f, rend.bounds.size.y / 2f, 0f);
        Vector3 downBPos = hitInfoDown.point;//+ new Vector3(0f, rend.bounds.size.y / 2f, 0f);
        Vector3 leftBPos = hitInfoLeft.point;//+ new Vector3(rend.bounds.size.x / 2f, 0f, 0f);
        Vector3 rightBPos = hitInfoRight.point;//- new Vector3(rend.bounds.size.x / 2f, 0f, 0f);

        if (upBPos != null)
            bPositions[0] = upBPos;
        if (downBPos != null)
            bPositions[1] = downBPos;
        if (leftBPos != null)
            bPositions[2] = leftBPos;
        if (rightBPos != null)
            bPositions[3] = rightBPos;
    }

    // Update is called once per frame
    void Update()
    {

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
            posB = bPositions[0];
            isMoving = true;
            Debug.Log("cuber started moving up");
        }
        if (hitInfoDown.collider != null && hitInfoDown.collider.gameObject.CompareTag("Player"))
        {
            posB = bPositions[1];
            isMoving = true;
            Debug.Log("cuber started moving down");
        }
        if (hitInfoLeft.collider != null && hitInfoLeft.collider.gameObject.CompareTag("Player"))
        {
            posB = bPositions[2];
            isMoving = true;
            Debug.Log("cuber started moving left");
        }
        if (hitInfoRight.collider != null && hitInfoRight.collider.gameObject.CompareTag("Player"))
        {
            posB = bPositions[3];
            isMoving = true;
            Debug.Log("cuber started moving right");
        }

    }

    private void Move()
    {
        timer += Time.deltaTime;
        transform.position = Vector3.Lerp(posA, posB, curve.Evaluate(timer / durationToAndBack));

        if (timer >= durationToAndBack)
        {
            timer = 0f;
            transform.position = posA;
            isMoving = false;
        }
    }
}