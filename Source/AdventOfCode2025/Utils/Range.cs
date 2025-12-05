namespace AdventOfCode2025.Utils;

using System;
using System.Numerics;

/// <summary>
/// Simple representation of an inclusive range of numbers.
/// </summary>
public record Range<T> where T : INumber<T>
{
    public Range(T lower, T upper)
    {
        if (upper <= lower)
        {
            throw new ArgumentException("Upper range must be higher than the lower range.");
        }

        Lower = lower;
        Upper = upper;
    }

    /// <summary>
    /// Gets the lower bound of this <see cref="Range" />.
    /// </summary>
    public T Lower { get; }

    /// <summary>
    /// Gets the upper bound of this <see cref="Range" />.
    /// </summary>
    public T Upper { get; }

    /// <summary>
    /// Gets the number of items between the <see cref="Lower" /> and <see cref="Upper" /> bounds.
    /// </summary>
    public T Length => Upper - Lower + T.One;
}
