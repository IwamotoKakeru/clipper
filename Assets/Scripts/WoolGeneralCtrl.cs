using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoolGeneralCtrl : MonoBehaviour
{
    public GameObject[] Wools { get; private set; }
    private int maxWoolNum;

    private SheepTextCtrl sheepText;

    void Start()
    {
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

}
