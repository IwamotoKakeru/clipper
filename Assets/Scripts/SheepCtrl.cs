using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepCtrl : MonoBehaviour
{
    public int HP { get; private set; }

    private GameObject[] wools;


    void Start()
    {
        HP = 4;
        wools = GameObject.FindGameObjectsWithTag("wool");
    }

    void Update()
    {
        wools = GameObject.FindGameObjectsWithTag("wool");
        Debug.Log(wools.Length);
    }

    public void Damage(int damageAmount)
    {
        HP = HP - damageAmount;
    }
}
