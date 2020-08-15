using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class awakemanager : MonoBehaviour
{
    public GameObject player;
    public GameObject rotate;
    public float movespeed;
    private void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("friendly");
        player.transform.Rotate(Vector3.up*movespeed*Time.deltaTime);
        rotate.transform.Rotate(Vector3.up * movespeed * Time.deltaTime);
    }
}
