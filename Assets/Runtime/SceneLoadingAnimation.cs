using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadingAnimation : MonoBehaviour
{
    public Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Shrink");
    }

    public void PLayShrinkAnimation()
    {
        animator.SetTrigger("Expand");
    }
}
