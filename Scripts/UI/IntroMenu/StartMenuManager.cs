using Events;
using UnityEngine;
using Utilities;

namespace UI.IntroMenu
{
    public class StartMenuManager : EventListenerMono
    {
        [SerializeField] private GameObject _startMenuPanel;

        private void Start()
        {
            SetPanelActive(_startMenuPanel);
        }

        private void SetPanelActive(GameObject panel)
        {
            _startMenuPanel.SetActive(_startMenuPanel == panel);
        }

        protected override void RegisterEvents()
        {
            StartMenuEvents.EnglishLangBTN += OnEnglishLanguageBTN;
            StartMenuEvents.TurkishLangBTN += OnTurkishLanguageBTN;
            StartMenuEvents.SetLanguageChoiceBTN += OnSetLanguageChoiceBTN;
        }
        private void OnSetLanguageChoiceBTN()
        {
            string language = PlayerPrefs.GetString("Language", "English");
            IntroVideoController introVideoController = FindObjectOfType<IntroVideoController>();
            if (introVideoController != null)
            {
                introVideoController.ContinueVideo(language);
            }
            else
            {
                Debug.LogWarning("IntroVideoController not found.");
            }
        }

        private void OnTurkishLanguageBTN()
        {
            PlayerPrefs.SetString("Language", "Turkish");
            PlayerPrefs.Save();
            Debug.Log("Language set to: turkish");
        }

        private void OnEnglishLanguageBTN()
        {
            PlayerPrefs.SetString("Language", "English");
            PlayerPrefs.Save();
            Debug.Log("Language set to: english");
        }

        protected override void UnRegisterEvents()
        {
            StartMenuEvents.EnglishLangBTN -= OnEnglishLanguageBTN;
            StartMenuEvents.TurkishLangBTN -= OnTurkishLanguageBTN;
            StartMenuEvents.SetLanguageChoiceBTN -= OnSetLanguageChoiceBTN;
        }
        
    }
        
}
