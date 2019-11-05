using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorArm : MonoBehaviour
{
    LineRenderer lineRenderer;
    Vector3 armBasePos;
    public Transform hand;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        armBasePos = new Vector3(0, 6, 0);
    }

    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        armBasePos.x = mouse.x;

        lineRenderer.SetPosition(0, armBasePos);
        lineRenderer.SetPosition(1, hand.position + (Vector3.up * 0.05f));
    }
}
