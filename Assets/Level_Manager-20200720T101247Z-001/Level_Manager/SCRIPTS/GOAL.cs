using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GOAL : MonoBehaviour {
    [SerializeField] ParticleSystem finishedpart;
    [SerializeField] AudioClip suc;

    //public GameObject level_complete;
    AudioSource aud;
    public int unlock;
    public level1 cle;
    string levelname = "Level";
    levelmanagerscript completed;
    void Start()
    {
        Time.timeScale = 1;

        unlock = SceneManager.GetActiveScene().buildIndex;
        levelname += unlock;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "friendly")
        {
            finishedpart.Play();
            cle.clear = true;
            Invoke("levelcomplete", 2.5f);
        }


    }
    void levelcomplete()
    {
        SceneManager.LoadScene(levelname);
    }
}
