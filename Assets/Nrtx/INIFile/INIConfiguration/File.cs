using System;
using System.Collections.Generic;
using System.Reflection;
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

        public string GetString(string section, string key, string defaultValue)
        {
            if (_data == null ) 
            {
                return defaultValue;
            }
            string sValue = _data[section][key];
            if (sValue == null)
            {
                return defaultValue;
            }
            return sValue;
        }

        public int GetInt(string section, string key, int defaultValue)
        {
            if (_data == null ) 
            {
                return defaultValue;
            }
            string sValue = _data[section][key];
            if (sValue == null)
            {
                return defaultValue;
            }
            int iValue;
            if (!int.TryParse(sValue, out iValue))
            {
                return defaultValue;
            }
            return iValue;
        }

        public bool GetBool(string section, string key, bool defaultValue)
        {
            if (_data == null ) 
            {
                return defaultValue;
            }
            string sValue = _data[section][key];
            if (sValue == null)
            {
                return defaultValue;
            }
            bool bValue;
            if (!bool.TryParse(sValue, out bValue))
            {
                return defaultValue;
            }
            return bValue;
        }

        public static void LoadAll()
        {
            List<Type> allTypes = new List<Type>();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    foreach(ConfigurationFile attr in type.GetCustomAttributes(typeof(ConfigurationFile), false))
                    {
                        File configFile = new File(attr.filepath);
                        foreach (var p in type.GetProperties(BindingFlags.Public | BindingFlags.Static))
                        {
                            foreach(Value valueAttr in p.GetCustomAttributes(typeof(Value), false))
                            {
                                valueAttr.SetProperty(configFile, p);
                            }
                        }
                    }
                }
            }
        }
    }
}
