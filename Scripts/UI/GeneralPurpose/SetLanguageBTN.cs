using Events;
using Utilities;

namespace UI.GeneralPurpose
{
    public class SetLanguageBTN : UIBTN
    {
        protected override void OnClick()
        {
            StartMenuEvents.SetLanguageChoiceBTN?.Invoke();
        }
    }
}
