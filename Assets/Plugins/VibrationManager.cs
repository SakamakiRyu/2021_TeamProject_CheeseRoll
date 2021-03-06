using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VibrationManager
{

#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#else
    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrator;
#endif

    
   

    public static void Vibration(long milliseconds)
    {
        if (isAndroid())
        {
            vibrator.Call("vibrate", milliseconds);
        }
        else
        {
#if UNITY_ANDROID
            Handheld.Vibrate();
#endif
        }
    }
    public static bool isAndroid()
    {
#if UNITY_ANDROID && !UNITY_EDITOR

        return true;

#else
        return false;
        

#endif
    }

    
}
