namespace AdventOfCode2025.Problems;

using System.Collections.Generic;
using System.Linq;
using AdventOfCode2025.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2025/day/3">Day 3</a>.
/// </summary>
public class Problem3(InputDownloader inputDownloader) : ProblemBase(3, inputDownloader)
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
        return input.Select(bank => CalculateMaxJoltage(bank, 2)).Sum();
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        return input.Select(bank => CalculateMaxJoltage(bank, 12)).Sum();
    }

    internal static long CalculateMaxJoltage(string bank, int numberOfBatteries)
    {
        var stack = bank.SplitToDigits().ToList();

        var lastBatteryIndex = -1;
        var selectedBatteryStack = new List<int>();

        while (numberOfBatteries-- > 0)
        {
            // Select the available batteries
            var availableStack = stack
                .Skip(lastBatteryIndex + 1)
                .Take(stack.Count - (lastBatteryIndex + 1) - numberOfBatteries)
                .ToList();

            // Find the highest value of the available batteries
            var maxValue = availableStack.Max();

            // Remember the last chosen battery
            lastBatteryIndex = stack.IndexOf(maxValue, lastBatteryIndex + 1);

            // Add the battery to the selected ones.
            selectedBatteryStack.Add(maxValue);
        }

        return selectedBatteryStack.CombineToString().ToLong();
    }
}