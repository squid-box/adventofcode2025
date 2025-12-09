namespace AdventOfCode2025.Problems;

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
        return input
            .Select(line => new Coordinate(line.Split(',').AsInt()))
            .EnumeratePairs()
            .Select(pair => new Rectangle(pair.First, pair.Second))
            .Max(rectangle => rectangle.Area);
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        // Parse the points in the input.
        var points = input
            .Select(line => new Coordinate(line.Split(',').AsInt()))
            .ToList();
        
        // Determine the edges between the points.
        var edges = points
            .Append(points[0])
            .Chain()
            .Select(p => new Line(p.First, p.Second))
            .ToList();

        // Find the biggest area of the rectangles which do not intersect the edges.
        return points.EnumeratePairs()
            .Select(p => new Rectangle(p.First, p.Second))
            .Where(rect => !edges.Any(rect.Intersects))
            .Max(rectangle => rectangle.Area);
    }
}