using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform target;
    public float smoothspeed = 2f;
    public float smoothtime = 0.3f;
    public Vector3 offset;
    public Vector3 velocity = Vector3.one;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredposition = target.position + offset;
        Vector3 smoothedposition = Vector3.SmoothDamp(transform.position, desiredposition,ref velocity,smoothspeed);
        //Vector3 smoothedposition = Vector3.Lerp(transform.position, desiredposition, smoothspeed * Time.deltaTime);
        transform.position = smoothedposition;
        
    }
}
