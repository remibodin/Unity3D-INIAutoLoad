using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace IniConfiguration
{
    public static class LoadAttributes
    {
        private static Dictionary<Type, Action<System.Reflection.FieldInfo, string>> _loadValue = 
        new Dictionary<Type, Action<System.Reflection.FieldInfo, string>> 
        {
            {typeof(bool), ParseBool},
            {typeof(int), ParseInt},
            {typeof(string), ParseString},
            {typeof(float), ParseFloat}
        };

        public static void ParseString(System.Reflection.FieldInfo field, string value)
        {
            ReflectionUtils.SetField(field, value);
        }

        public static void ParseBool(System.Reflection.FieldInfo field, string value)
        {
            bool bValue;
            if (bool.TryParse(value, out bValue))
            {
                ReflectionUtils.SetField(field, bValue);
            }
        }

        public static void ParseInt(System.Reflection.FieldInfo field, string value)
        {
            int iValue;
            if (int.TryParse(value, out iValue))
            {
                ReflectionUtils.SetField(field, iValue);
            }
        }

        public static void ParseFloat(System.Reflection.FieldInfo field, string value)
        {
            float fValue;
            if (float.TryParse(value, out fValue))
            {
                ReflectionUtils.SetField(field, fValue);
            }
        }

        public static void LoadFileValues(Attributes.File fileInfos, Type type)
        {
            File configFile = new IniConfiguration.File(fileInfos.filepath);
            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                foreach(Attributes.Section sectionAttr in field.GetCustomAttributes(typeof(Attributes.Section), false))
                {
                    string sValue;
                    if (_loadValue.ContainsKey(field.FieldType) &&
                        configFile.TryGetString(sectionAttr.name, field.Name, out sValue))
                    {
                        _loadValue[field.FieldType](field, sValue);
                    }
                }
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void LoadAll()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    foreach(Attributes.File attr in type.GetCustomAttributes(typeof(Attributes.File), false))
                    {
                        LoadFileValues(attr, type);
                    }
                }
            }
        }
    }
}