using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetGame : MonoBehaviour
{
    Button yourButton;

    void Start()
    {
        //Button btn = yourButton.GetComponent<Button>();
        //btn.onClick.AddListener(OnClickReset);
    }
    
    public void OnClickReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
