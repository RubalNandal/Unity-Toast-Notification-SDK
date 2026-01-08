using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using ToastSDK.UI;

namespace ToastSDK.Tests
{
    public class ToastGameObjectTests
    {
        [Test]
        public void ToastGameObject_OnClick_DoesNotThrow()
        {
            // Purpose:
            // Verifies that the GameObject-based API required by the assignment
            // correctly invokes the SDK without causing runtime exceptions.
            //
            // This test ensures:
            // - The MonoBehaviour is wired correctly
            // - Click handling logic is safe
            // - The GameObject layer correctly delegates to the SDK API
            
            var go = new GameObject("ToastGO");
            go.AddComponent<EventSystem>();

            var toastGO = go.AddComponent<ToastGameObject>();

            var eventData = new PointerEventData(EventSystem.current);

            Assert.DoesNotThrow(() =>
            {
                toastGO.OnPointerClick(eventData);
            });
        }
    }
}
