using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;
public class rocketship : MonoBehaviour
{
    [SerializeField] float mainthrust = 100f;
    [SerializeField] float rotthrust = 100f;
    [SerializeField] bool collisions = true;

    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip suc;
    [SerializeField] AudioClip death;


    [SerializeField] ParticleSystem boost;
    [SerializeField] ParticleSystem deadpart;
    [SerializeField] ParticleSystem finishedpart;

    Rigidbody body;
    AudioSource aud;
    bool istransitioning = false;
    //public static bool ispaused = false;
    //public GameObject pausemenuUI;
    void Start()
    {

        /*pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        ispaused = false;*/
        body = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ispaused)
                resume();
            else
                pause();
        }*/
        if (!istransitioning)
        {
            Thrust();
            processInput();
        }
        if(Debug.isDebugBuild)
        {
            debugkeys();
        }
    }
    /*void resume()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        ispaused = false;
    }
    void pause()
    {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        ispaused = true;
    }*/
    void debugkeys()
    {
        if (Input.GetKey(KeyCode.L))
            loadnextlevel();
        else if (Input.GetKey(KeyCode.C))
            collisions = !collisions;

    }
    void OnCollisionEnter(Collision obj)
    {
        if (istransitioning || !collisions)
            return;
        switch(obj.gameObject.tag)
        {
            case "Finish":
                 
                print("finished");
                aud.Stop();                                                                                    
                aud.PlayOneShot(suc);
                finishedpart.Play();
                Invoke("loadnextlevel", 3f);
                break;
            case "friendly": 
                break;
            default:
                istransitioning = true;
                aud.Stop();
                aud.PlayOneShot(death);
                deadpart.Play();
                Invoke("loadsamelevel", 1f);
                break;
        }
 
    }
    void loadnextlevel()
    {
        int cursceneindex = SceneManager.GetActiveScene().buildIndex;
        int nextsceneindex = cursceneindex+1;
        if(nextsceneindex == SceneManager.sceneCountInBuildSettings)
        {
            nextsceneindex = 0;
        }
        SceneManager.LoadScene(nextsceneindex);
    }
    void loadsamelevel()
    {
        int cursceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(cursceneindex);
    }
    void Thrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            body.AddRelativeForce(Vector3.up*mainthrust);
            if (!aud.isPlaying && Time.timeScale!=0f)
            {
                aud.PlayOneShot(mainEngine);
                boost.Play();
            }
        }
        else//stop thrusting
        {
            aud.Stop();
            boost.Stop();
        }
    }
    void processInput()
    {
        body.freezeRotation = false;
        if (Input.GetKey(KeyCode.A))
        {

            transform.Rotate(Vector3.forward*rotthrust*Time.deltaTime);

        }
        else if(Input.GetKey(KeyCode.D))
        {

            transform.Rotate(-Vector3.forward*rotthrust*Time.deltaTime);

        }
        body.freezeRotation = true;
    }
}