using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehiclemanager : MonoBehaviour
{
    public rocketship r;
    public GameObject spawnposition;
    public vehiclelist list;
    public void Start()
    {
        Instantiate(list.vehicles[PlayerPrefs.GetInt("pointer")],spawnposition.transform.position,spawnposition.transform.rotation);
        r = GameObject.FindGameObjectWithTag("Player").GetComponent<rocketship>();
    }
}
