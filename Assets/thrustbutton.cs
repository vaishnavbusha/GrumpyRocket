using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class thrustbutton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool pointerDown = false;

    private rocketship rocket;
    // Start is called before the first frame update
    void Start()
    {
        //rocket = GameObject.Find("rocketship(Clone)").GetComponent<rocketship>();
        rocket = GameObject.FindGameObjectWithTag("Player").GetComponent<rocketship>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
        rocket.thrustbut(false);
    }

    void Update()
    {
        if (pointerDown)
        {
            //Your Code
            rocket.thrustbut(true);
        }

    }
}
