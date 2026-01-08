using UnityEngine;
using ToastSDK.Core;

namespace ToastSDK.Platform.Fallback
{
    internal class UnityToastService : IToastService
    {
        public void Show(string message)
        {
            Debug.Log($"[ToastSDK | Fallback] {message}");
        }
    }
}