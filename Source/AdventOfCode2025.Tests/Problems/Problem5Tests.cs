namespace AdventOfCode2025.Tests.Problems;

using AdventOfCode2025.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem5Tests
{
    private static readonly string[] TestInput =
    [
        "3-5",
        "10-14",
        "16-20",
        "12-18",
        "",
        "1",
        "5",
        "8",
        "11",
        "17",
        "32",
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem5.PartOne(TestInput), Is.EqualTo(3));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem5.PartTwo(TestInput), Is.EqualTo(14));
    }
}