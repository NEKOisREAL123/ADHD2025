using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Nextlvl_Match : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button Matchlvlbtn = this.GetComponent<Button>();
        Matchlvlbtn.onClick.AddListener(OnClicklvlBtn);
    }

    void OnClicklvlBtn(){
        StartCoroutine(Wait());
    }
    
    IEnumerator Wait(){
        SceneManager.LoadScene("AnsGame");
        yield return new WaitForSeconds(2);
    }
}
