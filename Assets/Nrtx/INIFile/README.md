# INIConfiguration

> Dépendant de INIFileParser

Permet de definir des valeurs de configuration via des properties attributes.

## HOWTO
### Definition

    using IniConfiguration;

    [ConfigurationFile("exemple.ini")]
    public static class Exemple
    {
        [IntValue("Section", "Key0", 0)]
        public static int IntValue { get; private set; }

        [StringValue("Section", "Key1", "defaultValue")]
        public static string StringValue { get; private set; }

        [BoolValue("Section", "Key2", true)]
        public static bool BoolValue { get; private set; }
    }
