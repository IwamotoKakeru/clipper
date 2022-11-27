using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaverCtrl : MonoBehaviour
{
    private float timeToDestroy = 0.2f;
    Rigidbody collisionRb = null;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.gameObject.CompareTag("wool")){
            VibrationCtrl.ShortVibration();
            collisionRb = collisionInfo.gameObject.GetComponent<Rigidbody>();
            collisionRb.useGravity = true;
            Destroy(collisionInfo.gameObject,timeToDestroy);
        }
    }
}
