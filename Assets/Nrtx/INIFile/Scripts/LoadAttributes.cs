using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace IniConfiguration
{
    public static class LoadAttributes
    {
        private static Dictionary<Type, Action<System.Reflection.FieldInfo, string>> _loadValue = 
        new Dictionary<Type, Action<System.Reflection.FieldInfo, string>>();

        public static void LoadFileValues(File configFile, Type type)
        {
            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                Attributes.Section[] sectionAttrs = field.GetCustomAttributes(typeof(Attributes.Section), false) as Attributes.Section[];
                if (sectionAttrs != null && sectionAttrs.Length > 0)
                {
                    string sValue;
                    if (_loadValue.ContainsKey(field.FieldType) &&
                        configFile.TryGetString(sectionAttrs[0].name, field.Name, out sValue))
                    {
                        _loadValue[field.FieldType](field, sValue);
                    }
                }
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void LoadAll()
        {
            Type[] types = ReflectionUtils.GetTypesOfAllAssemblies();

            // TypeParser Attribute
            foreach (Type type in types)
            {
                foreach(var method in type.GetMethods(BindingFlags.Public | BindingFlags.Static))
                {
                    Attributes.TypeParser[] typeAttr = method.GetCustomAttributes(typeof(Attributes.TypeParser), false) as Attributes.TypeParser[];
                    if (typeAttr != null && typeAttr.Length > 0)
                    {
                        _loadValue[typeAttr[0].type] = (Action<System.Reflection.FieldInfo, string>)Delegate.CreateDelegate(typeof(Action<System.Reflection.FieldInfo, string>), method);
                    }
                }
            }

            // File Attribute
            foreach (Type type in types)
            {
                Attributes.File[] fileAttrs = type.GetCustomAttributes(typeof(Attributes.File), false) as Attributes.File[];
                if (fileAttrs != null && fileAttrs.Length > 0)
                {
                    File configFile = new IniConfiguration.File(fileAttrs[0].filepath);
                    if (configFile.IsValid)
                    {
                        LoadFileValues(configFile, type);
                    }
                }
            }
        }
    }
}