using UnityEngine;
using UnityEngine.EventSystems;

namespace ToastSDK.UI
{
    public class ToastGameObject : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private string message = "Hello from Toast SDK";

        public void OnPointerClick(PointerEventData eventData)
        {
            ToastNotifier.Show(message);
        }
    }
}
