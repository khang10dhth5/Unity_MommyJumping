using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFormController : MonoBehaviour
{
    protected PlayerController player;
    private int id;
    public Transform SpawnPoint;
    protected Rigidbody2D rigibody;

    public int Id { get => id; set => id = value; }

    protected virtual void Awake()
    {
        rigibody = gameObject.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (!GameManager.Ins) return;
        player = GameManager.Ins.Player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void ActionPlatform()
    {

    }
}
