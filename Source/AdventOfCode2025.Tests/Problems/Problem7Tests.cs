namespace AdventOfCode2025.Tests.Problems;

using AdventOfCode2025.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem7Tests
{
    private static readonly string[] TestInput =
    [
        ".......S.......",
        "...............",
        ".......^.......",
        "...............",
        "......^.^......",
        "...............",
        ".....^.^.^.....",
        "...............",
        "....^.^...^....",
        "...............",
        "...^.^...^.^...",
        "...............",
        "..^...^.....^..",
        "...............",
        ".^.^.^.^.^...^.",
        "..............."
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem7.PartOne(TestInput), Is.EqualTo(21));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem7.PartTwo(TestInput), Is.EqualTo(40));
    }
}