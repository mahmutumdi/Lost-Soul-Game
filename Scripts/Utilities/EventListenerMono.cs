using UnityEngine;

namespace Utilities
{
    public abstract class EventListenerMono : MonoBehaviour
    {
        protected virtual void OnEnable() => RegisterEvents();

        protected virtual void OnDisable() => UnRegisterEvents();

        protected abstract void RegisterEvents();
        protected abstract void UnRegisterEvents();
    }
}
