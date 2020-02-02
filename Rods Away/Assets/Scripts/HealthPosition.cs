using System;
using System.Collections;
using UnityEngine;
using UnityEngine .UI;

public class HealthPosition : MonoBehaviour
{
    public Canvas canvas;
    RectTransform rectTransform;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    void Start()
    {
        Vector2 pos = gameObject.transform.position;  // get the game object position
        Vector2 viewportPoint = Camera.main.WorldToViewportPoint(pos);  //convert game object position to VievportPoint

        var camRectTransform = canvas.GetComponent<RectTransform>();

        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((viewportPoint.x * camRectTransform.sizeDelta.x) - (camRectTransform.sizeDelta.x * 0.5f)),
        ((viewportPoint.y * camRectTransform.sizeDelta.y) - (camRectTransform.sizeDelta.y * 0.5f)));


        rectTransform.anchoredPosition = WorldObject_ScreenPosition;
        // set MIN and MAX Anchor values(positions) to the same position (ViewportPoint)
        //rectTransform.anchorMin = viewportPoint;
        //rectTransform.anchorMax = viewportPoint;
    }
}
