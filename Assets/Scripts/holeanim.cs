using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holeanim : MonoBehaviour
{
    [SerializeField] public GameObject hole;
    // Start is called before the first frame update
    void Start()
    {
        hole.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i <= 120; i++)
        {
            Debug.Log(i);
            if (i == 120)
            {
                hole.SetActive(false);
                Debug.Log("true");
            }
            hole.SetActive(true);
            i = 1;
        }


    }
}
