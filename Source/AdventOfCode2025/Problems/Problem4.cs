namespace AdventOfCode2025.Problems;

using AdventOfCode2025.Utils;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2025/day/4">Day 4</a>.
/// </summary>
public class Problem4(InputDownloader inputDownloader) : ProblemBase(4, inputDownloader)
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
        var (map, rolls) = ParseInput(input);
        var numberOfValidPositions = 0;

        foreach (var position in rolls)
        {
            var adjacentRolls = 0;

            foreach (var neighbour in position.GetNeighbors())
            {
                if (map.IsWithinBounds(neighbour) && rolls.Contains(neighbour))
                {
                    adjacentRolls++;
                }
            }

            if (adjacentRolls < 4)
            {
                numberOfValidPositions++;
            }
        }

        return numberOfValidPositions;
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        var (map, rolls) = ParseInput(input);
        var numberOfRemovedRolls = 0;

        var removedRollsThisRound = -1;

        while (removedRollsThisRound != 0)
        {
            removedRollsThisRound = 0;

            foreach (var position in rolls)
            {
                if (!map[position].Equals('@'))
                {
                    continue;
                }

                var adjacentRolls = 0;

                foreach (var neighbour in position.GetNeighbors())
                {
                    if (map.IsWithinBounds(neighbour) && rolls.Contains(neighbour))
                    {
                        adjacentRolls++;
                    }
                }

                if (adjacentRolls < 4)
                {
                    rolls.Remove(position);
                    removedRollsThisRound++;
                }
            }

            numberOfRemovedRolls += removedRollsThisRound;
        }
        

        return numberOfRemovedRolls;
    }

    internal static (Matrix<char> map, HashSet<Coordinate> rolls) ParseInput(IEnumerable<string> input)
    {
        var rawList = input.ToList();

        var map = new Matrix<char>(rawList[0].Length, rawList.Count);
        var rolls = new HashSet<Coordinate>();

        for (var y = 0; y < map.Height; y++)
        {
            var line = rawList[y];

            for (var x = 0; x < map.Width; x++)
            {
                var tile = line[x];
                map[x, y] = tile;

                if (tile.Equals('@'))
                {
                    rolls.Add(new Coordinate(x, y));
                }
            }
        }

        return (map, rolls);
    }
}