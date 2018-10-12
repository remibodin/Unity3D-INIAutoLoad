namespace IniConfiguration
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class StringValue : Value
    {
        public StringValue(string section, string key, string defaultValue) : base(section, key)
        {
            this.defaultValue = defaultValue;
        }

        public string defaultValue;

        public override void SetProperty(IniFile file, System.Reflection.PropertyInfo p)
        {
            SetProperty<string>(p, file.GetString(section, key, defaultValue));
        }
	}
}