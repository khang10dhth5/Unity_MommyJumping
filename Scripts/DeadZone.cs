using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private GameObject gameController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag==GameTag.Platform.ToString())
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag == GameTag.Player.ToString())
        {
            Destroy(collision.gameObject);
            gameController.GetComponent<GameController>().EndGame();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
