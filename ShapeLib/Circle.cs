namespace ShapeLib;

public class Circle : IShape
{
    /// <summary>
    /// Radius of a circle
    /// </summary>
    private readonly double _radius;

    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("Argument must be greater than zero", nameof(radius));
        }
        _radius = radius;
    }

    public double Area => _radius * _radius * Math.PI;
}