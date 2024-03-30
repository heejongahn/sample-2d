using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public class EditorScript : MonoBehaviour
{
    static EditorScript()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        Debug.Log("Editor Script Evoked");
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        switch (state)
        {
            case PlayModeStateChange.ExitingEditMode:
                Debug.Log("Exiting Edit Mode.");
                // Code to execute when exiting edit mode before entering play mode.
                break;
            case PlayModeStateChange.EnteredPlayMode:
                Debug.Log("Entered Play Mode.");
                EditorSceneManager.LoadSceneAsync(SceneManager.GetSceneByName("GameScene").buildIndex);
                // Code to execute just after entering play mode.
                break;
            case PlayModeStateChange.ExitingPlayMode:
                Debug.Log("Exiting Play Mode.");
                // Code to execute when exiting play mode before re-entering edit mode.
                break;
            case PlayModeStateChange.EnteredEditMode:
                Debug.Log("Entered Edit Mode.");
                // Code to execute just after re-entering edit mode.
                break;
        }
    }
}
