using ToastSDK.Core;

namespace ToastSDK
{
    public static class ToastNotifier
    {
        public static void Show(string message)
        {
            ToastService.Instance.Show(message);
        }
    }
}
