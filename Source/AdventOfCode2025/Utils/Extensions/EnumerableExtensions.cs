namespace AdventOfCode2025.Utils.Extensions;

using System.Collections.Generic;
using System.Linq;

public static class EnumerableExtensions
{
    extension<T>(IEnumerable<T> source)
    {
        /// <summary>
        /// Generates "linked" pairs of the items in this <see cref="IEnumerable{T}"/>.
        /// </summary>
        public IEnumerable<(T First, T Second)> Chain()
        {
            using var enumerator = source.GetEnumerator();

            if (!enumerator.MoveNext())
                yield break;

            var previous = enumerator.Current;

            while (enumerator.MoveNext())
            {
                yield return (previous, enumerator.Current);
                previous = enumerator.Current;
            }
        }
        
        /// <summary>
        /// Generates pairs of all items in this <see cref="IEnumerable{T}"/>.
        /// </summary>
        public IEnumerable<(T First, T Second)> EnumeratePairs()
            => source.SelectMany((a, i) => source.Skip(i + 1).Select(b => (a, b)));
    }
}