using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    static public int keys = 0;
    static public float Mazetime = 0;

    [SerializeField]
    private GameObject button_panel;
    [SerializeField]
    private GameObject Maze_panel;

    [SerializeField] 
    private GameObject[] AllkeysObject;
    
    public Text keyAmount;
    public Text youWin;
    public GameObject door;
    public Text timeLabel;

    private bool gameStart;
    private float time;
    string objectName;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        gameStart = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            time += Time.deltaTime;
            timeLabel.text = (int)time + "s";
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Keys")
        {
            objectName = collision.gameObject.name;
            for (int i = 0; i < AllkeysObject.Length; i++)
            {
                if (objectName == AllkeysObject[i].name){
                    AllkeysObject[i].SetActive(true);
                } 
            }
            keys += 1;
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Princess")
        {
            Mazetime = time;
            gameStart = false;
            Destroy(collision.gameObject);
            youWin.text = "YOU WIN!!!";
            button_panel.SetActive(true);
            Maze_panel.SetActive(false);
            //StartCoroutine(MazeWin());
            

        }
        if (collision.gameObject.tag == "Enemies")
        {
            keys = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
        
    }

    // IEnumerator MazeWin() {
    //     youWin.text = "YOU WIN!!!";
        
    //     yield return new WaitForSeconds(2);
    //     SceneManager.LoadScene("AnsGame");

    // }
}
