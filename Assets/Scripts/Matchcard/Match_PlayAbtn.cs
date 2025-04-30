using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Match_PlayAbtn : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        Button MatchPlaybtn = this.GetComponent<Button>();
        MatchPlaybtn.onClick.AddListener(OnClickAgainBtn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnClickAgainBtn()
    {
        SceneManager.LoadScene("MemoryCardGame");
        panel.SetActive(true);
    }
}
