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
        Assert.That(actual, Is.EqualTo(expected).Within(Utils.Tolerance),
            $"Area should be equal to {expected}, got {actual}");
    }

    [TestCase(3, 4, 5, true)]
    [TestCase(1, 1, 15, false)]
    [TestCase(12, 4, 5, false)]
    [TestCase(5, 5, 100, false)]
    public void ValidTriangleTest(double side1, double side2, double side3, bool isValid)
    {
        if (!isValid)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(side1, side2, side3),
                "Three sides can't make a valid triangle. Exception must be thrown");
            return;
        }

        Assert.DoesNotThrow(() => new Triangle(side1, side2, side3),
            "Three sides make a triangle. No exception must be thrown");
    }

    [Test]
    public void RightAngledTest()
    {
        var side1 = 3;
        var side2 = 4;
        var side3 = 5;
        var rightTriangle = new Triangle(side1, side2, side3);
        Assert.AreEqual(true, rightTriangle.IsRightAngled,
            $"Triangle with sides {side1}, {side2}, {side3} should be right angled");
        //Swap sides to check that params order don't affect
        rightTriangle = new Triangle(side3, side2, side1);
        Assert.AreEqual(true, rightTriangle.IsRightAngled,
            $"Triangle with sides {side1}, {side2}, {side3} should be right angled");
        side1 = 6;
        var triangle = new Triangle(side1, side2, side3);
        Assert.AreEqual(false, triangle.IsRightAngled,
            $"Triangle with sides {side1}, {side2}, {side3} should not be right angled");
    }
}