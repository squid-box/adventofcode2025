namespace AdventOfCode2025.Problems;

using System.Collections.Generic;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2025/day/1">Day 1</a>.
/// </summary>
public class Problem1(InputDownloader inputDownloader) : ProblemBase(1, inputDownloader)
{
    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return PartOne(Input);
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return PartTwo(Input);
    }

    public static object PartOne(IEnumerable<string> input)
    {
        return "Unsolved";
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        return "Unsolved";
    }
}