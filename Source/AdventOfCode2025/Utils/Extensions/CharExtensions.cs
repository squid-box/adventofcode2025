namespace AdventOfCode2025.Utils.Extensions;

using System;

/// <summary>
/// Extensions for chars.
/// </summary>
public static class CharExtensions
{
    /// <summary>
    /// Converts a char into an int.
    /// </summary>
    /// <param name="source">The char to convert.</param>
    /// <returns>The char as an integer.</returns>
    public static int ToInt(this char source)
    {
        return (int)char.GetNumericValue(source);
    }
}