using UnityEngine;
using Utilities;
using Events;

namespace UI.PlayerControls
{
    public class JumpBTN : UIBTN
    {
        protected override void OnClick()
        {
            PlayerEvents.JumpBTNAction?.Invoke();
        }
    }
}