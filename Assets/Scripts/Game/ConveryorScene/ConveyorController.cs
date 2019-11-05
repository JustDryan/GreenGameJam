using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    public bool isSwitch, isEnd;
    Vector3 dir;
    float conveyorSpeed = 1f;

    public Vector3[] directions;
    int dirIndex;

    public GameObject objectActive;

    void Start()
    {
        if (objectActive != null)
        {
            objectActive.SetActive(false);
        }

        dir = transform.up * -1;
        if (isSwitch)
        {
            dir = directions[0];
        }
    }

    private void Update()
    {
        conveyorSpeed = GameController.gameController.conveyorSpeed;
    }

    public void SwitchDirection()
    {
        if (!isSwitch) return;
        if(objectActive != null)
        {
            objectActive.SetActive(!objectActive.activeSelf);
        }
        if(dirIndex == 0)
        {
            dirIndex = 1;
        }
        else
        {
            dirIndex = 0;
        }

        dir = directions[dirIndex];
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Trash")
        {
            if(other.gameObject.GetComponent<TrashController>() != null)
            {
                other.gameObject.GetComponent<TrashController>().SetMovementAndDirection(dir, conveyorSpeed);
                other.gameObject.GetComponent<TrashController>().SetMoving(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!isEnd) return;
        if (other.gameObject.tag == "Trash")
        {
            if (other.gameObject.GetComponent<TrashController>() != null)
            {
                other.gameObject.GetComponent<TrashController>().DropTrash();
            }
        }
    }
}
