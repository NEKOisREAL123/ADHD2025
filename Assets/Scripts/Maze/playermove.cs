using UnityEngine;

public class playermove : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private float speed = 4.5f;
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    public Joystick joystick;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    void Update()
    {
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
            anim.SetBool("Playeridle", false);
            anim.SetBool("Playerwalk", true);
            anim.SetBool("Playerrun", false);

            // 设置角色朝向
            if (moveDirection.x > 0)
                spriteRenderer.flipX = false;
            else if (moveDirection.x < 0)
                spriteRenderer.flipX = true;
        }
        else
        {
            anim.SetBool("Playeridle", true);
            anim.SetBool("Playerwalk", false);
            anim.SetBool("Playerrun", false);
        }
    }
}