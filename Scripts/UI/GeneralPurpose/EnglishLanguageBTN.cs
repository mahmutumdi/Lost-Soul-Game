using Events;
using Utilities;

namespace UI.GeneralPurpose
{
    public class EnglishLanguageBTN : UIBTN
    {
        protected override void OnClick()
        {
            StartMenuEvents.EnglishLangBTN?.Invoke();
        }
    }
}
