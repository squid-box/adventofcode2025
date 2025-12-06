namespace AdventOfCode2025.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode2025.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2025/day/6">Day 6</a>.
/// </summary>
public class Problem6(InputDownloader inputDownloader) : ProblemBase(6, inputDownloader)
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
        var numberLines = new List<List<int>>();
        var operatorLine = new List<string>();

        // Parse the input into aligned lines of numbers and operators.
        foreach (var line in input)
        {
            if (line.Contains('*'))
            {
                operatorLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            else
            {
                numberLines.Add(line.Split(" ", StringSplitOptions.RemoveEmptyEntries).AsInt().ToList());
            }
        }

        var sum = 0L;

        for (var column = 0; column < operatorLine.Count; column++)
        {
            if (operatorLine[column].Equals("*"))
            {
                var columnProduct = 1L;

                // Go through each column and add the numbers.
                foreach (var line in numberLines)
                {
                    columnProduct *= line[column];
                }

                sum += columnProduct;
            }
            else if (operatorLine[column].Equals("+"))
            {
                var columnSum = 0L;

                // Go through each column and multiply the numbers.
                foreach (var line in numberLines)
                {
                    columnSum += line[column];
                }

                // Add this column's result to the total sum.
                sum += columnSum;
            }
        }

        return sum;
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        var lines = input.ToList().WithNoEmptyLines();
        var operatorLine = lines.Count - 1;

        var sum = 0L;

        var numbers = new List<long>();
        var numberBuilder = new StringBuilder();

        // Go through the columns, right-to-left.
        for (var column = lines[0].Length - 1; column >= 0; column--)
        {
            // Build the vertical number.
            for (var line = 0; line < operatorLine; line++)
            {
                if (char.IsDigit(lines[line][column]))
                {
                    numberBuilder.Append(lines[line][column]);
                }
            }

            if (numberBuilder.Length != 0)
            {
                numbers.Add(numberBuilder.ToString().ToLong());
                numberBuilder.Clear();
            }

            // Check if the column has an operator.
            var op = lines[operatorLine][column];
            if (op is '+' or '*')
            {
                if (op.Equals('+'))
                {
                    sum += numbers.Sum();
                }
                else
                {
                    sum += numbers.Product();
                }

                numbers.Clear();
            }
        }

        return sum;
    }
}