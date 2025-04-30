using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Try : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text NameLabel1;
    [SerializeField]
    private Text GenderLabel2;
    [SerializeField]
    private Text AgeLabel3;
    [SerializeField]
    private Text timeLabel4;

    public int level;
    public float times1;
    public float times2;
    public float times3;
    public static float timestotal;

    public string player_name;
    public string player_Gender;
    public int player_Age;

    public bool loading = false;
    private clickS _clickS;
    
    public void LoadScence(string Selection) {
        SceneManager.LoadScene(Selection);
    }
    
    void UpdateData()
    {
        player_name = Player_Check.getName;
        player_Age = Convert.ToInt32(Player_Check.getAge);
        player_Gender = Player_Check.getGender;
        //level = _clickS.getlevel();
        times1 = _CardGameManager.timeMatch;
        times2 = Player.Mazetime;
        times3 = FindUI.Findtime;
    }
    private void Start()
    {
        UpdateData();
        //timestotal = times1 + times2 + times3;
        NameLabel1.text = player_name;
        GenderLabel2.text = player_Gender;
        AgeLabel3.text = Convert.ToInt32(player_Age).ToString();
        timeLabel4.text = timestotal + "s";
    }

    void Update()
    {
        NameLabel1.text = player_name;
        GenderLabel2.text = player_Gender;
        AgeLabel3.text = "" + player_Age;
        timeLabel4.text = timestotal + "s";
        //Debug.Log(_CardGameManager.timeMatch);
    }
}
