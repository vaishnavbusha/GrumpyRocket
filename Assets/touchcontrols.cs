using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchcontrols : MonoBehaviour
{
    private rocketship rocket;
    // Start is called before the first frame update
    void Start()
    {
        rocket = GameObject.Find("rocketship").GetComponent<rocketship>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void uparrow()
    {
            rocket.Thrust();        
    }
    public void leftarrow()
    {
        rocket.lefttilt();
    }
    public void rightarrow()
    {
            rocket.righttilt();
    }
}
