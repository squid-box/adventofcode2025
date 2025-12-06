namespace AdventOfCode2025.Tests.Problems;

using AdventOfCode2025.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem6Tests
{
    private static readonly string[] TestInput =
    [
        "123 328  51 64 ",
        " 45 64  387 23 ",
        "  6 98  215 314",
        "*   +   *   +  "
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem6.PartOne(TestInput), Is.EqualTo(4277556));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem6.PartTwo(TestInput), Is.EqualTo(3263827));
    }
}