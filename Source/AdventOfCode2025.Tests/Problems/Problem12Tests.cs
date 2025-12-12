namespace AdventOfCode2025.Tests.Problems;

using AdventOfCode2025.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem12Tests
{
    private static readonly string[] TestInput =
    [
        "0:",
        "###",
        "##.",
        "##.",
        "",
        "1:",
        "###",
        "##.",
        ".##",
        "",
        "2:",
        ".##",
        "###",
        "##.",
        "",
        "3:",
        "##.",
        "###",
        "##.",
        "",
        "4:",
        "###",
        "#..",
        "###",
        "",
        "5:",
        "###",
        ".#.",
        "###",
        "",
        "4x4: 0 0 0 0 2 0",
        "12x5: 1 0 1 0 2 2",
        "12x5: 1 0 1 0 3 2"
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem12.PartOne(TestInput), Is.EqualTo(2));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem12.PartTwo(TestInput), Is.EqualTo("N/A"));
    }
}