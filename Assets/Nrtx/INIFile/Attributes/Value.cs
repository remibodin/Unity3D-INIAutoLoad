namespace IniConfiguration
{
    public class Value : System.Attribute
    {
        public Value(string section)
        {
            this.section = section;
        }
        public string section;
    }
}