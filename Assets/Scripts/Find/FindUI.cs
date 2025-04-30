using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FindUI : MonoBehaviour
{
    public static int allscores = 0;
    public static float Findtime;
    //public Text Win;
    public Text timeLabel;
    private bool gameStart;

    [SerializeField]
    public GameObject PanelFindUI;
    [SerializeField]
    public GameObject joystick;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        gameStart = true;
        allscores = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {

            time += Time.deltaTime;
            timeLabel.text = ((int)time).ToString();

        }
        if (allscores >= 12)
        {
            gameStart = false;
            StartCoroutine(Wait_Loading());
            //Win.text = "Congratulation~";
            Findtime = time;
            //StartCoroutine(Wait());
            PanelFindUI.SetActive(true);
            joystick.SetActive(false);  
            
        }


    }
    IEnumerator Wait_Loading()
    {
        yield return new WaitForSeconds(1);

    }
    // IEnumerator Wait() {
    //
    //     yield return new WaitForSeconds(2);
    //     SceneManager.LoadScene("TryAgain");
    // }
}