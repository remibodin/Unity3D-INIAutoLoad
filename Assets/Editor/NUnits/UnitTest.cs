using NUnit.Framework;

public class UnitTest
{
    [Test]
    public static void BoolValue()
    {
        IniConfiguration.LoadAttributes.LoadAll();
        Assert.AreEqual(ConfigTest.MyBool, true);
    }

    [Test]
    public static void IntValue()
    {
        IniConfiguration.LoadAttributes.LoadAll();
        Assert.AreEqual(ConfigTest.MyInt, 42);
    }

    [Test]
    public static void NegIntValue()
    {
        IniConfiguration.LoadAttributes.LoadAll();
        Assert.AreEqual(ConfigTest.MyNegInt, -42);
    }

    [Test]
    public static void StringValue()
    {
        IniConfiguration.LoadAttributes.LoadAll();
        Assert.AreEqual(ConfigTest.MyString, "String");
    }

    [Test]
    public static void BoolDefaultValue()
    {
        IniConfiguration.LoadAttributes.LoadAll();
        Assert.AreEqual(ConfigTest.MyBoolNoDef, false);
    }

    [Test]
    public static void IntDefaultValue()
    {
        IniConfiguration.LoadAttributes.LoadAll();
        Assert.AreEqual(ConfigTest.MyIntNoDef, 84);
    }

    [Test]
    public static void StringDefaultValue()
    {
        IniConfiguration.LoadAttributes.LoadAll();
        Assert.AreEqual(ConfigTest.MyStringNoDef, "NoDef");
    }
}