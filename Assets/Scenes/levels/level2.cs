using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class level2 : MonoBehaviour
{
    float timer = 0f;
    // Start is called before the first frame update
    int curscore = 0;
    public bool clear = false;
    void Start()
    {
        curscore = PlayerPrefs.GetInt("level2", 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 20f && curscore < 3 && clear)
        {
            PlayerPrefs.SetInt("level2", 3);
        }
        else if (timer > 20f && timer < 60f && curscore < 2 && clear)
            PlayerPrefs.SetInt("level2", 2);
        else if (timer > 60f && timer < 80f && curscore < 1 && clear)
            PlayerPrefs.SetInt("level2", 1);
    }
}
