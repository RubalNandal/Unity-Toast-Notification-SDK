#if UNITY_ANDROID
using UnityEngine;
using ToastSDK.Core;

namespace ToastSDK.Platform.Android
{
    internal class AndroidToastService : IToastService
    {
        public void Show(string message)
        {
            using AndroidJavaClass unityPlayer =
                new AndroidJavaClass("com.unity3d.player.UnityPlayer");

            using AndroidJavaObject activity =
                unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            using AndroidJavaClass toastClass =
                new AndroidJavaClass("android.widget.Toast");

            activity.Call(
                "runOnUiThread",
                new AndroidJavaRunnable(() =>
                {
                    using AndroidJavaObject toast =
                        toastClass.CallStatic<AndroidJavaObject>(
                            "makeText",
                            activity,
                            message,
                            toastClass.GetStatic<int>("LENGTH_SHORT")
                        );

                    toast.Call("show");
                })
            );
        }
    }
}
#endif
