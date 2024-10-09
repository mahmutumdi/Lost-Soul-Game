using Events;
using Utilities;

namespace UI.PlayerControls.EquipAndInject
{
    public class RifleBTN : UIBTN
    {
        protected override void OnClick()
        {
            PlayerEvents.RifleBTNAction?.Invoke();
        }
    }
}