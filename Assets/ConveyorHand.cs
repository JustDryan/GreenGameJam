using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorHand : MonoBehaviour
{
    public static ConveyorHand conveyorHand;
    public float speed;
    Vector3 target, basePos;
    bool grabbing;

    SpriteRenderer spriteRenderer;
    public Sprite[] handSprites;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        conveyorHand = this;
        basePos = new Vector3(0, 6, 0);
        transform.position = basePos;
    } 

    void Update()
    {
        if (grabbing)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if(transform.position == target)
            {
                grabbing = false;
                spriteRenderer.sprite = handSprites[0];
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, basePos, speed * Time.deltaTime);
            spriteRenderer.sprite = handSprites[0];
        }
    }

    public void SetTarget(Vector3 t)
    {
        grabbing = true;
        target = t;
        spriteRenderer.sprite = handSprites[1];
    }
}
