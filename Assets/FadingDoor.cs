using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingDoor : MonoBehaviour
{
    Vector3 defaultRotation;

    [SerializeField] float jitterSpeed = 1.0f; //how fast it shakes
    [SerializeField] float jitterAmount = 1.0f; //how much it shakes

    [SerializeField] float timer = 0f;

    [SerializeField] float timeInImpassableState;
    [SerializeField] float timeInPassableState;

    public Material passableMaterial;
    public Material impassableMaterial;

    enum State
    {
        impassable,
        passable
    };

    private State state = State.impassable;

    // Start is called before the first frame update
    void Start()
    {
        defaultRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(state == State.passable)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, Random.Range(defaultRotation.z -15f, defaultRotation.z + 15f)));

            if (timer >= timeInPassableState )
            {
                gameObject.tag = "Enemy";
                GetComponent<Collider>().enabled = true;
                GetComponent<Renderer>().material = impassableMaterial;
                state = State.impassable;
                timer = 0f;
            }
        }
        if(state == State.impassable)
        {
            transform.rotation = Quaternion.Euler(defaultRotation);

            if (timer >= timeInImpassableState)
            {
                gameObject.tag = "Untagged";
                GetComponent<Collider>().enabled = false;
                GetComponent<Renderer>().material = passableMaterial;
                state = State.passable;
                timer = 0f;
            }
        }

    }
}
