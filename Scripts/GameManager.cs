using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public PlayerController Player;
    public GameState state;
    public int startingPlatform;//số platform khởi đầu
    public float xSpawnOffset;//giới hạn x
    public float minYSpawn;
    public float maxYSpawn;
    public PlatFormController[] platformPrefabs;
    public CollectableItem[] collectTableItem;
    public AudioSource audio;
    private PlatFormController lastPlatformLanded;
    private List<int> platformLandedID;
    private int score;
    private GameObject gameController;
    public PlatFormController LastPlatformLanded { get => lastPlatformLanded; set => lastPlatformLanded = value; }
    public List<int> PlatformLandedID { get => platformLandedID; set => platformLandedID = value; }
    public int Score { get => score; set => score = value; }

    // Start is called before the first frame update

    public override void Start()
    {
        base.Start();
        //Invoke("PlatformInit", 1f);
        audio = gameObject.GetComponent<AudioSource>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }
    public override void Awake()
    {
        MakeSingleton(false);
        platformLandedID = new List<int>();
    }
    public bool isPlatformLanded(int idplatform)
    {
        if (platformLandedID==null || platformLandedID.Count <= 0) return false;
        return platformLandedID.Contains(idplatform);
    }
    public void addScore(int sc)
    {
        if (GameManager.Ins.state == GameState.Playing)
        {
            Score += sc;
            Pref.BestScore = Score;
            gameController.GetComponent<GameController>().GetScore();
        }
    }
    public void PlatformInit()
    {
        if (GameManager.Ins.state == GameState.Playing)
        {
            LastPlatformLanded = Player.PlatformLanded1;
            for (int i = 0; i < startingPlatform; i++)
            {
                SpawnPlatform();
            }
            Player.Jump();
        }
    }
    public void SpawnCollectTB(PlatFormController tf)
    {
        if (!Player || collectTableItem == null || collectTableItem.Length <= 0) return;
        int r = Random.Range(0, collectTableItem.Length);
        var colecttb = collectTableItem[r];
        if (!colecttb) return;
        var c = Instantiate(colecttb, tf.SpawnPoint.position, Quaternion.identity);
        c.platform = tf;
    }
    public void SpawnPlatform()
    {
        if (!Player || platformPrefabs == null || platformPrefabs.Length <= 0) return;
        float x = Random.Range(-(2.3f - xSpawnOffset), (2.3f - xSpawnOffset));
        float disbetween = Random.Range(minYSpawn, maxYSpawn);
        float y = LastPlatformLanded.transform.position.y + disbetween;
        Vector3 posNewPlatform = new Vector3(x, y, 0);
        int r = Random.Range(0, platformPrefabs.Length);
        var newPlatform = platformPrefabs[r];
        if (!newPlatform) return;
        var platform=Instantiate(newPlatform, posNewPlatform, Quaternion.identity);
        platform.GetComponent<PlatFormController>().Id = LastPlatformLanded.Id + 1;
        LastPlatformLanded = platform;
        int ran = Random.Range(0, 10);
        if(ran<4)
        {
            SpawnCollectTB(platform);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
