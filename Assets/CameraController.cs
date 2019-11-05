using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    Vector3 target;

    public static CameraController cameraController;

    void Start()
    {
        cameraController = this;
    }

    void Update()
    {
        target.z = -10;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void SetTarget(Vector3 v)
    {
        target = v;
        target.z = -10;
    }
}
