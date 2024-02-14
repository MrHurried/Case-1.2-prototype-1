using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GravityShifter : MonoBehaviour
{
    private Keyboard kb;

    [SerializeField] private float absXGravity = 9.86f;
    [SerializeField] private float absYGravity = 9.86f;
    private Rigidbody rb;

    private void Start()
    {
        kb = Keyboard.current;
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector2(0f, 0f);
    }

    void Update()
    {
        if(kb.aKey.wasPressedThisFrame || kb.leftArrowKey.wasPressedThisFrame || kb.qKey.wasPressedThisFrame)
        {
            Physics.gravity = new Vector2(-absXGravity, 0f);
        }
        if (kb.dKey.wasPressedThisFrame || kb.rightArrowKey.wasPressedThisFrame)
        {
            Physics.gravity = new Vector2(absXGravity, 0f);
        }
        if (kb.sKey.wasPressedThisFrame || kb.downArrowKey.wasPressedThisFrame || kb.qKey.wasPressedThisFrame)
        {
            Physics.gravity = new Vector2(0f, -absYGravity);
        }
        if (kb.wKey.wasPressedThisFrame || kb.upArrowKey.wasPressedThisFrame || kb.zKey.wasPressedThisFrame)
        {
            Physics.gravity = new Vector2(0f, absYGravity);
        }

    }
}
