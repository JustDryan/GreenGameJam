using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinController : MonoBehaviour
{
    public TrashType.Trash trashType;
    public GameObject tickEffect, crossEffect;

    public int trashCountMax;
    int trashCount;

    void Start()
    {
        tickEffect = Resources.Load<GameObject>("Effects/Tick") as GameObject;
        crossEffect = Resources.Load<GameObject>("Effects/Cross") as GameObject;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Trash")
        {
            if(collision.gameObject.GetComponent<TrashController>() != null)
            {
                if(collision.gameObject.GetComponent<TrashController>().trashType == trashType)
                {
                    Destroy(collision.gameObject);
                    GameObject e = Instantiate(tickEffect, transform);
                    Destroy(e, 1.5f);
                }
                else
                {
                    Destroy(collision.gameObject);
                    GameObject e = Instantiate(crossEffect, transform);
                    Destroy(e, 1.5f);
                    GameController.gameController.PushTrashHeap();
                }
            }
        }
    }
}
