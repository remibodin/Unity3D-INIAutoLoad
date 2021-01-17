namespace IniConfiguration.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class File : System.Attribute
    {
        /// <summary>
        /// Attribute use to define the path of the file use to override values
        /// </summary>
        /// <param name="filepath">The filepath relative to the executable path</param>
        public File(string filepath)
        {
            this.filepath = filepath;
        }

        public string filepath;
    } 
}