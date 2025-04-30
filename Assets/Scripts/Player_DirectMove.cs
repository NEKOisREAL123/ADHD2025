using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_DirectMove : MonoBehaviour
{
    public int index = 0;
    public float speed = 0.05f;
    public Transform[] theWayPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != theWayPoints[index].position)
        {
                MoveToThePoints();        
        }
        else
        {
            index = ++index % theWayPoints.Length;
        }
    }

    private void MoveToThePoints()
    {
        Vector2 temp = Vector2.MoveTowards(transform.position, theWayPoints[index].position, speed * Time.deltaTime);
        GetComponent<Rigidbody2D>().MovePosition(temp);
    }
}
