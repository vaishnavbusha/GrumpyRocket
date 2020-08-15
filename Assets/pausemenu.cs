using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public static bool pause=false;
    // Update is called once per frame
    public GameObject pausemenuUI;
    private static pausemenu instance = null;

    // Game Instance Singleton
    public static pausemenu Instance => instance;
    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        pausemenuUI.SetActive(false);
    }
    public void resume()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        pause = !pause;
    }
    public void mainmenu()
    {
        SceneManager.LoadScene(0);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void pauseactive()
    {
        pause = !pause;
    }
    void Update()
    {
        if(pause)
        {
            pausemenuUI.SetActive(true);
            Time.timeScale = 0f;

        }
        else
        {
            pausemenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            pause = !pause;
    }
}
