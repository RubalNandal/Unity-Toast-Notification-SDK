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
            return new Platform.Android.AndroidToastService();
#elif UNITY_IOS && !UNITY_EDITOR
            return new Platform.iOS.UnityToastService();
#else
            return new EditorToastService();
#endif
        }
    }
}
