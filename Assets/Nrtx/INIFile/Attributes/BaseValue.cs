namespace IniConfiguration
{
    public partial class Value : System.Attribute
    {
        public Value(string section, string key)
        {
            this.section = section;
            this.key = key;
        }
        public string section;
        public string key;

        public virtual void SetProperty(File file, System.Reflection.PropertyInfo p)
        {

        }
    }
}