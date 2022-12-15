using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheepTextCtrl : MonoBehaviour
{
    private RectTransform sheepRectTfm;
    private Text text;

    public void SetText(string str)
    {
        text.text = str;
    }
    void Start()
    {
        text = GetComponent<Text>();
        sheepRectTfm = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        sheepRectTfm.rotation = Quaternion.LookRotation(sheepRectTfm.position - Camera.main.transform.position);
    }
}
