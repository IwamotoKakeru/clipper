using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class VibrationCtrl : MonoBehaviour
{
    public static void ShortVibration()
    {
        if (SystemInfo.supportsVibration)
        {
            PlaySystemSound(1519);
        }
    }

    //iOS Settings
#if UNITY_IOS && !UNITY_EDITOR
    [DllImport ("__Internal")]
    static extern void _playSystemSound(int n);
#endif
    private static void PlaySystemSound(int n)
    {
#if UNITY_IOS && !UNITY_EDITOR
    _playSystemSound(n);
#endif
    }

    //Android Settings

}
