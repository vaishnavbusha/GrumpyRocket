using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class level1 : MonoBehaviour
{
    float timer = 0f;
    // Start is called before the first frame update
    int curscore = 0;
    public GOAL complete;
    public bool clear = false;
    void Start()
    {
        curscore = PlayerPrefs.GetInt("level1", 0);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //print(timer);
        if (timer < 20f && curscore <=3 && complete.clear)
        {
            PlayerPrefs.SetInt("level1", 3);
        }
        else if (timer > 20f && timer < 60f && curscore < 2 && complete.clear)
            PlayerPrefs.SetInt("level1", 2);
        else if (timer > 60f && timer < 80f && curscore < 1 && complete.clear)
            PlayerPrefs.SetInt("level1", 1);
    }
}
