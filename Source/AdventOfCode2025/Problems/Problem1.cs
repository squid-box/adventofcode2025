namespace AdventOfCode2025.Problems;

using AdventOfCode2025.Utils.Extensions;
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
        var combinationLock = new CombinationLock(50);

        foreach (var line in input)
        {
            combinationLock.Rotate(line[0], line[1..].ToInt());
        }

        return combinationLock.ZeroPositions;
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        var combinationLock = new CombinationLock(50);

        foreach (var line in input)
        {
            combinationLock.Rotate(line[0], line[1..].ToInt());
        }

        return combinationLock.ZeroPasses;
    }

    private class CombinationLock
    {
        private int _currentPosition;

        public CombinationLock(int startingPosition)
        {
            _currentPosition = startingPosition;
        }

        public int ZeroPositions { get; private set; }

        public int ZeroPasses { get; private set; }

        public void Rotate(char direction, int steps)
        {
            for (var i = 0; i < steps; i++)
            {
                if (direction == 'L')
                {
                    _currentPosition--;
                }
                else
                {
                    _currentPosition++;
                }

                if (_currentPosition < 0)
                {
                    _currentPosition = 99;
                }

                if (_currentPosition == 100)
                {
                    _currentPosition = 0;
                }

                if (_currentPosition == 0)
                {
                    ZeroPasses++;
                }
            }

            if (_currentPosition == 0)
            {
                ZeroPositions++;
            }
        }
    }
}