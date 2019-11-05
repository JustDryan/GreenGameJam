using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    public GameObject trashPrefab;
    bool scene;

    public float conveyorSpeed;

    public BlackWhip blackWhip;
    public HandContoller handController;
    public GameObject swapButton;

    int landFillSize;
    void Start()
    {
        gameController = this;
    }

    void Update()
    {
        
    }

    public void SwitchScenes()
    {
        blackWhip.SwitchSides();
        swapButton.GetComponent<RectTransform>().localPosition = new Vector3
            (-swapButton.GetComponent<RectTransform>().localPosition.x, swapButton.GetComponent<RectTransform>().localPosition.y, swapButton.GetComponent<RectTransform>().localPosition.z);

        if (!scene)
        {
            CameraController.cameraController.SetTarget(new Vector3(19.3f, 0, -10));
            handController.SetHandActive();
        }
        else
        {
            CameraController.cameraController.SetTarget(new Vector3(0, 0, -10));
            handController.SetHandInActive();
        }

        scene = !scene;
    }

    void SpawnTrash()
    {

    }

    public void PushTrashHeap()
    {
        TrashHeapMover.trashHeapMover.IncreaseTargetHeight();
        landFillSize++;
    }
}
