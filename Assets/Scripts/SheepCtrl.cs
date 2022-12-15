using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheepCtrl : MonoBehaviour
{
    public int HP { get; private set; }

    private GameObject[] wools;
    private int maxWoolNum;

    private SheepTextCtrl sheepText;

    void Start()
    {
        HP = 4;
        sheepText = GameObject.Find("SheepText").GetComponent<SheepTextCtrl>();
        wools = GameObject.FindGameObjectsWithTag("wool");
        maxWoolNum = wools.Length;
    }

    void Update()
    {
        wools = GameObject.FindGameObjectsWithTag("wool");
        Debug.Log(wools.Length);
        sheepText.SetText(wools.Length.ToString() + "/" + maxWoolNum);
    }

    public void Damage(int damageAmount)
    {
        HP = HP - damageAmount;
    }
}
