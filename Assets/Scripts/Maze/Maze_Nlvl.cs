using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Maze_Nlvl : MonoBehaviour
{
    void Start()
    {
        Button Mazelvlbtn = this.GetComponent<Button>();
        Mazelvlbtn.onClick.AddListener(OnClickmazeBtn);
    }

    void OnClickmazeBtn(){
         SceneManager.LoadScene("Scenes/Mazes 1");
    }
}
