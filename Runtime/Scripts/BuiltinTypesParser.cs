using IniConfiguration.Attributes;

namespace IniConfiguration
{
    public static class BuiltinTypesParser
    {
        [TypeParser(typeof(string))]
        public static void ParseString(System.Reflection.FieldInfo field, string value)
        {
            ReflectionUtils.SetField(field, value);
        }

        [TypeParser(typeof(bool))]
        public static void ParseBool(System.Reflection.FieldInfo field, string value)
        {
            bool bValue;
            if (bool.TryParse(value, out bValue))
            {
                ReflectionUtils.SetField(field, bValue);
            }
        }

        [TypeParser(typeof(int))]
        public static void ParseInt(System.Reflection.FieldInfo field, string value)
        {
            int iValue;
            if (int.TryParse(value, out iValue))
            {
                ReflectionUtils.SetField(field, iValue);
            }
        }

        [TypeParser(typeof(float))]
        public static void ParseFloat(System.Reflection.FieldInfo field, string value)
        {
            float fValue;
            if (float.TryParse(value, out fValue))
            {
                ReflectionUtils.SetField(field, fValue);
            }
        }

        [TypeParser(typeof(double))]
        public static void ParseDouble(System.Reflection.FieldInfo field, string value)
        {
            double dValue;
            if (double.TryParse(value, out dValue))
            {
                ReflectionUtils.SetField(field, dValue);
            }
        }

        [TypeParser(typeof(char))]
        public static void ParseChar(System.Reflection.FieldInfo field, string value)
        {
            if (string.IsNullOrEmpty(value) == false)
            {
                ReflectionUtils.SetField(field, value[0]);
            }
        }
    }
}