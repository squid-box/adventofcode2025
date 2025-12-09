namespace AdventOfCode2025.Utils;

public readonly record struct Line(Coordinate Start, Coordinate End)
{
    public bool IsVertical => Start.X == End.X;

    public Coordinate Min => Coordinate.MinimumOf(Start, End);
    
    public Coordinate Max => Coordinate.MaximumOf(Start, End);
}