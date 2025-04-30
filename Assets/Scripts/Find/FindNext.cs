using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FindNext : MonoBehaviour
{
    private Try _try;
    // Start is called before the first frame update
    void Start()
    {
        Button Findlvlbtn = this.GetComponent<Button>();
        Findlvlbtn.onClick.AddListener(OnClickfindBtn);
    }

    public void OnClickfindBtn(){
        //_try.UpdateData();
        SceneManager.LoadScene("Mazes 1");
    }
}
