using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GameCtrl : MonoBehaviour
{
    private GameObject woolCtrlObject;
    public GameObject WoolCtrlObject
    {
        set
        {
            woolCtrlObject = value;
        }
    }
    private WoolGeneralCtrl woolCtrl;
    public GameObject timerCtrlObject;
    private TimerCtrl timerCtrl;

    private enum State
    {
        Set,
        Prepare,
        Game,
        Clear
    }
    private State state;


    void Start()
    {
        timerCtrl = timerCtrlObject.GetComponent<Transform>().Find("Text").GetComponent<TimerCtrl>();
        state = State.Set;
    }

    void Update()
    {

        if (woolCtrlObject == null)
        {
            state = State.Set;
        }
        else
        {
            state = State.Prepare;
            if (woolCtrl == null)
            {
                timerCtrl.StartCount();
                woolCtrl = woolCtrlObject.GetComponent<Transform>().Find("Body").GetComponent<WoolGeneralCtrl>();
            }
            state = State.Game;

            Debug.Log("Counting :" + woolCtrl.Wools.Length.ToString());

            if (woolCtrl.Wools.Length <= 0)
            {
                state = State.Clear;
                timerCtrl.StopCount();
                Debug.Log("Count Zero:" + woolCtrl.Wools.Length.ToString());
            }
        }
    }

}
