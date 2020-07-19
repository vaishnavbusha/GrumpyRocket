using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;
public class rocketship : MonoBehaviour
{
    [SerializeField] float mainthrust = 100f;
    [SerializeField] float rotthrust = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip suc;
    [SerializeField] AudioClip death;

    [SerializeField] ParticleSystem boost;
    [SerializeField] ParticleSystem deadpart;
    [SerializeField] ParticleSystem finishedpart;

    Rigidbody body;
    AudioSource aud;
    bool istransitioning = false; 
    [SerializeField]bool collisions = true;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!istransitioning)
        {
            Thrust();
            processInput();
        }
        if(Debug.isDebugBuild)
        {
            debugkeys();
        }
    }
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
            if (!aud.isPlaying)
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