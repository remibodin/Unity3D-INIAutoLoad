# INIConfiguration

> Dépendant de INIFileParser

## HOWTO
### Definition

    using IniConfiguration;

    [ConfigurationFile("exemple.ini")]
    public static class Exemple
    {
        [Value("Section")]
        public static int IntValue = 0;
    }
