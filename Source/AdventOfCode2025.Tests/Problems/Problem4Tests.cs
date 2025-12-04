namespace AdventOfCode2025.Tests.Problems;

using AdventOfCode2025.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem4Tests
{
    private static readonly string[] TestInput =
    [
        "..@@.@@@@.",
        "@@@.@.@.@@",
        "@@@@@.@.@@",
        "@.@@@@..@.",
        "@@.@@@@.@@",
        ".@@@@@@@.@",
        ".@.@.@.@@@",
        "@.@@@.@@@@",
        ".@@@@@@@@.",
        "@.@.@@@.@."
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem4.PartOne(TestInput), Is.EqualTo(13));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem4.PartTwo(TestInput), Is.EqualTo(43));
    }
}