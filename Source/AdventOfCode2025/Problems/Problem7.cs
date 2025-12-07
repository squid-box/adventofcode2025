namespace AdventOfCode2025.Problems;

using System.Collections.Generic;
using System.Linq;
using AdventOfCode2025.Utils;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2025/day/7">Day 7</a>.
/// </summary>
public class Problem7(InputDownloader inputDownloader) : ProblemBase(7, inputDownloader)
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
        var inputList = input.ToList();
        var map = new Matrix<char>(inputList[0].Length, inputList.Count);

        var tachyonPositions = new HashSet<Coordinate>();

        for (var y = 0; y < map.Height; y++)
        {
            for (var x = 0; x < map.Width; x++)
            {
                var tile = inputList[y][x];
                map[x,y] = tile;

                if (tile.Equals('S'))
                {
                    tachyonPositions.Add(new Coordinate(x, y) + Vector.South);
                }
            }
        }

        var numberOfSplits = 0;

        while (tachyonPositions.Count != 0)
        {
            var nextSetOfPositions = new HashSet<Coordinate>();

            foreach (var nextTachyonPosition in tachyonPositions)
            {
                if (!map.IsWithinBounds(nextTachyonPosition) || map[nextTachyonPosition].Equals('|'))
                {
                    // We don't add the next position
                    continue;
                }

                if (map[nextTachyonPosition].Equals('.'))
                {
                    map[nextTachyonPosition] = '|';
                    nextSetOfPositions.Add(nextTachyonPosition + Vector.South);
                }
                else if (map[nextTachyonPosition].Equals('^'))
                {
                    nextSetOfPositions.Add(nextTachyonPosition + Vector.West);
                    nextSetOfPositions.Add(nextTachyonPosition + Vector.East);

                    numberOfSplits++;
                }
            }

            tachyonPositions = nextSetOfPositions;
        }

        return numberOfSplits;
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        var inputList = input.ToList();
        var map = new Matrix<char>(inputList[0].Length, inputList.Count);

        Coordinate root = null;

        for (var y = 0; y < map.Height; y++)
        {
            for (var x = 0; x < map.Width; x++)
            {
                var tile = inputList[y][x];
                map[x, y] = tile;

                if (tile.Equals('S'))
                {
                    root = new Coordinate(x, y);
                }
            }
        }

        return CountTimelines(map, root, []);
    }

    private static long CountTimelines(Matrix<char> map, Coordinate position, Dictionary<Coordinate, long> cache)
    {
        if (cache.TryGetValue(position, out var cached))
        {
            return cached;
        }

        var nextPosition = position + Vector.South;

        if (map[nextPosition].Equals('.'))
        {
            cache[position] = CountTimelines(map, nextPosition, cache);
            return cache[position];
        }

        if (map[nextPosition].Equals('^'))
        {
            cache[position] = CountTimelines(map, nextPosition + Vector.West, cache) + CountTimelines(map, nextPosition + Vector.East, cache);
            return cache[position];
        }

        return 1L;
    }

}