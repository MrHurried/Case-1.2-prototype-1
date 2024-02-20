using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private List<string> colliderTags = new List<string>();
    [SerializeField] private GameObject deathPS; //death particle system
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collect 1 points (sent to player)
            collision.gameObject.GetComponent<PointCollecting>().CollectPoints(1);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Instantiate death particle system
            Instantiate(deathPS, transform.position, Quaternion.identity); // scene reloading is handled in the deathPS of the player
            GetComponent<TrailRenderer>().enabled = false;
            Destroy(gameObject);
            
        }

        if (colliderTags.Contains(collision.gameObject.tag))
        {
            //Instantiate death particle system
            Instantiate(deathPS, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


}
