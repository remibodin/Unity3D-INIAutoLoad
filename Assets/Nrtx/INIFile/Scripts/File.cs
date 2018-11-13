using IniParser;
using IniParser.Model;

namespace IniConfiguration
{
    public class File
    {
        private IniData _data = null;

        public bool IsValid { get { return _data != null; } }

        public File(string filename)
        {
            try
            {
                if (System.IO.File.Exists(filename))
                {
                    var parser = new FileIniDataParser();
                    _data = parser.ReadFile(filename);
                }
            }
            catch(System.Exception e)
            {
                UnityEngine.Debug.LogWarning(e.Message);
            }
        }

        public bool TryGetString(string section, string key, out string value)
        {
            if (IsValid == false)
            {
                value = null;
            }
            else
            {
                value = _data[section][key];
            }
            return (value != null);
        }
    }
}
