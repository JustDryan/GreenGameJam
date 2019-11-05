using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackWhip : MonoBehaviour
{
    float targetX;
    public float whipSpeed;

    void Start()
    {
        targetX = GetComponent<RectTransform>().localPosition.x;
    }

    void Update()
    {
        GetComponent<RectTransform>().localPosition = Vector3.MoveTowards(GetComponent<RectTransform>().localPosition, new Vector3(targetX, 0, 0), whipSpeed * Time.deltaTime);
        //GetComponent<Image>().color -= new Color(0, 0, 0, 0.01f);
    }

    public void SwitchSides()
    {
        targetX = -targetX;
        GetComponent<Image>().color = new Color(0, 0, 0, 1);
    }
}
