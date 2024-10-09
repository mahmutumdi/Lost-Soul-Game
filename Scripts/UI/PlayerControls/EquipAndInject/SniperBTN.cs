using Events;
using Utilities;

namespace UI.PlayerControls.EquipAndInject
{
    public class SniperBTN : UIBTN
    {
        protected override void OnClick()
        {
            PlayerEvents.SniperBTNAction?.Invoke();
        }
    }
}