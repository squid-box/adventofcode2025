namespace AdventOfCode2025.Tests.Utils.Extensions;

using System;
using AdventOfCode2025.Utils.Extensions;
using NUnit.Framework;

[TestFixture]
public class StringExtensionsTests
{
    [TestCase("0", 0)]
    [TestCase("-10", -10)]
    [TestCase("666", 666)]
    public void TestToInt(string source, int expectedResult)
    {
        Assert.That(source.ToInt().Equals(expectedResult));
    }

    [TestCase("0", 0L)]
    [TestCase("-10", -10L)]
    [TestCase("6000000000", 6000000000L)]
    public void TestToLong(string source, long expectedResult)
    {
        Assert.That(source.ToLong().Equals(expectedResult));
    }

    [Test]
    public void LongToInt_Throws()
    {
        Assert.Throws<OverflowException>(() => "6000000000".ToInt());
    }

    [Test]
    public void ToInt_BadString_Throws()
    {
        Assert.Throws<FormatException>(() => "hello".ToInt());
    }

    [TestCase("1", "1", 1)]
    [TestCase("11", "1", 2)]
    [TestCase("111", "1", 3)]
    [TestCase("1111", "1", 4)]
    [TestCase("1111", "11", 3)]
    [TestCase("123123123", "123", 3)]
    [TestCase("824824824", "824", 3)]
    [TestCase("1188511885", "11", 2)]
    [TestCase("1188511885", "885", 2)]
    public void TestCountInstanceOf(string text, string sequence, int count)
    {
        Assert.That(text.CountInstancesOf(sequence), Is.EqualTo(count));
    }
}