using System;
using NUnit.Framework;
using ShapeLib;

namespace ShapeLibTests;

public class TriangleTest
{
    [TestCase(0, 1, 2)]
    [TestCase(-1, 1, 2)]
    [TestCase(1, 0, 2)]
    [TestCase(1, -1, 2)]
    [TestCase(1, 1, 0)]
    [TestCase(1, 1, -2)]
    public void SidesShouldBeGreaterThanZeroTest(double side1, double side2, double side3)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Triangle triangle = new(side1, side2, side3);
        }, "Must throw ArgumentException");
    }

    [Test]
    public void AreaTest()
    {
        var side1 = 3;
        var side2 = 4;
        var side3 = 5;
        var expected = 6;
        var actual = new Triangle(side1, side2, side3).Area;
        Assert.That(actual, Is.EqualTo(expected).Within(Utils.Tolerance), $"Area should be equal to {expected}, got {actual}");
    }
}