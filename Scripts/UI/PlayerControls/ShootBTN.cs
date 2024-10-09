using UnityEngine;
using Utilities;
using Events;

namespace UI.PlayerControls
{
    public class ShootBTN : UIBTN
    {
        protected override void OnClick()
        {
            PlayerEvents.ShootBTNAction?.Invoke();
        }
    }
}