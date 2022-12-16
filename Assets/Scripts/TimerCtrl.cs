using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCtrl : MonoBehaviour
{
    private int minute, seconds, milliSeconds;
    private float elapsedTime;
    private Text timerText;
    private bool isCountingTime;
    // Start is called before the first frame update
    void Start()
    {
        isCountingTime = false;
        minute = 0;
        seconds = 0;
        milliSeconds = 0;
        timerText = GetComponentInChildren<Text>();
    }
    public void StartCount()
    {
        isCountingTime = true;
    }

    public void StopCount()
    {
        isCountingTime = false;
        timerText.color = Color.red;
        Debug.Log("Count Stop");
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountingTime) elapsedTime += Time.deltaTime;

        minute = (int)elapsedTime / 60;
        seconds = (int)elapsedTime % 60;
        milliSeconds = (int)(elapsedTime % 1 * 100);

        timerText.text = minute.ToString("00") + ":" + seconds.ToString("00") + ":" + milliSeconds.ToString("00");

    }
}
