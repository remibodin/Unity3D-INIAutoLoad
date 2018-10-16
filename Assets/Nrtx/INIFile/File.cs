using IniParser;
using IniParser.Model;

namespace IniConfiguration
{
    public class File
    {
        private IniData _data;

        public File(string filename)
        {
            try
            {
                var parser = new FileIniDataParser();
                _data = parser.ReadFile(filename);
            }
            catch(System.Exception e)
            {
                UnityEngine.Debug.LogWarning(e.Message);
            }
        }

        public bool TryGetString(string section, string key, out string value)
        {
            if (_data == null)
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
