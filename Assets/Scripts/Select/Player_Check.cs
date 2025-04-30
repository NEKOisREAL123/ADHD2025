using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Check : MonoBehaviour
{
    
    [SerializeField]
    private Text UserName;
    [SerializeField]
    private Text UserGender;
    [SerializeField]
    private Text UserAge;
    [SerializeField]
    private Button Next;
    [SerializeField]
    private GameObject userPanel;
    [SerializeField]
    private GameObject SelectPanel;

    [SerializeField]
    private Text Wrong_input;

    public static string getName = "Test";
    public static string getGender ="Male";
    public static int getAge = 6;
    // Start is called before the first frame update
    void Start()
    {
        Button btnSel = this.GetComponent<Button>();
        btnSel.onClick.AddListener(OnClickBtn);
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    void OnClickBtn(){
        getName = UserName.GetComponent<Text>().text;
        getGender = UserGender.GetComponent<Text>().text;
        getAge = System.Convert.ToInt32(UserAge.GetComponent<Text>().text);

        if(getName == ""){
            Wrong_input.text="Please Enter Your Name";
        }
        else if(getName != null && getAge > 100 || getAge < 3){
            Wrong_input.text="Your Age is Wrong";
        }
        else{
            Wrong_input.text=" ";
            userOK();
        }
        
    }
    void userOK(){
        userPanel.SetActive(false);
        SelectPanel.SetActive(true);
    }
}
