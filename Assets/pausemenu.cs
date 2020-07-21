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
    void Start()
    {
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
