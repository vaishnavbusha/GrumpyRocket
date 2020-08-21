using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class awakemanager : MonoBehaviour
{
    public GameObject buybutton;
    public GameObject startbutton;
    public GameObject rotate;
    public float movespeed;
    public GameObject spawnposition;
    public vehiclelist listofvehicles;
    public int vehiclepointer = 0;

    public Text currency;
    public Text shuttlename;
    public Text rocketcost;

    public Slider thrust_speed;
    public Slider rotation_speed;
    private void Awake()
    {
        PlayerPrefs.SetInt("pointer", vehiclepointer);
        vehiclepointer = PlayerPrefs.GetInt("pointer");
        PlayerPrefs.SetInt("currency", 10);
        
        GameObject childObject = Instantiate(listofvehicles.vehicles[vehiclepointer], spawnposition.transform.position,spawnposition.transform.rotation) as GameObject;
        childObject.transform.parent = rotate.transform;
        childObject.transform.position = Vector3.up;
        getinfo();
    }

    public void Buybutton()
    {
        if(PlayerPrefs.GetInt("currency")>= listofvehicles.vehicles[PlayerPrefs.GetInt("pointer")].GetComponent<rocketship>().price)
        {
            PlayerPrefs.SetInt("currency", PlayerPrefs.GetInt("currency") - listofvehicles.vehicles[PlayerPrefs.GetInt("pointer")].GetComponent<rocketship>().price);
            PlayerPrefs.SetString(listofvehicles.vehicles[PlayerPrefs.GetInt("pointer")].GetComponent<rocketship>().Name.ToString(),listofvehicles.vehicles[PlayerPrefs.GetInt("pointer")].GetComponent<rocketship>().Name.ToString());
            //GameObject.Find("buy").GetComponentInChildren<Text>().text = "bought";
        }
        getinfo();
    }
    private void getinfo()
    {
        thrust_speed.minValue = 0f;
        thrust_speed.maxValue = 100f;
        thrust_speed.wholeNumbers = true;
        thrust_speed.value = listofvehicles.vehicles[PlayerPrefs.GetInt("pointer")].GetComponent<rocketship>().thrustspeed;
        rotation_speed.minValue = 0f;
        rotation_speed.maxValue = 100f;
        rotation_speed.wholeNumbers = true;
        rotation_speed.value = listofvehicles.vehicles[PlayerPrefs.GetInt("pointer")].GetComponent<rocketship>().rotspeed;


        if (listofvehicles.vehicles[PlayerPrefs.GetInt("pointer")].GetComponent<rocketship>().Name.ToString() ==
            PlayerPrefs.GetString(listofvehicles.vehicles[PlayerPrefs.GetInt("pointer")].GetComponent<rocketship>().Name.ToString()))
        {
            Debug.Log(PlayerPrefs.GetString(listofvehicles.vehicles[PlayerPrefs.GetInt("pointer")].GetComponent<rocketship>().Name.ToString()));
            //shuttleinfo.text = "owned";
            shuttlename.text = listofvehicles.vehicles[PlayerPrefs.GetInt("pointer")].GetComponent<rocketship>().Name.ToString();
            rocketcost.text = listofvehicles.vehicles[PlayerPrefs.GetInt("pointer")].GetComponent<rocketship>().price.ToString();
            startbutton.SetActive(true);
            buybutton.SetActive(false);
            currency.text = PlayerPrefs.GetInt("currency").ToString();
            return;
        }

        currency.text = PlayerPrefs.GetInt("currency").ToString();
        shuttlename.text = listofvehicles.vehicles[PlayerPrefs.GetInt("pointer")].GetComponent<rocketship>().Name.ToString();
        rocketcost.text = listofvehicles.vehicles[PlayerPrefs.GetInt("pointer")].GetComponent<rocketship>().price.ToString();
           startbutton.SetActive(false);
           buybutton.SetActive(true);
    }

    private void FixedUpdate()
    {
        //player = GameObject.FindGameObjectWithTag("friendly");
        //player.transform.Rotate(Vector3.up*movespeed*Time.deltaTime);
        rotate.transform.Rotate(Vector3.up * movespeed * Time.deltaTime);
    }
    public void rightbutton()
    {
        if(vehiclepointer < listofvehicles.vehicles.Length - 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            vehiclepointer++;
            PlayerPrefs.SetInt("pointer", vehiclepointer);
            GameObject childObject = Instantiate(listofvehicles.vehicles[vehiclepointer], spawnposition.transform.position, spawnposition.transform.rotation) as GameObject;
            childObject.transform.parent = rotate.transform;
            childObject.transform.position = Vector3.up;
            //PlayerPrefs.SetString(listofvehicles.vehicles[PlayerPrefs.GetInt("pointer")].GetComponent<rocketship>().Name.ToString(), "none");
            getinfo();
        }
    }
    public void leftbutton()
    {
        if (vehiclepointer >0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            vehiclepointer--;
            PlayerPrefs.SetInt("pointer", vehiclepointer);
            GameObject childObject = Instantiate(listofvehicles.vehicles[vehiclepointer], spawnposition.transform.position, spawnposition.transform.rotation) as GameObject;
            childObject.transform.parent = rotate.transform;
            childObject.transform.position = Vector3.up;
            //PlayerPrefs.SetString(listofvehicles.vehicles[PlayerPrefs.GetInt("pointer")].GetComponent<rocketship>().Name.ToString(), "none");
            getinfo();
        }
    }
    public void selectbutton()
    {
        SceneManager.LoadScene(1);
    }

}
