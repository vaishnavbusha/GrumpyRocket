using System.Threading;
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
    public AudioSource thrustaudiosource;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();
        thrustaudiosource = thrustaudiosource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!istransitioning)
        {
            //Thrust();
            processInput();
        }
        //if(Debug.isDebugBuild)
        //{
        //    debugkeys();
        //}
    }
    //void debugkeys()
    //{
    //    if (Input.GetKey(KeyCode.L))
    //        loadnextlevel();
    //    else if (Input.GetKey(KeyCode.C))
    //        collisions = !collisions;

    //}

    void OnCollisionEnter(Collision obj)
    {
        if (istransitioning || !collisions)
            return;
        switch(obj.gameObject.tag)
        {
            /*case "Finish":
                 
                print("finished");
                aud.Stop();                                                                                    
                aud.PlayOneShot(suc);
                finishedpart.Play();
                //Invoke("loadnextlevel", 3f);*/
                //break;
            case "friendly": 
                break;
            case "Finish":
                break;
            //case "levelcompletepad":

            default:
                istransitioning = true;
                aud.Stop();
                aud.PlayOneShot(death);
                deadpart.Play();
                Invoke("loadsamelevel", 1f);
                break;
        }
        
    }
    //void loadnextlevel()
    //{
    //    int cursceneindex = SceneManager.GetActiveScene().buildIndex;
    //    int nextsceneindex = cursceneindex+1;
    //    if(nextsceneindex == SceneManager.sceneCountInBuildSettings)
    //    {
    //        nextsceneindex = 0;
    //    }
    //    SceneManager.LoadScene(nextsceneindex);

    //}
    void loadsamelevel()
    {
        int cursceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(cursceneindex);
    }
    //public void Thrust()
    //{
    //    if(Input.GetKey(KeyCode.Space))
    //    {
    //        body.AddRelativeForce(0,1*mainthrust,0);
    //        if (!aud.isPlaying && Time.timeScale!=0f)
    //        {
    //            aud.PlayOneShot(mainEngine);
                
    //        }
    //        boost.Play();
    //    }
    //    else//stop thrusting
    //    {
    //      aud.Stop();
    //      boost.Stop();
    //    }
    //}
    public void thrustbut(bool ispressing)
    {
        if (ispressing&&!istransitioning)
        {
            body.AddRelativeForce(0, 1 * mainthrust, 0);
            if (!thrustaudiosource.isPlaying && Time.timeScale != 0f)
            {
                thrustaudiosource.PlayOneShot(mainEngine);
                boost.Play();
            }
            
        }
        else//stop thrusting
        {
            thrustaudiosource.Stop();
            boost.Stop();
        }
    }

    public void processInput()
    {
        body.freezeRotation = false;
        if (Input.GetKey(KeyCode.A))
            lefttilt();
        else if (Input.GetKey(KeyCode.D))
            righttilt();
        
        body.freezeRotation = true;
    }
    public void lefttilt()
    {
        transform.Rotate(0,0,1*rotthrust*Time.deltaTime);
    }
    public void righttilt()
    {
        transform.Rotate(0,0,-1 * rotthrust * Time.deltaTime);
    }
}