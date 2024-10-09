using Events;
using Utilities;

namespace UI.MainMenu
{
    public class EpisodesBTN : UISenderBTN
    {
        protected override void OnClick()
        {
            MainMenuEvents.EpisodesBTN?.Invoke(this);
        }
    }
}
