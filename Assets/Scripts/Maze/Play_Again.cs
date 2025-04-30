using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play_Again : MonoBehaviour
{
    [SerializeField]
    private GameObject button_panel;
    [SerializeField]
    private GameObject Maze_panel;
    // Start is called before the first frame update
    void Start()
    {
        Button MazeAbtn = this.GetComponent<Button>();
        MazeAbtn.onClick.AddListener(OnClickABtn);
    }

    void OnClickABtn(){
        Player.keys = 0;
        button_panel.SetActive(false);
        Maze_panel.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
