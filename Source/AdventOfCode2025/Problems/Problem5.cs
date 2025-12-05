namespace AdventOfCode2025.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2025.Utils;
using AdventOfCode2025.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2025/day/5">Day 5</a>.
/// </summary>
public class Problem5(InputDownloader inputDownloader) : ProblemBase(5, inputDownloader)
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
        var inputParts = input.ToList().SplitByBlankLines();

        var ranges = inputParts[0]
            .Select(p => p.Split('-').AsLong())
            .Select(bounds => new Range<long>(bounds[0], bounds[1]));

        var ingredients = inputParts[1].AsLong();

        return ingredients.Count(ingredient => ranges.Any(range => ingredient.IsWithin(range)));
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        var ranges = input.ToList().SplitByBlankLines()[0]
            .Select(p => p.Split('-').AsLong())
            .Select(bounds => new Range<long>(bounds[0], bounds[1]))
            .OrderBy(range => range.Lower)
            .ToList();

        var mergedRanges = new List<Range<long>>();
        var currentRange = ranges[0];

        for (var i = 1; i < ranges.Count; i++)
        {
            var nextRange = ranges[i];

            // If the next range is continuous with the current one, we merge them.
            if (currentRange.Upper >= nextRange.Lower)
            {
                currentRange = new Range<long>(currentRange.Lower, Math.Max(currentRange.Upper, nextRange.Upper));
            }
            else
            {
                // Otherwise we store the current range and move to the next range.
                mergedRanges.Add(currentRange);
                currentRange = nextRange;
            }
        }

        // Store the last range.
        mergedRanges.Add(currentRange);

        return mergedRanges.Sum(r => r.Length);
    }
}