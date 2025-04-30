using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class items2 : MonoBehaviour
{

    
    public Text Item2;
    private Collider2D col;

    Animator anim;
    


    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForTouch();


    }


    bool CheckForTouch()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            var wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            var touchPosition = new Vector2(wp.x, wp.y);

            if (col == Physics2D.OverlapPoint(touchPosition))
            {
                //Debug.Log("HIT!");

                if (col.gameObject.tag == "item2")
                {

                    Item2.text = "1/1";
                    anim.SetBool("idle2", false);
                    anim.SetBool("finded2", true);

                    FindUI.allscores += 1;


                }
            }
            else
            {
                //Debug.Log("MISS");


            }
        }
        return false;
    }

}
