using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Utilities
{
    public abstract class UIPressBTN : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Button _button;

        public void OnPointerDown(PointerEventData eventData)
        {
            HandlePointerDown(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            HandlePointerUp(eventData);
        }

        protected abstract void HandlePointerDown(PointerEventData eventData);
        protected abstract void HandlePointerUp(PointerEventData eventData);
    }
}