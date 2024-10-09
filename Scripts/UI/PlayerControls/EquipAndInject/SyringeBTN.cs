using Events;
using Utilities;

namespace UI.PlayerControls.EquipAndInject
{
    public class SyringeBTN: UIBTN
    {
        protected override void OnClick()
        {
            PlayerEvents.SyringeBTNAction?.Invoke();
        }
    }
}