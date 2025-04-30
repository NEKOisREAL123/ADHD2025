using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class clickS : MonoBehaviour
{

    [SerializeField]
    private Slider levelSlider;
    [SerializeField]
    private Text AgeLabel;
    [SerializeField]
    private Text LevelLabel;
    
    public static int levelSelect;

    public static int gameLevel_1 = 2;
    public static int gameLevel_2 = 6;

    public static string setLevel;

    // Update is called once per frame
    void Update()
    {
        SetGameSize();
        SetGameLevel();
    }

    
    public void LevelOnClick()
    {
        if (levelSelect == 2)
        {
            SetGameLevel();
        }
        else if (levelSelect == 1)
        {
            SetGameLevel();
        }
        else
        {
            SetGameLevel();
        }
        SceneManager.LoadScene("MemoryCardGame");
    }
    
    
    void SetGameSize()
    {
        if(Player_Check.getAge > 17){
            AgeLabel.text = "Adult";
        }
        else{
            AgeLabel.text = "Child";
        }
    }
    public void  SetGameLevel(){
        getlevel();
        if (levelSelect == 2)
        {
            gameLevel_1 = 2;
            gameLevel_2 = 6;
            LevelLabel.text = " High ";
        }
        else if (levelSelect == 1)
        {
            gameLevel_1 = 2;
            gameLevel_2 = 4;
            LevelLabel.text = " Medium ";
        }
        else
        {
            gameLevel_1 = 2;
            gameLevel_2 = 3;
            LevelLabel.text = " Easy ";
        }
        setLevel = LevelLabel.text;
    }

    public int getlevel()
    {
        return levelSelect = (int)levelSlider.value;
    }
}
