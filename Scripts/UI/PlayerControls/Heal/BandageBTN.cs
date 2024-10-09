using Events;
using Utilities;

namespace UI.PlayerControls.Heal
{
    public class BandageBTN : UIBTN
    {
        protected override void OnClick()
        {
            PlayerEvents.BandageBTNAction?.Invoke();
        }
    }
}