namespace IniConfiguration
{
	[System.AttributeUsage(System.AttributeTargets.Property)]
    public class BoolValue : Value
    {
        public BoolValue(string section, string key, bool defaultValue) : base(section, key)
        {
            this.defaultValue = defaultValue;
        }

        public bool defaultValue;

        public override void SetProperty(IniFile file, System.Reflection.PropertyInfo p)
        {
            base.SetProperty<bool>(p, file.GetBool(section, key, defaultValue));
        }
    }
}