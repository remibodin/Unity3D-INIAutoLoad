using IniConfiguration;

[ConfigurationFile("DataTest/config.ini")]
public class ConfigTest
{
    [BoolValue("Options", "Bool", false)]
    public static bool MyBool {get; private set;}

    [IntValue("Options", "Int", 0)]
    public static int MyInt {get; private set;}

    [IntValue("Options", "NegInt", 0)]
    public static int MyNegInt {get; private set;}

    [StringValue("Options", "String", "")]
    public static string MyString {get; private set;}

    [BoolValue("Options", "BoolNoDef", false)]
    public static bool MyBoolNoDef {get; private set;}

    [IntValue("Options", "IntNoDef", 84)]
    public static int MyIntNoDef {get; private set;}

    [StringValue("Options", "StringNoDef", "NoDef")]
    public static string MyStringNoDef {get; private set;}
}
