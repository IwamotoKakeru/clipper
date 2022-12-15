using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheepCtrl : MonoBehaviour
{
    public int HP { get; private set; }

    private GameObject[] wools;


    void Start()
    {
        HP = 4;
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
