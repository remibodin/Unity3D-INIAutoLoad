using NUnit.Framework;

public class UnitTest
{
    [Test]
    public static void BoolValue()
    {
        IniConfiguration.IniFile.LoadAll();
        Assert.True(ConfigTest.MyBool);
    }

    [Test]
    public static void IntValue()
    {
        IniConfiguration.IniFile.LoadAll();
        Assert.AreEqual(ConfigTest.MyInt, 42);
    }

    [Test]
    public static void NegIntValue()
    {
        IniConfiguration.IniFile.LoadAll();
        Assert.AreEqual(ConfigTest.MyNegInt, -42);
    }

    [Test]
    public static void StringValue()
    {
        IniConfiguration.IniFile.LoadAll();
        Assert.AreEqual(ConfigTest.MyString, "String");
    }
}