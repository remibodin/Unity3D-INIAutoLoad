namespace IniConfiguration
{
    public partial class Value : System.Attribute
    {
        public Value(string section, string key)
        {
            this.section = section;
            this.key = key;
        }
        public string section;
        public string key;

        public virtual void SetProperty(IniFile file, System.Reflection.PropertyInfo p)
        {

        }

        public void SetProperty<T>(System.Reflection.PropertyInfo p, T value)
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