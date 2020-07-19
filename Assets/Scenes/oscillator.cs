using System;
using UnityEngine;
[DisallowMultipleComponent]
public class oscillator : MonoBehaviour
{
    [SerializeField] Vector3 move;
    // Start is called before the first frame update
    [Range(0,1)] [SerializeField] float movefactor;
    Vector3 initialpos,disp;
    [SerializeField] float period = 2f;
    void Start()
    {
        initialpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period; // raises from 0
        const float tau = Mathf.PI * 2f; //1 full cycle aka tau = 360 deg
        float sinwave = Mathf.Sin(cycles * tau);//goes from -1 to +1
        movefactor = sinwave / 2f + 0.5f;
        disp = move * movefactor;
        transform.position = disp + initialpos;
    }
}
