using Events;
using Unity.VisualScripting;
using UnityEngine;
using Utilities;

namespace Datas
{
    public class PlayerData
    {
        public bool LanguageChoice => _languageChoice;
        private const string LanguagePrefKey = "Language";
        private bool _languageChoice;

        public PlayerData()
        {
            if (!PlayerPrefs.HasKey(LanguagePrefKey))
            {
                PlayerPrefs.SetString(LanguagePrefKey, "English");
                PlayerPrefs.Save();
            }

            // Load the current language preference.
            _languageChoice = PlayerPrefs.GetString(LanguagePrefKey) == "English";
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            StartMenuEvents.SetLanguageChoiceBTN += OnClick;
            StartMenuEvents.EnglishLangBTN += () => OnLanguageSelected("English");
            StartMenuEvents.TurkishLangBTN += () => OnLanguageSelected("Turkish");
            //unregister???
        }

        void OnClick()
        {
            
        }
        
        private void OnLanguageSelected(string language)
        {
            _languageChoice = (language == "English");
            PlayerPrefs.SetString(LanguagePrefKey, language);
            PlayerPrefs.Save();
        }
    }
}
