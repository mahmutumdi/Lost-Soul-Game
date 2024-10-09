using Events;
using Utilities;

namespace UI.GeneralPurpose
{
    public class TurkishLanguageBTN : UIBTN
    {
        protected override void OnClick()
        {
            StartMenuEvents.TurkishLangBTN?.Invoke();
        }
    }
}
