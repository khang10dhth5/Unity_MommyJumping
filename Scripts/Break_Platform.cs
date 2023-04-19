using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break_Platform : PlatFormController
{
    public GameObject smoke;
    public override void ActionPlatform()
    {
        Destroy(gameObject, 1f);
    }
    private void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        else
        {
            GameObject s = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
            Destroy(s, 1f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
