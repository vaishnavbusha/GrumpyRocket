using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
public class awdawd : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool pointerDown = false;

    private rocketship rocket;
    void Start()
    {
        rocket = GameObject.FindGameObjectWithTag("Player").GetComponent<rocketship>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
    }

    void Update()
    {
        if (pointerDown)
        {
            //Your Code
            rocket.lefttilt();
        }
    }
}
