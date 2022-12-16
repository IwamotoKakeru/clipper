using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GameCtrl : MonoBehaviour
{
    private GameObject sheepCtrlObject;
    public GameObject SheepCtrlObject
    {
        set
        {
            sheepCtrlObject = value;
        }
    }
    private SheepCtrl sheepCtrl;
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

        if (sheepCtrlObject == null)
        {
            state = State.Set;
        }
        else
        {
            state = State.Prepare;
            timerCtrl.StartCount();
            sheepCtrl = sheepCtrlObject.GetComponent<Transform>().Find("Body").GetComponent<SheepCtrl>();
            state = State.Game;

            Debug.Log("Counting :" + sheepCtrl.Wools.Length.ToString());

            if (sheepCtrl.Wools.Length <= 0)
            {
                state = State.Clear;
                timerCtrl.StopCount();
                Debug.Log("Count Zero:" + sheepCtrl.Wools.Length.ToString());
            }
        }
    }

}
