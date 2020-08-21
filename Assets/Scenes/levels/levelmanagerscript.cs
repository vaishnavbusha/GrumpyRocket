using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class levelmanagerscript : MonoBehaviour
{
    public int totalstars=0;
    public Button[] buttons;
    [System.Serializable]
    public class Level
    {
        public string LevelText;
    }
    public Level[] buttonlist;
    public Sprite[] stars;
    // Start is called before the first frame update
    void Start()
    {
        FillList();
    }
    private void FillList()
    {
        for (var i=0;i<buttonlist.Length;i++)
        {
            Button new_button = buttons[i];
            level_button_new button = new_button.GetComponent<level_button_new>();
            button.LevelText.text = buttonlist[i].LevelText;
            int levelscore = PlayerPrefs.GetInt("level" + button.LevelText.text,0);
            totalstars += levelscore;
            if (levelscore == 1 || levelscore == 2 || levelscore == 3)
            {
                UnlockLevel(i+1);
            }
            //PlayerPrefs.DeleteKey("level" + button.LevelText.text);
            buttons[i].image.sprite = stars[levelscore];
            button.GetComponent<Button>().onClick.AddListener(() => LoadLevel("Level" + button.LevelText.text));
        }
    }
    public void LoadLevel(string Name)
    {
        SceneManager.LoadScene(Name);
    }
    void Update()
    {
    }
    public void UnlockLevel(int levelNumber)
    {
        buttons[levelNumber].interactable = true;
    }
}
