using UnityEngine;
using UnityEngine.UI;

public class Maze2Playermove : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] AllkeysObject;

    [SerializeField] private GameObject Nextlvl;
    
    public SpriteRenderer spriteRenderer;
    private float speed = 4.5f;
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    public Joystick joystick;
    
    private bool gameStart;
    private float time;
    public Text timeLabel;
    private static int keys02 = 1;
    string objectName;

    void Start()
    {
        time = 0;
        gameStart = true;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (gameStart)
        {
            time += Time.deltaTime;
            timeLabel.text = ((int)time).ToString();
        }
        

        horizontalMove = joystick.Horizontal;
        verticalMove = joystick.Vertical;
        
        // 如果使用键盘控制，也可以考虑加入键盘输入检测
        // horizontalMove = Input.GetAxisRaw("Horizontal");
        // verticalMove = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(horizontalMove, verticalMove, 0).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // 设置动画状态
        if (moveDirection.magnitude > 0)
        {
            // 设置角色朝向
            if (moveDirection.x > 0)
                spriteRenderer.flipX = false;
            else if (moveDirection.x < 0)
                spriteRenderer.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Keys"))
        {
            objectName = collision.gameObject.name;
            for (int i = 0; i < AllkeysObject.Length; i++)
            {
                Debug.Log("key0" + keys02);
                Debug.Log(objectName);
                if (objectName == AllkeysObject[i].name && objectName == "key0" + keys02){
                    keys02 += 1;
                    AllkeysObject[i].SetActive(true);
                    collision.gameObject.SetActive(false);
                }
            }
            //Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("Princess"))
        {
            if (keys02 >= 12)
            {
                gameStart = false;
                Nextlvl.SetActive(true);
            }
        }

    }
}
