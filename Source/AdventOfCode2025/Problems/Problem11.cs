namespace AdventOfCode2025.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2025.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2025/day/11">Day 11</a>.
/// </summary>
public class Problem11(InputDownloader inputDownloader) : ProblemBase(11, inputDownloader)
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
        return CountPaths(Parse(input), "you", "out", new Dictionary<string, long>());
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        var graph = Parse(input);

        // Find the paths passing through svr -> fft -> dac -> out
        long[] variantOne =
        [
            CountPaths(graph, "svr", "fft", []),
            CountPaths(graph, "fft", "dac", []),
            CountPaths(graph, "dac", "out", [])
        ];

        // Find the paths passing through svr -> dac -> fft -> out
        long[] variantTwo =
        [
            CountPaths(graph, "svr", "dac", []),
            CountPaths(graph, "dac", "fft", []),
            CountPaths(graph, "fft", "out", [])
        ];
        
        // Multiply the possible paths of each variant, and return the sum of those paths.
        return variantOne.Product() + variantTwo.Product();
    }
    
    private static long CountPaths(Dictionary<string, string[]> graph, string from, string to, Dictionary<string, long> cache) 
    {
        if (!cache.ContainsKey(from)) 
        {
            if (from == to) 
            {
                cache[from] = 1;
            } 
            else 
            {
                var res = 0L;
                
                foreach (var next in graph.GetValueOrDefault(from) ?? []) 
                {
                    res += CountPaths(graph, next, to, cache);
                }
                
                cache[from] = res;
            }
        }
        
        return cache[from];
    }

    private static Dictionary<string, string[]> Parse(IEnumerable<string> input)
    {
        return input
            .Select(line => line.Split(':', StringSplitOptions.TrimEntries))
            .ToDictionary(parts => parts[0], parts => parts[1].Split(' '));
    }
}