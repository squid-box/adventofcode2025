namespace AdventOfCode2025.Tests.Problems;

using AdventOfCode2025.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem6Tests
{
    private static readonly string[] TestInput =
    [
        
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem6.PartOne(TestInput), Is.EqualTo(4711));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem6.PartTwo(TestInput), Is.EqualTo(4711));
    }
}