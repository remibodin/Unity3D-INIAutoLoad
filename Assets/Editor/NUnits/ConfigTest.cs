using IniConfiguration;

[ConfigurationFile("DataTest/config.ini")]
public class ConfigTest
{
    [Value("Options")]
    public static bool MyBool = false;

    [Value("Options")]
    public static int MyInt = 0;

    [Value("Options")]
    public static int MyNegInt = 0;

    [Value("Options")]
    public static string MyString = string.Empty;

    [Value("Options")]
    public static bool MyBoolNoDef = false;

    [Value("Options")]
    public static int MyIntNoDef = 84;

    [Value("Options")]
    public static string MyStringNoDef = "NoDef";

    [Value("Options")]
    public static float MyFloat = .0f;

    [Value("Options")]
    public static float MyNegFloat = .0f;

    [Value("Options")]
    public static float MyFloatNoDef = 42.0f;
}
