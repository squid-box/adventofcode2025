namespace AdventOfCode2025.Tests.Problems;

using AdventOfCode2025.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem3Tests
{
    private static readonly string[] TestInput =
    [
        "987654321111111",
        "811111111111119",
        "234234234234278",
        "818181911112111"
    ];

    [TestCase("987654321111111", 2, 98)]
    [TestCase("811111111111119", 2, 89)]
    [TestCase("234234234234278", 2, 78)]
    [TestCase("818181911112111", 2, 92)]
    [TestCase("987654321111111", 12, 987654321111)]
    [TestCase("811111111111119", 12, 811111111119)]
    [TestCase("234234234234278", 12, 434234234278)]
    [TestCase("818181911112111", 12, 888911112111)]
    [TestCase("99999999993241", 12, 999999999941)]
    public void TestCalculateJoltage(string bank, int numberOfBatteries, long expectedJoltage)
    {
        Assert.That(Problem3.CalculateMaxJoltage(bank, numberOfBatteries), Is.EqualTo(expectedJoltage));
    }


    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem3.PartOne(TestInput), Is.EqualTo(357));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem3.PartTwo(TestInput), Is.EqualTo(3121910778619));
    }
}