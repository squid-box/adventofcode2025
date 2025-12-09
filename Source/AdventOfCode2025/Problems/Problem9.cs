namespace AdventOfCode2025.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2025.Utils;
using AdventOfCode2025.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2025/day/9">Day 9</a>.
/// </summary>
public class Problem9(InputDownloader inputDownloader) : ProblemBase(9, inputDownloader)
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
        var redTiles = input
            .Select(line => new Coordinate(line.Split(',').AsInt().ToArray())).ToList();

        var largestArea = 0L;

        for (var i = 0; i < redTiles.Count - 1; i++)
        {
            for (var j = 1; j < redTiles.Count; j++)
            {
                if (i == j)
                {
                    continue;
                }

                var width = Math.Abs(redTiles[j].X - redTiles[i].X) + 1L;
                var height = Math.Abs(redTiles[j].Y - redTiles[i].Y) + 1L;

                var area = width * height;

                if (area > largestArea)
                {
                    largestArea = area;
                }
            }
        }

        return largestArea;
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        return "Unsolved";
    }
}