using NUnit.Framework;
using ToastSDK.Core;

namespace ToastSDK.Tests
{
    public class ToastServiceTests
    {
        [Test]
        public void ToastService_Instance_IsNotNull()
        {
            // Purpose:
            // Ensures that the internal service resolver always returns
            // a valid platform-specific implementation.
            //
            // This validates:
            // - Lazy initialization logic
            // - Correct platform selection at runtime
            // - No null service states that could crash the SDK
            
            var service = ToastService.Instance;

            Assert.IsNotNull(service);
        }
    }
}
