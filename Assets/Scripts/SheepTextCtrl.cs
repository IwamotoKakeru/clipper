using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheepTextCtrl : MonoBehaviour
{
    private RectTransform sheepRectTfm;
    private GameObject camera;
    private Text text;


    public void SetText(string str)
    {
        text.text = str;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Start()
    {
        text = GetComponent<Text>();
        sheepRectTfm = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Implemented later
        // sheepRectTfm.rotation = Quaternion.LookRotation(sheepRectTfm.position - camera.transform.position);
    }
}
