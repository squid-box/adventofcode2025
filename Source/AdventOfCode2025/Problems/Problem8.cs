namespace AdventOfCode2025.Problems;

using System.Collections.Generic;
using System.Linq;
using AdventOfCode2025.Utils;
using AdventOfCode2025.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2025/day/8">Day 8</a>.
/// </summary>
public class Problem8(InputDownloader inputDownloader) : ProblemBase(8, inputDownloader)
{
    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return PartOne(Input, 1000);
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return PartTwo(Input);
    }

    public static object PartOne(IEnumerable<string> input, int targetNumberOfConnections)
    {
        var (boxes, distances) = ParseInput(input);

        var disjointSet = new DisjointSet<Coordinate>(boxes);
        var componentSizes = new Dictionary<Coordinate, int>();
        var connected = 0;
        var done = false;

        foreach (var distance in distances.OrderBy(d => d.Key))
        {
            foreach (var (a, b) in distance.Value)
            {
                disjointSet.Union(a, b);
                connected++;

                if (connected >= targetNumberOfConnections)
                {
                    done = true;
                    break;
                }
            }

            if (done)
            {
                break;
            }
        }

        foreach (var set in boxes.Select(box => disjointSet.FindSet(box)))
        {
            componentSizes.TryAdd(set, 0);
            componentSizes[set]++;
        }

        return componentSizes.Values
            .OrderByDescending(size => size)
            .Take(3)
            .Aggregate(seed: 1L, func: (acc, size) => acc * size);
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        var (boxes, distances) = ParseInput(input);

        var disjointSet = new DisjointSet<Coordinate>(boxes);
        var successfulUnions = 0;
        var requiredUnions = boxes.Count - 1;

        foreach (var distance in distances.OrderBy(d => d.Key))
        {
            foreach (var (a, b) in distance.Value)
            {
                if (disjointSet.Union(a, b))
                {
                    successfulUnions++;
                    
                    if (successfulUnions == requiredUnions)
                    {
                        return (long)a.X * b.X;
                    }
                }
            }
        }

        return -1;
    }

    private static (List<Coordinate> boxes, Dictionary<long, HashSet<(Coordinate, Coordinate)>>) ParseInput(IEnumerable<string> input)
    {
        var boxes = input
            .Select(line => new Coordinate(line.Split(',').AsInt().ToArray()))
            .ToList();

        var distances = new Dictionary<long, HashSet<(Coordinate, Coordinate)>>();

        for (var i = 0; i < boxes.Count; i++)
        {
            for (var j = i + 1; j < boxes.Count; j++)
            {
                var distance = (int)(boxes[i] - boxes[j]).Magnitude;

                if (!distances.ContainsKey(distance))
                {
                    distances.Add(distance, []);
                }

                distances[distance].Add((boxes[i], boxes[j]));
            }
        }

        return (boxes, distances);
    }
}
