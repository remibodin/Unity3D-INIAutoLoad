namespace IniConfiguration.Attributes
{
    public class Section : System.Attribute
    {
        public Section(string name)
        {
            this.name = name;
        }
        public string name;
    }
}