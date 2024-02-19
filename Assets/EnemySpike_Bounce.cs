using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpike_Bounce : MonoBehaviour
{
    [SerializeField] Vector3 moveVector;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(moveVector);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        float angle = Vector3.Angle(normal, moveVector * -1f);

        

        transform.rotation = Quaternion.Euler(90f, angle, 0f);
    }*/
}
