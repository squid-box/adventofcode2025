namespace AdventOfCode2025.Tests.Problems;

using AdventOfCode2025.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem11Tests
{
    private static readonly string[] TestInput =
    [
        "aaa: you hhh",
        "you: bbb ccc",
        "bbb: ddd eee",
        "ccc: ddd eee fff",
        "ddd: ggg",
        "eee: out",
        "fff: out",
        "ggg: out",
        "hhh: ccc fff iii",
        "iii: out"
    ];

    private static readonly string[] TestInput2 =
        [
            "svr: aaa bbb",
            "aaa: fft",
            "fft: ccc",
            "bbb: tty",
            "tty: ccc",
            "ccc: ddd eee",
            "ddd: hub",
            "hub: fff",
            "eee: dac",
            "dac: fff",
            "fff: ggg hhh",
            "ggg: out",
            "hhh: out"
        ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem11.PartOne(TestInput), Is.EqualTo(5));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem11.PartTwo(TestInput2), Is.EqualTo(2));
    }
}