using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecking : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(GameTag.Platform.ToString())) return;
        var platformLanded = collision.gameObject.GetComponent<PlatFormController>();
        if (!GameManager.Ins || !GameManager.Ins.Player || !platformLanded) return;
        GameManager.Ins.Player.PlatformLanded1 = platformLanded;
        GameManager.Ins.Player.Jump();
        if(!GameManager.Ins.isPlatformLanded(platformLanded.Id))
        {
            GameManager.Ins.addScore(1);
            GameManager.Ins.PlatformLandedID.Add(platformLanded.Id);
        }
    }
}
