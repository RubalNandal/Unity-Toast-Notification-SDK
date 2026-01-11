#if UNITY_ANDROID
using UnityEngine;
using ToastSDK.Core;

namespace ToastSDK.Platform.Android
{
    // Android-specific implementation using native Toast
    internal class AndroidToastService : IToastService
    {
        public void Show(string message)
        {
    #if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");

                AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
                int duration = toastClass.GetStatic<int>("LENGTH_SHORT");

                AndroidJavaObject toast = toastClass.CallStatic<AndroidJavaObject>("makeText", context, message, duration);
                toast.Call("show");
            }));
    #endif
        }
    }
}
#endif
