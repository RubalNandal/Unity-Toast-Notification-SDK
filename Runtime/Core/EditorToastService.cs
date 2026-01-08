using UnityEngine;

namespace ToastSDK.Core
{
    internal class EditorToastService : IToastService
    {
        public void Show(string message)
        {
            Debug.Log($"[ToastSDK | Editor] {message}");
        }
    }
}
