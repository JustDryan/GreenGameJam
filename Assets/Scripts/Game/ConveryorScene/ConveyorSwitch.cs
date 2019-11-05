using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSwitch : MonoBehaviour
{
    ConveyorController conveyorController;
    public float onRot, offRot;
    float targetRot, rotZ;
    public Transform targetSprite;
    int dir;

    void Start()
    {
        targetRot = onRot;
        rotZ = targetRot;
        conveyorController = transform.parent.GetComponent<ConveyorController>();
    }

    private void Update()
    {
        if (rotZ != targetRot)
        {
            rotZ += dir * 5;
            transform.eulerAngles = new Vector3(0, 0, rotZ);
            ConveyorHand.conveyorHand.SetTarget(targetSprite.position);
        }

        transform.eulerAngles = new Vector3(0, 0, rotZ);
    }

    private void OnMouseDown()
    {
        SwitchConveyor();
    }

    void SwitchConveyor()
    {
        conveyorController.SwitchDirection();

        if(targetRot == onRot)
        {
            targetRot = offRot;
            dir = -1;
        }
        else
        {
            targetRot = onRot;
            dir = 1;
        }
    }
}
