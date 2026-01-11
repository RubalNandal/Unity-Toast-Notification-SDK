using ToastSDK.Platform;

namespace ToastSDK.Core
{
    internal static class ToastService
    {
        private static IToastService _instance;

        internal static IToastService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = CreateService();
                }

                return _instance;
            }
        }

        private static IToastService CreateService()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            return new ToastSDK.Platform.Android.AndroidToastService();
#elif UNITY_IOS && !UNITY_EDITOR
            return new ToastSDK.Platform.Fallback.UnityToastService();
#else
            return new ToastSDK.Platform.Editor.EditorToastService();
#endif
        }
    }
}
