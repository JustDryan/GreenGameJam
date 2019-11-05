using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandContoller : MonoBehaviour
{
    SpriteRenderer handSprite;
    int spriteIndex;

    bool isDipping;
    float timer;

    bool isActive;

    void Start()
    {
        handSprite = GetComponentInChildren<SpriteRenderer>();
        spriteIndex = handSprite.sortingOrder;
    }

    void Update()
    {
        if (isActive)
        {
            HandControl();
        }
    }

    void HandControl()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,10);

        if (Input.GetMouseButtonDown(0))
        {
            isDipping = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDipping = false;
        }

        if (Time.time > timer)
        {
            if (isDipping)
            {
                if (spriteIndex > -9)
                {
                    spriteIndex -= 2;
                    timer = Time.time + 0.2f;
                }
            }
            else
            {
                if (spriteIndex < -1)
                {
                    spriteIndex += 2;
                    timer = Time.time + 0.2f;
                }
            }
        }

        spriteIndex = Mathf.Clamp(spriteIndex, -9, -1);
        handSprite.sortingOrder = spriteIndex;
    }

    public void SetHandActive()
    {
        isActive = true;
    }

    public void SetHandInActive()
    {
        isActive = false;
    }
}
