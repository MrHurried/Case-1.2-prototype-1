using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollecting : MonoBehaviour
{
    //Verzamelde punten
    private int collectedPoints = 0;

    //Het puntextscript, hetgene dat verantwoordelijk is voor de text "0/x points collected" te tonen
    [SerializeField] private PointText pointTextScript;

    //Het LoadNextSceneScript op het SceneManager empty object dat aanwezig is in ieder level
    private LoadNextScene nextSceneLoader;

    //punten in de huidige kamer
    private int pointsInCurrentRoom = 0;

    //Het geluid dat afspeelt als je een punt oppakt
    [SerializeField] AudioClip pickupSound;

    //De audiosource die het geluid van het punt moet afspelen.
    AudioSource audioSource;

    private void Awake()
    {
        //Sla een reference naar de point text op
        pointTextScript = GameObject.FindWithTag("PointText").GetComponent<PointText>();
    }

    private void Start()
    {
        // Onder de main camera is een pickup sound player
        audioSource = Camera.main.transform.GetChild(0).gameObject.GetComponent<AudioSource>(); 

        //Pak alle gameobjects met de point tag
        GameObject[] points = GameObject.FindGameObjectsWithTag("Point");

        //Sla de hoeveelheid punten in het level op
        pointsInCurrentRoom = points.Length;

        //Sla een reference naar de scene manager GameObject op (niet te verwarren met unity's SceneManager c# klasse)
        nextSceneLoader = GameObject.FindWithTag("SceneMngr").GetComponent<LoadNextScene>();

        //Refresh de point text
        pointTextScript.Refresh(0, pointsInCurrentRoom);
    }

    /// <summary>
    /// verander punttext
    /// kijk of we genoeg punten hebben, indien wel -> ga naar volgend level
    /// </summary>
    public void CollectPoints(int pointamount = 0)
    {
        collectedPoints += pointamount;
        pointTextScript.Refresh(collectedPoints, pointsInCurrentRoom);
        PlayPickupSound();
        if (collectedPoints >= pointsInCurrentRoom)
        {
            nextSceneLoader.Go();
        }
    }


    // Speel een pickup sound wanneer je iets oppakt, ieders keer met een andere pitch
    private void PlayPickupSound()
    {
        int targetPitch = collectedPoints;
        while(targetPitch > 3)
        {
            targetPitch -= 3;
        }
        audioSource.pitch = targetPitch;
        audioSource.clip = pickupSound;
        audioSource.Play();
    }
}