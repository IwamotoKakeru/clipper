using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheepCtrl : MonoBehaviour
{
    public int HP { get; private set; }

    public GameObject[] Wools { get; private set; }
    private int maxWoolNum;

    private SheepTextCtrl sheepText;

    void Start()
    {
        HP = 4;
        sheepText = GameObject.Find("SheepText").GetComponent<SheepTextCtrl>();
        Wools = GameObject.FindGameObjectsWithTag("wool");
        maxWoolNum = Wools.Length;
    }

    void Update()
    {
        Wools = GameObject.FindGameObjectsWithTag("wool");
        Debug.Log("NumOfWools:" + Wools.Length);
        sheepText.SetText(Wools.Length.ToString() + "/" + maxWoolNum);
    }

    public void Damage(int damageAmount)
    {
        HP = HP - damageAmount;
    }
}
