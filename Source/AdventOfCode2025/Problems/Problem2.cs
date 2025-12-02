namespace AdventOfCode2025.Problems;

using AdventOfCode2025.Utils.Extensions;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2025/day/2">Day 2</a>.
/// </summary>
public class Problem2(InputDownloader inputDownloader) : ProblemBase(2, inputDownloader)
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
        var ranges = input.First().Split(',');

        var total = 0L;

        foreach (var range in ranges)
        {
            var limits = range.Split('-');

            for (var n = limits[0].ToLong(); n <= limits[1].ToLong(); n++)
            {
                var number = n.ToString();

                if (number.Length % 2 != 0)
                {
                    continue;
                }

                var segmentOne = number.Substring(0, number.Length / 2);
                var segmentTwo = number.Substring(number.Length / 2);

                if (segmentOne.Equals(segmentTwo))
                {
                    total += n;
                }
            }
        }

        return total;
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        var ranges = input.First().Split(',');
        var total = 0L;

        foreach (var range in ranges)
        {
            var limits = range.Split('-');

            total += FindInvalidIds(limits[0].ToLong(), limits[1].ToLong()).Sum();
        }

        return total;
    }

    /// <summary>
    /// Gets the invalid ID's in the given range.
    /// </summary>
    /// <param name="lowerRange">Lower (inclusive) bound of the range.</param>
    /// <param name="upperRange">Upper (inclusive) bound of the range.</param>
    /// <returns>A list of any invalid ID's found in the given range.</returns>
    public static IEnumerable<long> FindInvalidIds(long lowerRange, long upperRange)
    {
        var result = new List<long>();

        for (var n = lowerRange; n <= upperRange; n++)
        {
            var number = n.ToString();

            for (var i = 1; i < number.Length; i++)
            {
                var segment = number.Substring(0, i);

                if (CountSequentialRepeats(number, segment) > 1)
                {
                    result.Add(n);
                    break;
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Finds the number of times a given sequence repeats (without breaks) in the text.
    /// </summary>
    /// <param name="text">The text to search.</param>
    /// <param name="sequence">The sequence to serach for.</param>
    /// <returns>The number of times the sequence repeats unbroken within the text.</returns>
    internal static int CountSequentialRepeats(string text, string sequence)
    {
        if (string.IsNullOrEmpty(text) || 
            string.IsNullOrEmpty(sequence) || 
            !text.Contains(sequence) ||
            text.Length % sequence.Length != 0)
        {
            return 0;
        }

        var splits = text.Chunk(sequence.Length);

        return splits.All(s => string.Equals(string.Join("", s), sequence)) ? 
            splits.Count(s => string.Equals(string.Join("", s), sequence)) : 0;
    }
}