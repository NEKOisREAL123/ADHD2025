using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using Random = UnityEngine.Random;

public class atkenim : MonoBehaviour
{
    private float timer = 0;
    private Animator anim;
    [SerializeField] private GameObject enim;


    void Start()
    {
        enim.GetComponent<BoxCollider2D>().enabled = true;
        //anim = GetComponent<Animator>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);

        if (timer > 1.5)
        {
            enim.GetComponent<BoxCollider2D>().enabled = true;
            if ( timer >= 2.01)
            {
                timer = 0;
            }
            Debug.Log("True");
        }
        else
        {
            enim.GetComponent<BoxCollider2D>().enabled = false;
            //StartCoroutine(Wait());

            Debug.Log("False");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        
    }
}
