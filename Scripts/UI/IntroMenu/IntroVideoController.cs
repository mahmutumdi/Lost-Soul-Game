using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace UI.IntroMenu
{
    public class IntroVideoController : MonoBehaviour
    {
        [SerializeField] private GameObject _startMenuPanel;
    
        [SerializeField] private VideoPlayer studioVideoPlayer;
        [SerializeField] private VideoPlayer storyVideoPlayer;
        
        [SerializeField] private VideoClip studioIntro;
        [SerializeField] private VideoClip englishStoryIntro;
        [SerializeField] private VideoClip turkishStoryIntro;
    
        private const string hasWatchedStoryIntroKey = "HasWatchedStoryIntro";
        private const string menuSceneName = "MainMenu";

        void Start()
        {
            storyVideoPlayer.gameObject.SetActive(false);
            studioVideoPlayer.clip = studioIntro;
            studioVideoPlayer.loopPointReached += OnStudioIntroEnd;
            studioVideoPlayer.Play();
        }

        void OnStudioIntroEnd(VideoPlayer vp)
        {
            studioVideoPlayer.loopPointReached -= OnStudioIntroEnd;
        
            if (PlayerPrefs.GetInt(hasWatchedStoryIntroKey, 0) == 1)
            {
                SceneManager.LoadScene(menuSceneName);
            }
            else
            {
                studioVideoPlayer.loopPointReached -= OnStudioIntroEnd;

                if (PlayerPrefs.GetInt(hasWatchedStoryIntroKey, 0) == 1)
                {
                    SceneManager.LoadScene(menuSceneName);
                }
                else
                {
                    studioVideoPlayer.gameObject.SetActive(false);
                    _startMenuPanel.SetActive(true);
                }
            }
        }

        public void ContinueVideo(string language)
        {
            _startMenuPanel.SetActive(false);
            storyVideoPlayer.gameObject.SetActive(true);

            VideoClip storyIntroClip = (language == "English") ? englishStoryIntro : turkishStoryIntro;
            storyVideoPlayer.clip = storyIntroClip;
            storyVideoPlayer.loopPointReached += OnStoryIntroEnd;
            storyVideoPlayer.Play();
        }
        void OnStoryIntroEnd(VideoPlayer vp)
        {
            PlayerPrefs.SetInt(hasWatchedStoryIntroKey, 1);
            PlayerPrefs.Save();

            SceneManager.LoadScene(menuSceneName);
        }

    


    }
}