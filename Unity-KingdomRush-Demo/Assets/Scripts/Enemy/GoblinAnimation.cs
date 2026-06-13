using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAnimation : MonoBehaviour
{
    private Animator animator;
    Vector3 lastPosition;
    Vector3 deltaPosition;
    void Start()
    {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        deltaPosition = transform.position - lastPosition;
        animator.SetFloat("MoveX", deltaPosition.x);
        animator.SetFloat("MoveY", deltaPosition.y);
        lastPosition = transform.position;

    }
}
