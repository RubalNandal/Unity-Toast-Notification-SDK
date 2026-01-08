using NUnit.Framework;
using ToastSDK;

namespace ToastSDK.Tests
{
    public class ToastNotifierTests
    {
        [Test]
        public void Show_DoesNotThrowException()
        {
            // Purpose:
            // Verifies that the public SDK entry point can be called safely
            // in the Editor environment without throwing exceptions.
            //
            // This ensures:
            // - The SDK is stable for consumers
            // - Platform resolution and fallback logic is correctly wired
            // - No native platform code is executed in the Editor
            
            Assert.DoesNotThrow(() =>
            {
                ToastNotifier.Show("Test message");
            });
        }
    }
}
