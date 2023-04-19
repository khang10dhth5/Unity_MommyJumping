using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadController : Singleton<GamePadController>
{
    public bool isMoble;
    private bool moveLeft;
    private bool moveRight;

    public bool MoveLeft { get => moveLeft; set => moveLeft = value; }
    public bool MoveRight { get => moveRight; set => moveRight = value; }
    public override void Awake()
    {
        MakeSingleton(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoble) return;
        moveLeft = Input.GetAxisRaw("Horizontal") < 0 ? true : false;
        moveRight = Input.GetAxisRaw("Horizontal") > 0 ? true : false;
    }
}
