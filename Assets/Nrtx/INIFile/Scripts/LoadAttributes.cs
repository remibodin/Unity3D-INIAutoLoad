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

        public static void LoadFileValues(File configFile, Type type)
        {
            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                Attributes.Section[] sectionsAttrs = field.GetCustomAttributes(typeof(Attributes.Section), false) as Attributes.Section[];
                if (sectionsAttrs != null && sectionsAttrs.Length > 0)
                {
                    // get last section attribute
                    Attributes.Section sectionAttr = sectionsAttrs[sectionsAttrs.Length - 1];
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
                    // get last file attribute
                    Attributes.File[] fileAttrs = type.GetCustomAttributes(typeof(Attributes.File), false) as Attributes.File[];
                    if (fileAttrs != null && fileAttrs.Length > 0)
                    {
                        Attributes.File fileAttr = fileAttrs[fileAttrs.Length - 1];
                        File configFile = new IniConfiguration.File(fileAttr.filepath);
                        if (configFile.IsValid)
                        {
                            LoadFileValues(configFile, type);
                        }
                    }
                }
            }
        }
    }
}