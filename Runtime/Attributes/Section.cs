namespace IniConfiguration.Attributes
{
    public class Section : System.Attribute
    {
        /// <summary>
        /// Attribute use to make a public static variable overrided
        /// </summary>
        /// <param name="name">The section name in ini file</param>
        public Section(string name)
        {
            this.name = name;
        }
        public string name;
    }
}