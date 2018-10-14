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
                return false;
            }
            value = _data[section][key];
            return (value != null);
        }

        public bool TryGetInt(string section, string key, out int value)
        {
            string sValue;
            if (TryGetString(section, key, out sValue) == false)
            {
                value = 0;
                return false;
            }
            return int.TryParse(sValue, out value);
            
        }

        public bool TryGetBool(string section, string key, out bool value)
        {
            string sValue;
            if (TryGetString(section, key, out sValue) == false)
            {
                value = false;
                return false;
            }
            return bool.TryParse(sValue, out value);
        }

        public string GetString(string section, string key, string defaultValue)
        {
            string value;
            if (TryGetString(section, key, out value) == false)
            {
                return defaultValue;
            }
            return value;
        }

        public int GetInt(string section, string key, int defaultValue)
        {
            int value;
            if (TryGetInt(section, key, out value) == false)
            {
                return defaultValue;
            }
            return value;
        }

        public bool GetBool(string section, string key, bool defaultValue)
        {
            bool value;
            if (TryGetBool(section, key, out value) == false)
            {
                return defaultValue;
            }
            return value;
        }
    }
}
