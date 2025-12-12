namespace AdventOfCode2025.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2025.Utils;
using AdventOfCode2025.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2025/day/12">Day 12</a>.
/// </summary>
public class Problem12(InputDownloader inputDownloader) : ProblemBase(12, inputDownloader)
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
        var inputChunks = input.ToList().SplitByBlankLines();

        // Parse present shapes and ID's.
        var presentTypes = new List<Present>();

        for (var chunk = 0; chunk < inputChunks.Count - 1; chunk++)
        {
            presentTypes.Add(new Present(inputChunks[chunk]));
        }

        var areasBigEnough = 0;

        // Go over the available areas.
        foreach (var line in inputChunks.Last())
        {
            var parts = line.Split(':', StringSplitOptions.TrimEntries);

            // Parse dimensions
            var dimensions = parts[0].Split('x').AsInt();

            // List how many of each present ID we need.
            var numberOfPresentsToFit = new Dictionary<int, int>();
            var presentCounts = parts[1].Split(' ').AsInt();

            for (var n = 0; n < presentCounts.Count; n++)
            {
                numberOfPresentsToFit.Add(n, presentCounts[n]);
            }

            ////////////////////////
            // Bullshit solution //
            //////////////////////
            
            // Count the number of presents we need to fit.
            var totalNumberOfPresents = numberOfPresentsToFit.Sum(kvp => kvp.Value);

            // Determine how many full lines and rows of 3x3 gifts we can fit.
            var linesOfPresents = dimensions[1] / 3;
            var rowsOfPresents = dimensions[0] / 3;

            // Check if we can fit our total number of presents in that space.
            if (linesOfPresents * rowsOfPresents >= totalNumberOfPresents)
            {
                areasBigEnough++;
            }
        }

        return areasBigEnough;
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        return "Unsolved";
    }

    private class Present
    {
        public Present(IList<string> input)
        {
            Shape = new Matrix<char>(3);

            for (var y = 0; y < input.Count; y++)
            {
                if (y == 0)
                {
                    Id = input[0].Split(':')[0].ToInt();
                    continue;
                }

                for (var x = 0; x < input[1].Length; x++)
                {
                    Shape[x, y - 1] = input[y][x];
                }
            }
        }

        public int Id { get; }

        public Matrix<char> Shape { get; }
    }
}