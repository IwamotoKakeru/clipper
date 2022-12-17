using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaverCtrl : MonoBehaviour
{
    private float timeToDestroy = 0.2f;
    private int damageAmount = 1;
    Rigidbody collisionRb = null;
    BoxCollider collisionCol = null;

    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("Hit Something");
        if (collisionInfo.gameObject.CompareTag("wool"))
        {
            VibrationCtrl.ShortVibration();

            collisionRb = collisionInfo.gameObject.GetComponent<Rigidbody>();
            collisionRb.useGravity = true;

            collisionCol = collisionInfo.gameObject.GetComponent<BoxCollider>();
            collisionCol.isTrigger = true;

            Destroy(collisionInfo.gameObject, timeToDestroy);
        }
        if (collisionInfo.gameObject.CompareTag("sheep"))
        {
            SheepCtrl sheepCtrl = collisionInfo.gameObject.GetComponent<SheepCtrl>();
            sheepCtrl.Damage(damageAmount);
        }
    }
}
