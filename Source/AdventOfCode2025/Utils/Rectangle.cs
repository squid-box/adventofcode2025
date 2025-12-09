namespace AdventOfCode2025.Utils;

public class Rectangle(Coordinate a, Coordinate b)
{
    public Coordinate From => Coordinate.MinimumOf(a, b);
    
    public Coordinate To => Coordinate.MaximumOf(a, b);

    public long Area => (long)Width * Height;

    public int Width => To.X - From.X + 1;

    public int Height => To.Y - From.Y + 1;

    public bool Intersects(Line edge)
        => edge.IsVertical
            ? edge.Start.X > From.X && edge.Start.X < To.X &&
              !(From.Y >= edge.Max.Y || To.Y <= edge.Min.Y)
            : edge.Start.Y > From.Y && edge.Start.Y < To.Y &&
              !(From.X >= edge.Max.X || To.X <= edge.Min.X);
}