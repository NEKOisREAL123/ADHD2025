using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour
{
   

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.keys == 8)
        {
            anim.SetBool("idled", false);
            anim.SetBool("opend", true);
            DestroyObjectDelayed();
        }

    }

    void DestroyObjectDelayed()
    {
       
        Destroy(gameObject, 2);
    }


}
