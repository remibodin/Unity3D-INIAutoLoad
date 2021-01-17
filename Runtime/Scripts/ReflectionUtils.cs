using System;
using System.Collections.Generic;
using System.Reflection;

namespace IniConfiguration
{
    public static class ReflectionUtils
    {
        public static void SetField<T>(FieldInfo f, T value)
        {
            f.SetValue(null, value);
        }

        public static Type[] GetTypesOfAllAssemblies()
        {
            List<Type> types = new List<Type>();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                types.AddRange(assembly.GetTypes());
            }
            return types.ToArray();
        }
    }
}