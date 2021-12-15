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

        if (side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1)
        {
            throw new ArgumentException("Three sides does not make a triangle");
        }

        _side1 = side1;
        _side2 = side2;
        _side3 = side3;
    }

    public bool IsRightAngled
    {
        get
        {
            var sides = new[] { _side1, _side2, _side3 };
            Array.Sort(sides);
            return Math.Abs(Math.Pow(sides[2], 2) - (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2))) < Utils.Tolerance;
        }
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