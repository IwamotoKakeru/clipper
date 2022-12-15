﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepTextCtrl : MonoBehaviour
{
    private RectTransform sheepRectTfm;
    void Start()
    {
        sheepRectTfm = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        sheepRectTfm.rotation = Quaternion.LookRotation(sheepRectTfm.position - Camera.main.transform.position);
    }
}
