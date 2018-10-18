using UnityEngine;
public class ApplyGlobalConfiguration : MonoBehaviour
{
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Screen.fullScreen = Configuration.Display.Fullscreen;
        AudioListener.volume = Configuration.Sound.MasterVolume;
    }
}