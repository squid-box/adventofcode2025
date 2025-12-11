namespace AdventOfCode2025.Problems;

using System;
using System.Linq;
using System.Collections.Generic;
using AdventOfCode2025.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2025/day/10">Day 10</a>.
/// </summary>
public class Problem10(InputDownloader inputDownloader) : ProblemBase(10, inputDownloader)
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
        return ParseInput(input).Sum(FindLowestNumberOfClicks);
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        return "Unsolved";
    }
    
    private static int FindLowestNumberOfClicks(Machine machine)
    {
        for (var numberOfClicks = 0; numberOfClicks <= machine.Buttons.Count; numberOfClicks++)
        {
            if (TryFindSolution(machine, numberOfClicks, 0, 0, new bool[machine.TargetState.Length]))
            {
                return numberOfClicks;
            }
        }
        
        return 0;
    }
    
    private static bool TryFindSolution(Machine machine, int maxNumberOfClicks, int start, int clicks, bool[] state)
    {
        if (clicks == maxNumberOfClicks)
        {
            return state.SequenceEqual(machine.TargetState);
        }

        for (var i = start; i <= machine.Buttons.Count - (maxNumberOfClicks - clicks); i++)
        {
            ToggleLights(machine.Buttons[i], state);
            
            if (TryFindSolution(machine, maxNumberOfClicks, i + 1, clicks + 1, state))
            {
                return true;
            }
            
            ToggleLights(machine.Buttons[i], state);
        }
        
        return false;

        void ToggleLights(HashSet<int> lights, bool[] state)
        {
            foreach (var i in lights.Where(i => i < state.Length))
            {
                state[i] = !state[i];
            }
        }
    }
    
    private static List<Machine> ParseInput(IEnumerable<string> input)
    {
        var machines = new List<Machine>();

        foreach (var line in input)
        {
            var parts = line.Split(' ');
            
            var targetState = parts[0][1..^1].Select(c => c.Equals('#')).ToArray();

            var buttonsParts = parts[1..^1];
            var buttons = buttonsParts.Select(buttonsPart => buttonsPart[1..^1].Split(',').AsInt().ToHashSet()).ToList();

            var joltages = parts[^1][1..^1].Split(',').AsInt().ToArray();

            machines.Add(new Machine(targetState, buttons, joltages));
        }

        return machines;
    }
    
    private class Machine
    {
        public Machine(bool[] targetState, List<HashSet<int>> buttons, int[] joltages)
        {
            TargetState = targetState;
            Buttons = buttons;
            Joltages = joltages;
        }
        
        public List<HashSet<int>> Buttons { get; }
        
        public int[] Joltages { get; }
        
        public bool[] TargetState { get; }
    }
}
