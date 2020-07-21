using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Goal_2 : MonoBehaviour
{

    public GameObject level_complete;

    public int unlock;


    void Start()
    {
        unlock = SceneManager.GetActiveScene().buildIndex + 1;

        PlayerPrefs.SetInt("levelReached", unlock);
        level_complete.SetActive(true);
    }

}
