using IniConfiguration.Attributes;

namespace Configuration
{
    [File("configuration.ini")]
    public static class Display
    {
        [Section("Display")]
        public static bool Fullscreen = true;
    }

    [File("configuration.ini")]
    public static class Sound
    {
        [Section("Sound")]
        public static float MasterVolume = 1.0f;
    }
}