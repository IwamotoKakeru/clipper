using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaverCtrl : MonoBehaviour
{
    private float timeToDestroy = 0.1f;

    void OnCollisionEnter(Collision collisionInfo)
    {
        VibrationCtrl.ShortVibration();

        if(true){
            Destroy(collisionInfo.gameObject,timeToDestroy);
        }
    }
}
