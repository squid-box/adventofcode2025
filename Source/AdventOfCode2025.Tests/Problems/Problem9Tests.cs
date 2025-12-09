namespace AdventOfCode2025.Tests.Problems;

using AdventOfCode2025.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem9Tests
{
    private static readonly string[] TestInput =
    [
        "7,1",
        "11,1",
        "11,7",
        "9,7",
        "9,5",
        "2,5",
        "2,3",
        "7,3"
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem9.PartOne(TestInput), Is.EqualTo(50));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem9.PartTwo(TestInput), Is.EqualTo(24));
    }
}