using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Platform : PlatFormController
{
    public float moveSpeed=1;
    public bool isLeft;
    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, 1);
        if(i==0)
        {
            isLeft = false;
        }
        else
        {
            isLeft = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (transform.position.x<=-2.2f)
        {
            isLeft = false;
        }
        if (transform.position.x >= 2.2f)
        {
            isLeft = true;
        }
        if (isLeft)
        {
            rigibody.velocity = new Vector2(-moveSpeed, 0);
        }
        else
        {
            rigibody.velocity = new Vector2(moveSpeed, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
