using Events;
using Utilities;

namespace UI.PlayerControls.EquipAndInject
{
    public class PistolBTN : UIBTN
    {
        protected override void OnClick()
        {
            PlayerEvents.PistolBTNAction?.Invoke();
        }
    }
}