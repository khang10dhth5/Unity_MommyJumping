using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;//lực nhảy
    public float moveSpeed;
    private PlatFormController PlatformLanded;//platform đã nhảy
    private Rigidbody2D rigibody;
    private AudioSource audio;
    public PlatFormController PlatformLanded1 { get => PlatformLanded; set => PlatformLanded = value; }

    private void FixedUpdate()//các phần liên quan vật lí nên cho vào fixupdate thay vì update
    {
        Move();
    }

    private void Awake()
    {
        rigibody = gameObject.GetComponent<Rigidbody2D>();
    }
    public void Jump()
    {
        if (GameManager.Ins.state == GameState.Playing)
        {
            if (!GameManager.Ins) return;
            if (!rigibody || rigibody.velocity.y > 0 || !PlatformLanded)//velocity.y là vận tốc y
                return;
            if (PlatformLanded1 is Break_Platform)
            {
                PlatformLanded1.ActionPlatform();
            }
            rigibody.velocity = new Vector2(rigibody.velocity.x, jumpForce);
        
                audio.Play();
        }
        
    }
    public void Move()
    {
        if (GameManager.Ins.state == GameState.Playing)
        {
            if (!GameManager.Ins || !rigibody || !GamePadController.Ins) return;
            if (GamePadController.Ins.MoveLeft)
            {
                rigibody.velocity = new Vector2(-moveSpeed, rigibody.velocity.y);
            }
            else if (GamePadController.Ins.MoveRight)
            {
                rigibody.velocity = new Vector2(moveSpeed, rigibody.velocity.y);
            }
            else
            {
                rigibody.velocity = new Vector2(0, rigibody.velocity.y);
            }
            gameObject.transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.3f, 2.3f), transform.position.y, transform.position.z);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
