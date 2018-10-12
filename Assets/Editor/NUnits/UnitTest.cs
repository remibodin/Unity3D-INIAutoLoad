using NUnit.Framework;

public class UnitTest
{
    [Test]
    public static void BoolValue()
    {
        IniConfiguration.File.LoadAll();
        Assert.True(ConfigTest.MyBool);
    }

    [Test]
    public static void IntValue()
    {
        IniConfiguration.File.LoadAll();
        Assert.AreEqual(ConfigTest.MyInt, 42);
    }

    [Test]
    public static void NegIntValue()
    {
        IniConfiguration.File.LoadAll();
        Assert.AreEqual(ConfigTest.MyNegInt, -42);
    }

    [Test]
    public static void StringValue()
    {
        IniConfiguration.File.LoadAll();
        Assert.AreEqual(ConfigTest.MyString, "String");
    }
}