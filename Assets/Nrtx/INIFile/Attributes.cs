using System;

namespace IniConfiguration
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class ConfigurationFile : System.Attribute
    {
        public ConfigurationFile(string filepath)
        {
            this.filepath = filepath;
        }

        public string filepath;
    }

    public partial class Value : System.Attribute
    {
        public Value(string section, string key)
        {
            this.section = section;
            this.key = key;
        }
        public string section;
        public string key;

        public virtual void SetProperty(File file, System.Reflection.PropertyInfo p)
        {

        }

        public void SetProperty<T>(System.Reflection.PropertyInfo p, T value)
        {
            p.SetValue(null, 
                Convert.ChangeType(
                    value, 
                    p.PropertyType, 
                    System.Globalization.CultureInfo.CurrentCulture), 
                null);
        }
        
    } 

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class StringValue : Value
    {
        public StringValue(string section, string key, string defaultValue) : base(section, key)
        {
            this.defaultValue = defaultValue;
        }

        public string defaultValue;

        public override void SetProperty(File file, System.Reflection.PropertyInfo p)
        {
            base.SetProperty<string>(p, file.GetString(section, key, defaultValue));
        }
    }

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
            base.SetProperty<int>(p, file.GetInt(section, key, defaultValue));
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class BoolValue : Value
    {
        public BoolValue(string section, string key, bool defaultValue) : base(section, key)
        {
            this.defaultValue = defaultValue;
        }

        public bool defaultValue;

        public override void SetProperty(File file, System.Reflection.PropertyInfo p)
        {
            base.SetProperty<bool>(p, file.GetBool(section, key, defaultValue));
        }
    }
}