namespace ShapeLib;

public class Triangle : IShape
{
    private readonly double _side1;
    private readonly double _side2;
    private readonly double _side3;

    public Triangle(double side1, double side2, double side3)
    {
        if (side1 <= 0)
        {
            throw new ArgumentException("Argument must be greater than zero", nameof(side1));
        }
        if (side2 <= 0)
        {
            throw new ArgumentException("Argument must be greater than zero", nameof(side2));
        }
        if (side3 <= 0)
        {
            throw new ArgumentException("Argument must be greater than zero", nameof(side3));
        }
        _side1 = side1;
        _side2 = side2;
        _side3 = side3;
    }
    
    public double Area
    {
        get
        {
            var p = (_side1 + _side2 + _side3) / 2;
            return Math.Sqrt(p * (p - _side1) * (p - _side2) * (p - _side3));
        }
    }
}