using UnityEngine;

namespace ToastSDK.Platform.Android
{
    // Shows a native Android Toast message
    internal class AndroidToastService : IToastService
    {
        public void Show(string message)
        {
            using (var unityPlayer =
                   new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                var activity =
                    unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

                if (activity == null)
                {
                    Debug.LogError("AndroidToastService: currentActivity is null");
                    return;
                }

                activity.Call(
                    "runOnUiThread",
                    new AndroidJavaRunnable(() =>
                    {
                        using (var toastClass =
                               new AndroidJavaClass("android.widget.Toast"))
                        {
                            var toast = toastClass.CallStatic<AndroidJavaObject>(
                                "makeText",
                                activity,
                                message,
                                toastClass.GetStatic<int>("LENGTH_SHORT")
                            );

                            toast.Call("show");
                        }
                    })
                );
            }
        }
    }
}
