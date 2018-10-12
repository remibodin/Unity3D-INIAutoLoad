namespace IniConfiguration
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class ConfigurationFile : System.Attribute
    {
        public ConfigurationFile(string filepath)
        {
            this.filepath = filepath;
        }

        public string filepath;
    } 
}