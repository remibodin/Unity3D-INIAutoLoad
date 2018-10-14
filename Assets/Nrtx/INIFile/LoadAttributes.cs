using System.Reflection;
using UnityEngine;
using System;

namespace IniConfiguration
{
    public static class LoadAttributes
    {
        public static void LoadFileValues(ConfigurationFile fileInfos, Type type)
        {
            File configFile = new File(fileInfos.filepath);
            foreach (var p in type.GetProperties(BindingFlags.Public | BindingFlags.Static))
            {
                foreach(Value valueAttr in p.GetCustomAttributes(typeof(Value), false))
                {
                    valueAttr.SetProperty(configFile, p);
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
                    foreach(ConfigurationFile attr in type.GetCustomAttributes(typeof(ConfigurationFile), false))
                    {
                        LoadFileValues(attr, type);
                    }
                }
            }
        }
    }
}