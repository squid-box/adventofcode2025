namespace AdventOfCode2025.Utils.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Extensions for strings.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Converts a string into an int.
    /// </summary>
    /// <param name="source">The string to convert.</param>
    /// <returns>The string as an integer.</returns>
    public static int ToInt(this string source)
    {
        return Convert.ToInt32(source);
    }

    /// <summary>
    /// Converts a string into a long.
    /// </summary>
    /// <param name="source">The string to convert.</param>
    /// <returns>The string as a long.</returns>
    public static long ToLong(this string source)
    {
        return Convert.ToInt64(source);
    }

    /// <summary>
    /// Converts a string from binary to a decimal int.
    /// </summary>
    /// <param name="source">The string to convert.</param>
    /// <returns>The string as a decimal integer.</returns>
    public static int ToIntFromBinary(this string source)
    {
        return Convert.ToInt32(source, 2);
    }

    /// <summary>
    /// Sorts all characters in a string alphabetically.
    /// </summary>
    /// <param name="source">The string to sort.</param>
    /// <returns>A new string, with all <see cref="char"/>'s sorted.</returns>
    public static string SortAlphabetically(this string source)
    {
        return string.Concat(source.OrderBy(c => c));
    }

    /// <summary>
    /// Finds the number of times a given sequence appears in this string.
    /// </summary>
    /// <param name="text">The string to search for the given sequence.</param>
    /// <param name="sequence">The sequence to look for in this string.</param>
    /// <returns>The number of times the given sequence appears in this string.</returns>
    public static int CountInstancesOf(this string text, string sequence)
    {
        if (string.IsNullOrEmpty(text) || 
            string.IsNullOrEmpty(sequence) || 
            !text.Contains(sequence))
        {
            return 0;
        }

        var foundIndices = new HashSet<int>();

        for (var i = 0; i < text.Length; i++)
        {
            var index = text.Substring(i).IndexOf(sequence);

            if (index == -1)
            {
                continue;
            }

            foundIndices.Add(index + i);
        }

        return foundIndices.Count;
    }
}