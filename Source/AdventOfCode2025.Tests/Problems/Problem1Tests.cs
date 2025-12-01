namespace AdventOfCode2025.Tests.Problems;

using AdventOfCode2025.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem1Tests
{
    private static readonly string[] TestInputOne =
    [
        "L68",
        "L30",
        "R48",
        "L5",
        "R60",
        "L55",
        "L1",
        "L99",
        "R14",
        "L82"
    ];

    private static readonly string[] TestInputTwo =
    [
        "R1000"
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem1.PartOne(TestInputOne), Is.EqualTo(3));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem1.PartTwo(TestInputOne), Is.EqualTo(6));
        Assert.That(Problem1.PartTwo(TestInputTwo), Is.EqualTo(10));
    }
}