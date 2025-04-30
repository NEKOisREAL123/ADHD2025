using UnityEngine;
using UnityEngine.SceneManagement;

public class FindAgain : MonoBehaviour
{
    [SerializeField]
    private GameObject button_panel;
    [SerializeField]
    private GameObject Find_panel;

    // Start is called before the first frame update
    void Start()
    {
        button_panel.SetActive(false);
        //Button FindAbtn = this.GetComponent<Button>();
        //FindAbtn.onClick.AddListener(OnClickFABtn);
    }
    void Update()
    {
        if (FindUI.allscores >= 12)
        {
            button_panel.SetActive(true);
        }
        else
        {
            button_panel.SetActive(true);
            //button_panel.SetActive(false);
        }
    }

    void OnClickFABtn(){
        Find_panel.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
