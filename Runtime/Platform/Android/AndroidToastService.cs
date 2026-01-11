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
            // UnityPlayer class
            using var unityPlayer =
                new AndroidJavaClass("com.unity3d.player.UnityPlayer");

            // Current Android activity (CAN be null if called too early)
            var activity =
                unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            if (activity == null)
            {
                Debug.LogError(
                    "AndroidToastService: currentActivity is null. Toast not shown.");
                return;
            }

            activity.Call(
                "runOnUiThread",
                new AndroidJavaRunnable(() =>
                {
                    // Defensive: activity can still become null on UI thread
                    if (activity == null)
                    {
                        Debug.LogError(
                            "AndroidToastService: activity null on UI thread.");
                        return;
                    }

                    using var toastClass =
                        new AndroidJavaClass("android.widget.Toast");

                    int duration =
                        toastClass.GetStatic<int>("LENGTH_SHORT");

                    using var toast =
                        toastClass.CallStatic<AndroidJavaObject>(
                            "makeText",
                            activity,
                            message,
                            duration
                        );

                    toast.Call("show");
                })
            );
        }
    }
}
#endif
