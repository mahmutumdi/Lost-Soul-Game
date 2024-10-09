using Events;
using Utilities;

namespace UI.PlayerControls.Heal
{
    public class MedkitBTN : UIBTN
    {
        protected override void OnClick()
        {
            PlayerEvents.MedkitBTNAction?.Invoke();
        }
    }
}