using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    public TrashType.Trash trashType;

    float speed;
    Vector3 direction;

    bool moving;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GenerateTrash();
    }

    void Update()
    {
        if (moving)
        {
            MoveTrash();
        }
    }

    void MoveTrash()
    {
        transform.position += (direction * (speed * Time.deltaTime));

        if (rb.bodyType != RigidbodyType2D.Kinematic)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    public void DropTrash()
    {
        SetMoving(false);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void SetMovementAndDirection(Vector3 d, float s)
    {
        direction = d;
        speed = s;
    }

    public void SetMoving(bool b)
    {
        moving = b;
    }

    void GenerateTrash()
    {
        trashType = (TrashType.Trash)Random.Range(0, System.Enum.GetValues(typeof(TrashType.Trash)).Length);
    }
}
