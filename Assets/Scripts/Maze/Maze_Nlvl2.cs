using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Maze_Nlvl2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button Mazelvlbtn = this.GetComponent<Button>();
        Mazelvlbtn.onClick.AddListener(OnClickmazeBtn);
    }

    void OnClickmazeBtn(){
        SceneManager.LoadScene("TryAgain");
    }
}
