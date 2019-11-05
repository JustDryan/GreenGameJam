using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashHeapMover : MonoBehaviour
{
    public static TrashHeapMover trashHeapMover;
    public Animator anim;
    Vector3 target;

    void Start()
    {
        trashHeapMover = this;
        target = transform.position;
    }

    

    void Update()
    {
        if (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 2 * Time.deltaTime);
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }

    }

    public void IncreaseTargetHeight()
    {
        target.y += 0.5f;
    }
}
