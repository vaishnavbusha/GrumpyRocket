using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class rightbuttonscript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool pointerDown = false;

    private rocketship rocket;
    // Start is called before the first frame update
    void Start()
    {
        rocket = GameObject.Find("rocketship").GetComponent<rocketship>();
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
            rocket.righttilt();
        }
    }
}
