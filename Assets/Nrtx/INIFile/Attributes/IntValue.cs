namespace IniConfiguration
{
	[System.AttributeUsage(System.AttributeTargets.Property)]
    public class IntValue : Value
    {
        public IntValue(string section, string key, int defaultValue) : base(section, key)
        {
            this.defaultValue = defaultValue;
        }

        public int defaultValue;

        public override void SetProperty(File file, System.Reflection.PropertyInfo p)
        {
            ReflectionUtils.SetProperty<int>(p, file.GetInt(section, key, defaultValue));
        }
    }
}