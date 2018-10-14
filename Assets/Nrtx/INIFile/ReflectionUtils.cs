namespace IniConfiguration
{
    public static class ReflectionUtils
    {
        public static void SetProperty<T>(System.Reflection.PropertyInfo p, T value)
        {
            p.SetValue(null, 
                System.Convert.ChangeType(
                    value, 
                    p.PropertyType, 
                    System.Globalization.CultureInfo.CurrentCulture), 
                null);
        }
    }
}