using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartOnClick : MonoBehaviour
{
    [SerializeField] private GameObject UserIn;
    [SerializeField] private GameObject StartUI;
    //public Button Startbutton;
    //public Button btn_s;
    
    // Start is called before the first frame update
    void Start()
    {
        Button btn_s = this.GetComponent<Button>();
        btn_s.onClick.AddListener(OnClickStart);
        Debug.Log("True");
        
    }

    private void Update()
    {
        //btn_s.onClick.AddListener(UserClick);
    }

    // Update is called once per frame
    public void OnClickStart()
    {
        Debug.Log("Click1");
        UserIn.SetActive(true);
        StartUI.SetActive(false);
        
        //Startbutton.interactable = false;
        
    }
    
}
