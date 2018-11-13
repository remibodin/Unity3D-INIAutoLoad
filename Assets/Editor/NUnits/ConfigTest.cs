using IniConfiguration.Attributes;

[File("DataTest/config.ini")]
public class ConfigTest
{
    [Section("Options")]
    public static bool MyBool = false;

    [Section("Options")]
    public static int MyInt = 0;

    [Section("Options")]
    public static int MyNegInt = 0;

    [Section("Options")]
    public static string MyString = string.Empty;

    [Section("Options")]
    public static bool MyBoolNoDef = false;

    [Section("Options")]
    public static int MyIntNoDef = 84;

    [Section("Options")]
    public static string MyStringNoDef = "NoDef";

    [Section("Options")]
    public static float MyFloat = .0f;

    [Section("Options")]
    public static float MyNegFloat = .0f;

    [Section("Options")]
    public static float MyFloatNoDef = 42.0f;

    public static int NotOverrideValue = 42;
}
