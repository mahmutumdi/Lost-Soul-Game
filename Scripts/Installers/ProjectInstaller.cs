using System.Collections.Generic;
using Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Installers
{
    public class ProjectInstaller
    {
        public static ProjectInstaller Instance { get; private set;}
        
        public static UnityAction ProjectInstalled;
        
        public Camera MainCam { get; private set; }
        
        private const string mainMenuScene = "MainMenu";
        private Dictionary<Languages, LanguageSO> _languagePackages;

        private ProjectInstaller()
        {
            if(Instance != null)
            {
                return;
            }
            SceneManager.sceneLoaded += OnSceneLoaded;
            Instance = this;
            
            ProjectInstalled?.Invoke();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void OnBeforeSceneLoad()
        {
            ProjectInstaller projectInstaller = new();
        }

        private void OnSceneLoaded(Scene loadedScene, LoadSceneMode arg1)
        {
            if(loadedScene.name == mainMenuScene)
            {
                MainCam = Camera.main;
            }
        }

    }

    public enum Languages
    {
        Turkish,
        English
    }
    internal class LanguageSO
    {
    }
}
