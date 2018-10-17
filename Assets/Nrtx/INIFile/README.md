# INIConfiguration

> Dépendant de INIFileParser

## HOWTO
### Definition

    using IniConfiguration.Attributes;

    [File("exemple.ini")]
    public static class Exemple
    {
        [Section("SectionName")]
        public static int IntValue = 0;
    }
