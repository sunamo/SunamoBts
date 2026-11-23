namespace SunamoBts.Tests;

public class IntToBoolTests
{
    [Theory]
    [InlineData("1", true)]
    [InlineData("0", false)]
    [InlineData("", false)]
    [InlineData("True", true)]
    [InlineData("false", false)]
    [InlineData(" 2 ", true)]
    public void IntToBool_AcceptsNumbersAndWords(string value, bool expected)
    {
        Assert.Equal(expected, BTS.IntToBool((object)value));
    }
}
