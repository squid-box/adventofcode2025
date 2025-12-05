namespace AdventOfCode2025.Tests.Utils;

using System;
using AdventOfCode2025.Utils;
using NUnit.Framework;

[TestFixture]
public class RangeTests
{
    [TestCase(1, 5, 5)]
    [TestCase(0, 10, 11)]
    public void TestLength(long lowerBound, long upperBound, long expectedLength)
    {
        Assert.That(new Range<long>(lowerBound, upperBound).Length, Is.EqualTo(expectedLength));
    }

    public void RangeMustBeLargerThanZeroTest()
    {
        Assert.Throws<ArgumentException>(() => new Range(0, 0));
    }
}
