using UnityEngine;
using ToastSDK.Core;

namespace ToastSDK.Platform.Editor
{
    internal class EditorToastService : IToastService
    {
        public void Show(string message)
        {
            Debug.Log($"[ToastSDK | Editor] {message}");
        }
    }
}
