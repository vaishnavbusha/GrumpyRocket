using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_comoplete_tut : MonoBehaviour
{
    public string name;

    public void Level()
    {
        SceneManager.LoadScene(name);
    }
}
