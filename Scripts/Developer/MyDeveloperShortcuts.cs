using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyDeveloperShortcuts : MonoBehaviour
{
    [MenuItem("Tools/Story Intro/Mark As \"Unwatched\"")]
    private static void MarkIntroAsUnwatched()
    {
        PlayerPrefs.SetInt("HasWatchedStoryIntro", 0);
        PlayerPrefs.Save();
        Debug.Log("Intro marked as unwatched.");
    }

    [MenuItem("Tools/Story Intro/Mark As \"Watched\"")]
    private static void MarkIntroAsWatched()
    {
        PlayerPrefs.SetInt("HasWatchedStoryIntro", 1);
        PlayerPrefs.Save();
        Debug.Log("Intro marked as watched.");
    }
}
