namespace AdventOfCode2025.Utils;

using System;
using System.Collections.Generic;

/// <summary>
/// Implementation of a disjointed set, modified variant from https://github.com/tmbarker/puzzle-utils.
/// </summary>
/// <typeparam name="T">The type of value associated with each element in the set</typeparam>
public sealed class DisjointSet<T> where T : IEquatable<T>
{
    private readonly Dictionary<T, DisjointSetNode<T>> _nodes = new();

    /// <summary>
    /// Initialize a <see cref="DisjointSet{T}"/> with a set for each element in the specified <paramref name="collection"/>.
    /// </summary>
    /// <param name="collection">The elements to make a set with</param>
    public DisjointSet(IEnumerable<T> collection)
    {
        foreach (var element in collection)
        {
            MakeSet(element);
        }
    }

    /// <summary>
    /// The number of partitions (components) in the set.
    /// </summary>
    public int PartitionsCount { get; private set; }

    /// <summary>
    /// Check if the disjoint set contains the specified element. 
    /// </summary>
    /// <param name="element">The element to query membership of</param>
    /// <returns>A <see cref="bool"/> representing the success of the operation</returns>
    public bool ContainsElement(T element)
    {
        return _nodes.ContainsKey(element);
    }

    /// <summary>
    /// Attempt to add the provided element to the set.
    /// </summary>
    /// <param name="element">The element to add</param>
    /// <returns>
    /// A <see cref="bool" /> representing the success of the operation. Returns false if the element is already in the disjoint set.
    /// </returns>
    public bool MakeSet(T element)
    {
        if (ContainsElement(element))
        {
            return false;
        }

        _nodes[element] = new DisjointSetNode<T>(element);
        PartitionsCount++;
        return true;
    }

    /// <summary>
    /// Attempt to merge two sets.
    /// </summary>
    /// <param name="elementA">Element of set A.</param>
    /// <param name="elementB">Element of set B.</param>
    /// <returns>A <see cref="bool"/> representing the success of the operation.</returns>
    public bool Union(T elementA, T elementB)
    {
        var parentA = FindSet(_nodes[elementA]);
        var parentB = FindSet(_nodes[elementB]);

        if (parentA == parentB)
        {
            return false;
        }

        if (parentA.Rank >= parentB.Rank)
        {
            if (parentA.Rank == parentB.Rank)
            {
                parentA.Rank++;
            }

            parentB.Parent = parentA;
        }
        else
        {
            parentA.Parent = parentB;
        }

        PartitionsCount--;
        return true;
    }

    /// <summary>
    /// Find the set representative for the specified element.
    /// </summary>
    /// <param name="element">The element to find the set representative for</param>
    /// <returns>The representative of the set the element belongs to</returns>
    public T FindSet(T element)
    {
        return FindSet(_nodes[element]).Element;
    }

    private static DisjointSetNode<T> FindSet(DisjointSetNode<T> node)
    {
        var parent = node.Parent;
        if (parent == node)
        {
            return node;
        }

        node.Parent = FindSet(node.Parent);
        return node.Parent;
    }

    private sealed class DisjointSetNode<T1> where T1 : IEquatable<T1>
    {
        internal DisjointSetNode(T1 element)
        {
            Element = element;
            Parent = this;
            Rank = 0;
        }

        internal T1 Element { get; }

        internal DisjointSetNode<T1> Parent { get; set; }
        
        internal int Rank { get; set; }
    }
}