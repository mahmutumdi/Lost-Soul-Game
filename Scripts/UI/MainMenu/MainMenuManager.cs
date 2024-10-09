using Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace UI.MainMenu
{
    public class MainMenuManager : EventListenerMono
    {
        [SerializeField] private GameObject _mainMenuPanel;
        
        protected override void RegisterEvents()
        {
            MainMenuEvents.EpisodesBTN += OnEpisodesBTN;
        }

        private void OnEpisodesBTN(UISenderBTN sender)
        {
            Debug.Log("EpisodesBTN clicked: " + sender.gameObject.name);
            switch (sender.gameObject.name)
            {
                case "Ep1Button": SceneManager.LoadScene("Episode1"); break;
                case "Ep2Button": SceneManager.LoadScene("Episode2"); break;
                case "Ep3Button": SceneManager.LoadScene("Episode3"); break;
                case "Ep4Button": SceneManager.LoadScene("Episode4"); break;
                case "Ep5Button": SceneManager.LoadScene("Episode5"); break;
                case "Ep6Button": SceneManager.LoadScene("Episode6"); break;
                case "Ep7Button": SceneManager.LoadScene("Episode7"); break;
                case "Ep8Button": SceneManager.LoadScene("Episode8"); break;
                case "Ep9Button": SceneManager.LoadScene("Episode9"); break;
                case "Ep10Button": SceneManager.LoadScene("Episode10"); break;
            }
        }
    
        protected override void UnRegisterEvents()
        {
            MainMenuEvents.EpisodesBTN -= OnEpisodesBTN;
            Debug.Log("unregistermainmenu");
        }
    }
}
