using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class AutoloadConfiguration 
{
    static AutoloadConfiguration()
    {
        EditorApplication.playModeStateChanged += PlayMode;
    }

    private static void PlayMode(PlayModeStateChange stateChange)
    {
        if (stateChange == PlayModeStateChange.EnteredPlayMode)
            IniConfiguration.File.LoadAll();
    }
}