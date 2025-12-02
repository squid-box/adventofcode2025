namespace AdventOfCode2025.Tests.Problems;

using System.Linq;
using AdventOfCode2025.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem2Tests
{
    private static readonly string[] TestInput =
    [
        "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124"
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem2.PartOne(TestInput), Is.EqualTo(1227775554));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem2.PartTwo(TestInput), Is.EqualTo(4174379265));
    }

    [TestCase("1", "1", 1)]
    [TestCase("11", "1", 2)]
    [TestCase("101", "1", 0)]
    [TestCase("111", "1", 3)]
    [TestCase("1111", "1", 4)]
    [TestCase("1111", "11", 2)]
    [TestCase("123123123", "123", 3)]
    [TestCase("824824824", "824", 3)]
    [TestCase("1188511885", "11885", 2)]
    public void TestCountSequentialRepeats(string text, string sequence, int count)
    {
        Assert.That(Problem2.CountSequentialRepeats(text, sequence), Is.EqualTo(count));
    }

    [TestCase(11, 22, 2)]
    [TestCase(95, 115, 2)]
    [TestCase(998, 1012, 2)]
    public void TestFindInvalidIds(long lowerRange, long upperRange, int count)
    {
        Assert.That(Problem2.FindInvalidIds(lowerRange, upperRange).Count(), Is.EqualTo(count));
    }
}