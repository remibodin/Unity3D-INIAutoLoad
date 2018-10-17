namespace IniConfiguration.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class File : System.Attribute
    {
        public File(string filepath)
        {
            this.filepath = filepath;
        }

        public string filepath;
    } 
}