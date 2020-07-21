using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Level_manager : MonoBehaviour {

    public Button[] levelButtons;

    public void Start()
    {

        int levelReached = PlayerPrefs.GetInt ("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {

            if (i +1 > levelReached)
            levelButtons[i].interactable = false;

        }

    }

    public void LoadLevel(string Name)
    {
        SceneManager.LoadScene(Name);
    }

}
