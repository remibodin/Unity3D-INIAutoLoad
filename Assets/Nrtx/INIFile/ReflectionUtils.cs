namespace IniConfiguration
{
    public static class ReflectionUtils
    {
        public static void SetField<T>(System.Reflection.FieldInfo f, T value)
        {
            f.SetValue(null, value);
        }
    }
}