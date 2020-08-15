using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelfinished : MonoBehaviour
{
    public GOAL changelevel;
    // Start is called before the first frame update
    public GameObject lev;
    
    private void Start()
    {
        lev.SetActive(false);
    }
    public void replay()
    {
        int cursceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(cursceneindex);
    }
    public void next()
    {
        changelevel.levelcomplete();
    }
    public void back()
    {
        SceneManager.LoadScene(1);
    }
    
}
