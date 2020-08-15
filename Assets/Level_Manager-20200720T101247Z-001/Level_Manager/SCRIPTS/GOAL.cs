using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GOAL : MonoBehaviour {
    [SerializeField] ParticleSystem finishedpart;
    [SerializeField] AudioClip suc;

    //public GameObject level_complete;
    public levelfinished ob;
    AudioSource aud;
    public int unlock;
    public GameObject buttons;
    //public level1 cle;
    public bool clear = false;
    string levelname = "Level";
    levelmanagerscript completed;
    void Start()
    {
        Time.timeScale = 1;
        //cle = GameObject.FindObjectOfType<level1>();
        unlock = SceneManager.GetActiveScene().buildIndex;
        levelname += unlock;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "friendly")
        {
            finishedpart.Play();
            clear = true;
            ob.lev.SetActive(true);
            buttons.SetActive(false);
            //Invoke("levelcomplete", 2.5f);
        }
    }
    public void levelcomplete()
    {
        SceneManager.LoadScene(levelname);
    }
}
