using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpikePath : MonoBehaviour
{
    public List<Transform> pathNodes = new List<Transform>();

    public GameObject spikePrefab;

    [SerializeField] private float minNodeDetectionDistance = .01f;

    public int indexOfNoteToMoveTo = 0;
    public int lastNodePassedIndex = -1;

    [SerializeField] AnimationCurve curve;
    public float timer = 0f;

    private Rigidbody spikeRb;

    public float durationBetweenPoints;

    [SerializeField]
    private

    Vector3 lastNodePos;
    Vector3 nextNodePos;

    float distanceBetweenPrevAndNextNode;

    [SerializeField] private float spikeRotationSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; i++)
        {
            pathNodes.Add(transform.GetChild(i));
        }

        spikeRb = Instantiate(spikePrefab, pathNodes[0].transform.position, Quaternion.Euler(0f, 90f , 0f)).GetComponent<Rigidbody>();


        lastNodePos = pathNodes[lastNodePassedIndex].transform.position;
        nextNodePos = pathNodes[indexOfNoteToMoveTo].transform.position;

        distanceBetweenPrevAndNextNode = Vector3.Distance(lastNodePos, nextNodePos);

    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(spikeRb.position, nextNodePos) < minNodeDetectionDistance)
        {
            doReachedPointProcedure();
        }
        timer += Time.deltaTime;


        spikeRb.position = Vector3.Lerp(lastNodePos, nextNodePos, curve.Evaluate((timer / ( distanceBetweenPrevAndNextNode/durationBetweenPoints))));

        spikeRb.MoveRotation(Quaternion.Euler(spikeRb.transform.rotation.eulerAngles.x + spikeRotationSpeed * Time.deltaTime, 90f, 0f));

    }

    void doReachedPointProcedure()
    {
        if (Vector3.Distance(pathNodes[lastNodePassedIndex].position, spikeRb.position) < 0)

        Debug.Log("entered checkpoint");

        timer = 0f;

        indexOfNoteToMoveTo++;
        lastNodePassedIndex++;

        if (indexOfNoteToMoveTo > pathNodes.Count - 1)
            indexOfNoteToMoveTo = 0;
        if (lastNodePassedIndex > pathNodes.Count - 1)
            lastNodePassedIndex = 0;

        lastNodePos = pathNodes[lastNodePassedIndex].transform.position;
        nextNodePos = pathNodes[indexOfNoteToMoveTo].transform.position;

        distanceBetweenPrevAndNextNode = Vector3.Distance(lastNodePos, nextNodePos);
    }
}
