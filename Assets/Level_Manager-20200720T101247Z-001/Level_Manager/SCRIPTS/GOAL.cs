using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GOAL : MonoBehaviour {
    [SerializeField] ParticleSystem finishedpart;
    [SerializeField] AudioClip suc;

    public GameObject level_complete;
    AudioSource aud;
    public int unlock;

    void Start()
    {
        Time.timeScale = 1;

        unlock = SceneManager.GetActiveScene().buildIndex + 1;

        level_complete.SetActive(false);


    }

    /*void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Player"))
        {

            
            PlayerPrefs.SetInt("levelReached", unlock);
            level_complete.SetActive(true);


        }
    }*/
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "friendly")
        {
            finishedpart.Play();
            Invoke("levelcomplete", 2.5f);
            PlayerPrefs.SetInt("levelReached", unlock);
            //
        }


    }
    void levelcomplete()
    {
        
        level_complete.SetActive(true);
    }
}
