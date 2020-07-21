using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

    //public string Level= SceneManager.GetActiveScene().name;
    int LevelAmount = 50;
    private int currentLevel;

    public void Start()
    {
        CheckLevel();
    }

    void CheckLevel()
    {
        for (int i = 1; i <= LevelAmount; i++)
        {
            if (SceneManager.GetActiveScene().name == "Level" + i)
            {
                currentLevel = i;
                SaveMyGame();
            }
        }
    }

    void SaveMyGame()
    {
        int NextLevel = currentLevel + 1;
        if(NextLevel <= LevelAmount)
        {
            PlayerPrefs.SetInt("Level" + NextLevel.ToString(), 1);
        }

        LoadNextLevel();
    }

    public void LoadNextLevel ()
	{
       // AdManager.Instance.bannerad.Destroy();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

}
