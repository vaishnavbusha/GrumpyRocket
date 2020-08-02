using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class levelmanagerscript : MonoBehaviour
{
    int totalstars=0;

    public Button[] buttons;
    [System.Serializable]
    public class Level
    {
        
        public string LevelText;
        //public Button.ButtonClickedEvent OnClick;
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
            //switch (levelscore)
            //{
            //    case 1:
            //        buttons[i].image.sprite = onestar;
            //        break;
            //    case 2:
            //        buttons[i].image.sprite = twostar;
            //        break;
            //    case 3:
            //        buttons[i].image.sprite = threestar;
            //        break;
            //    default:
            //        buttons[i].image.sprite = zerostar;
            //        break;
            //}
            button.GetComponent<Button>().onClick.AddListener(() => LoadLevel("Level" + button.LevelText.text));
        }
    }
    public void LoadLevel(string Name)
    {
        SceneManager.LoadScene(Name);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void UnlockLevel(int levelNumber)
    {
        buttons[levelNumber].interactable = true;
    }
}
