using ShapeLib;

const int count = 100;
var random = new Random();

var shapes = new List<IShape>(count);
for (int i = 0; i < count; i++)
{
    shapes.Add(GenerateShape(random.Next(2) > 0));
}

foreach (var shape in shapes)
{
    Console.WriteLine(shape.Area);
}

IShape GenerateShape(bool triangle)
{
    return triangle ? new Circle(10) : new Triangle(1, 3, 3);
}


